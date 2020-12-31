using Microsoft.Xrm.Sdk;
using System;
using System.Linq;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Helpers;
using XTB.CustomApiManager.Proxy;
//using static XTB.CustomApiManager.Entities.CustomAPI;

namespace XTB.CustomApiManager.Forms
{
    public partial class UpdateCustomApiForm : Form
    {
        #region Private Fields

      
        private IOrganizationService _service;
        private CustomApiProxy _customapiproxy;
        private bool _shouldupdate;

        #endregion Private Fields

        #region Public Constructors

        public UpdateCustomApiForm(IOrganizationService service, CustomApiProxy customapitoupdate)
        {
            InitializeComponent();
            _service = service;
            _customapiproxy = customapitoupdate;

            dlgLookupPublisher.Service = service;
            dlgLookupPluginType.Service = service;
            cdsCboPrivileges.OrganizationService = service;
            cdsCboPrivileges.DataSource = 

            

            cboBindingType.DataSource = Enum.GetValues(typeof(CustomAPI.BindingType_OptionSet));           
            cboAllowedCustomProcessingStep.DataSource = Enum.GetValues(typeof(CustomAPI.AllowedCustomProcessingStepType_OptionSet));


            LoadPrivileges();

            
            txtUniqueName.Text = _customapiproxy.UniqueName;
            txtName.Text = _customapiproxy.Name;
            txtDisplayName.Text = _customapiproxy.DisplayName;
            txtDescription.Text = _customapiproxy.Description;

            cboAllowedCustomProcessingStep.SelectedIndex = (int)_customapiproxy.AllowedProcesingStep;
            cboBindingType.SelectedIndex = (int)_customapiproxy.BindingType;
            txtBoundEntity.Text = _customapiproxy.BoundEntityLogicalName;

            cdsCboPrivileges.Text = _customapiproxy.ExecutePrivilegeName;
            chkIsFunction.Checked = _customapiproxy.IsFunction;
            chkIsPrivate.Checked = _customapiproxy.IsPrivate;
            
            if (_customapiproxy.PluginType != null) 
            {
                txtLookupPluginType.EntityReference = _customapiproxy.PluginType;
                txtLookupPluginType.Text = _customapiproxy.PluginType.Name;
            }


        }

        #endregion Public Constructors

        #region Public Properties

       

        public bool CustomApiUpdated { get; private set; }

        #endregion Public Properties

        #region Public Methods



        #endregion Public Methods

        #region Private Event Handlers
        private void btnLookupPluginType_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (dlgLookupPluginType.ShowDialog(this))
            {
                case DialogResult.OK:
                    txtLookupPluginType.Entity = dlgLookupPluginType.Entity;
                    txtLookupPluginType.Text = dlgLookupPluginType.Entity.Attributes[Plug_inType.PrimaryName].ToString();

                    break;
                case DialogResult.Abort:
                    //txtLookupPluginType.Entity = null;
                    break;
            }
            //cmbValue.Text = (txtLookup?.Entity?.Id ?? Guid.Empty).ToString();
            Cursor = Cursors.Default;
        }






        #endregion Private Event Handlers

        #region Private Methods



        #endregion Private Methods





     
        private Entity CustomApiToUpdate() 
        {
            var api = new Entity(CustomAPI.EntityName,_customapiproxy.CustomApiRow.Id);
            
            //Update only if needed
            if (_customapiproxy.Name != txtName.Text) 
            {
                api[CustomAPI.PrimaryName] = txtName.Text;
                _shouldupdate = true;
            };

            if (_customapiproxy.Description != txtDescription.Text)
            {
                api[CustomAPI.Description] = txtDescription.Text;
                _shouldupdate = true;
            };

            if (_customapiproxy.DisplayName != txtDisplayName.Text)
            {
                api[CustomAPI.DisplayName] = txtDisplayName.Text;
                _shouldupdate = true;
            };

            if (_customapiproxy.ExecutePrivilegeName != cdsCboPrivileges.Text)
            {
                api[CustomAPI.ExecutePrivilegeName] = cdsCboPrivileges.Text;
                _shouldupdate = true;
            };
            if (_customapiproxy.IsPrivate != chkIsPrivate.Checked)
            {
                api[CustomAPI.IsPrivate] = chkIsPrivate.Checked;
                _shouldupdate = true;
            };

            if ((_customapiproxy.PluginType?.Id ?? Guid.Empty) != txtLookupPluginType.Id)
            {
                if (txtLookupPluginType.Id == Guid.Empty)
                {
                    api[CustomAPI.PluginType] = null;
                }
                else 
                {
                    api[CustomAPI.PluginType] = new EntityReference(Plug_inType.EntityName, txtLookupPluginType.Id);
                }

                _shouldupdate = true;
            }
            


            return api;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //todo modify for Update
                var customapitoupdate = CustomApiToUpdate();
                if (_shouldupdate)
                {
                    Cursor = Cursors.WaitCursor;
                    _service.Update(customapitoupdate);
                    CustomApiUpdated = true;
                    Cursor = Cursors.Default;
                }
                else 
                {
                    MessageBox.Show($"No change detected.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    DialogResult = DialogResult.None;
                }
                
                
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            }

        }

        
        private bool IsBoundToEntity()
        {
            return cboBindingType.SelectedIndex == (int)CustomAPI.BindingType_OptionSet.Entity
                    ||
                    cboBindingType.SelectedIndex == (int)CustomAPI.BindingType_OptionSet.EntityCollection;
        }

       

        private void LoadPrivileges()
        {
            
             var privileges = _service.GetPrivileges();

                
            //todo on update, will need to
            //Find the index of the selected API in the list
            //var index = customapis.Entities.Select(e => e.Id).ToList().IndexOf(SelectedCustomApi?.Id ?? Guid.Empty);


            cdsCboPrivileges.DataSource = privileges;
            cdsCboPrivileges.SelectedIndex = -1;
            

        }

       
    }
}
