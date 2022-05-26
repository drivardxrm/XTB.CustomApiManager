using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Linq;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Helpers;
using XTB.CustomApiManager.Proxy;

namespace XTB.CustomApiManager.Forms
{
    public partial class NewCustomApiForm : Form
    {
        #region Private Fields

        //private Control focus;
        private IOrganizationService _service;
        private SolutionProxy _selectedSolution;
        private Settings _connectionsettings;

        #endregion Private Fields

        #region Public Constructors

        public NewCustomApiForm(IOrganizationService service, SolutionProxy solution, Settings connectionsettings)
        {
            InitializeComponent();
            _service = service;
            _connectionsettings = connectionsettings;
            

            dlgLookupPublisher.Service = service;
            dlgLookupPluginType.Service = service;
            cdsCboPrivileges.OrganizationService = service;
            cdsCboSolutions.OrganizationService = service;

            var unmanagedsolutions = _service.GetUnmanagedSolutions();
            cdsCboSolutions.SelectedIndexChanged -= new EventHandler(cdsCboSolutions_SelectedIndexChanged);
            cdsCboSolutions.DataSource = unmanagedsolutions;
            cdsCboSolutions.SelectedIndexChanged += new EventHandler(cdsCboSolutions_SelectedIndexChanged);
            
            cdsCboSolutions.SelectedIndex = unmanagedsolutions.Entities.Select(e => e.Id).ToList().IndexOf(solution?.SolutionRow?.Id ?? Guid.Empty);
            

            cboEntities.Service = service;


            cboBindingType.DataSource = Enum.GetValues(typeof(CustomAPI.BindingType_OptionSet));           
            cboAllowedCustomProcessingStep.DataSource = Enum.GetValues(typeof(CustomAPI.AllowedCustomProcessingStepType_OptionSet));

            // Set default publisher, Takes it from Settings file or from the solution
            if (_connectionsettings.DefaultPublisherId != Guid.Empty) 
            {
                var publisher = _service.GetPublisher(_connectionsettings.DefaultPublisherId);

                txtLookupPublisher.EntityReference = new EntityReference(Publisher.EntityName, _connectionsettings.DefaultPublisherId);
                txtLookupPublisher.Text = publisher.Attributes[Publisher.Name].ToString();
                txtPrefix.Text = $"{publisher.Attributes[Publisher.Prefix]}_";
            }
            else if (solution?.PublisherRef != null)
            {
                txtLookupPublisher.EntityReference = solution.PublisherRef;
                txtLookupPublisher.Text = solution.PublisherRef.Name;
                txtPrefix.Text = $"{solution.Prefix}_";
            }


            LoadPrivileges();

            //default values
            cboBindingType.SelectedIndex = (int)CustomAPI.BindingType_OptionSet.Global;
            cboAllowedCustomProcessingStep.SelectedIndex = (int)CustomAPI.AllowedCustomProcessingStepType_OptionSet.None;

            chkIsCustomizable.Checked = true; 
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// GUID of the Custom API Created
        /// </summary>
        public Guid NewCustomApiId { get; private set; }

        #endregion Public Properties



        #region Private Event Handlers
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                Cursor = Cursors.WaitCursor;
                var createRequest = new CreateRequest
                {
                    Target = CustomApiToCreate()
                };
                if (_selectedSolution != null) 
                {
                    createRequest["SolutionUniqueName"] = _selectedSolution.UniqueName;
                }

                var createResponse = (CreateResponse)_service.Execute(createRequest);

                NewCustomApiId = createResponse.id;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            }

        }


        private void txtUniqueName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                txtName.Text = txtUniqueName.Text;
            }

            if (txtDisplayName.Text == string.Empty)
            {
                txtDisplayName.Text = txtUniqueName.Text;
            }

            if (txtDescription.Text == string.Empty)
            {
                txtDescription.Text = txtUniqueName.Text;
            }

        }

        private void cboBindingType_SelectedIndexChanged(object sender, EventArgs e)
        {

            cboEntities.Enabled = IsBoundToEntity();
            if (IsBoundToEntity())
            {
                cboEntities.LoadData();
            }
            else
            {
                cboEntities.ClearData();
            }
        }

        private void btnLookupPluginType_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (dlgLookupPluginType.ShowDialog(this))
            {
                case DialogResult.OK:
                    txtLookupPluginType.Entity = dlgLookupPluginType.Entity;

                    break;
                case DialogResult.Abort:
                    //txtLookupPluginType.Entity = null;
                    break;
            }

            Cursor = Cursors.Default;
        }

        private void btnLookupPublisher_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (dlgLookupPublisher.ShowDialog(this))
            {
                case DialogResult.OK:
                    txtLookupPublisher.Entity = dlgLookupPublisher.Entity;
                    var prefix = _service.GetPublisherPrefix((Guid)dlgLookupPublisher.Entity.Attributes[Publisher.PrimaryKey]);
                    txtPrefix.Text = $"{prefix}_";

                    //unlock

                    break;
                case DialogResult.Abort:

                    break;
            }

            Cursor = Cursors.Default;
        }

        #endregion Private Event Handlers

        #region Private Methods



        #endregion Private Methods





        private Entity CustomApiToCreate() 
        {
            var api = new Entity(CustomAPI.EntityName);

            api[CustomAPI.UniqueName] = txtPrefix.Text + txtUniqueName.Text;  

            api[CustomAPI.AllowedCustomProcessingStepType] = new OptionSetValue(cboAllowedCustomProcessingStep.SelectedIndex);  
            api[CustomAPI.BindingType] = new OptionSetValue(cboBindingType.SelectedIndex); 
            api[CustomAPI.Description] = txtDescription.Text;
            api[CustomAPI.DisplayName] = txtDisplayName.Text;
            api[CustomAPI.ExecutePrivilegeName] = cdsCboPrivileges.Text;
            api[CustomAPI.IsFunction] = chkIsFunction.Checked;
            api[CustomAPI.EnabledforWorkflow] = chkWFEnabled.Checked;
            api[CustomAPI.IsPrivate] = chkIsPrivate.Checked;
            api[CustomAPI.PrimaryName] = txtName.Text;
            api[CustomAPI.IsCustomizable] = chkIsCustomizable.Checked;

            if (IsBoundToEntity()) 
            {
                api[CustomAPI.BoundEntityLogicalName] = cboEntities.SelectedEntity?.LogicalName;
            }

            if (!string.IsNullOrEmpty(txtLookupPluginType.Text)) 
            {
                api[CustomAPI.PluginType] = new EntityReference(Plug_inType.EntityName, txtLookupPluginType.Id);
            }


            return api;
        }

        

        
        private bool IsBoundToEntity()
        {
            return cboBindingType.SelectedIndex == (int)CustomAPI.BindingType_OptionSet.Entity
                    ||
                    cboBindingType.SelectedIndex == (int)CustomAPI.BindingType_OptionSet.EntityCollection;
        }

        private bool IsPublisherSelected()
        {
            return !string.IsNullOrEmpty(txtLookupPublisher.Text);
        }

        

        private void LoadPrivileges()
        {
            
             var privileges = _service.GetPrivileges();


            cdsCboPrivileges.DataSource = privileges;
            cdsCboPrivileges.SelectedIndex = -1;

        }

        private void txtLookupPluginType_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPlugintype_Click(object sender, EventArgs e)
        {

        }

        private void cdsCboSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSolution = cdsCboSolutions.SelectedIndex != -1 ?
                                            new SolutionProxy(cdsCboSolutions.SelectedEntity) :
                                            null;

        }

        private void cdsCboSolutions_TextUpdate(object sender, EventArgs e)
        {
            if (cdsCboSolutions.SelectedText == "") 
            {
                cdsCboSolutions.SelectedIndex = -1;
            }
        }
    }
}
