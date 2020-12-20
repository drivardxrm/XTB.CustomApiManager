using Microsoft.Xrm.Sdk;
using System;
using System.Linq;
using System.Windows.Forms;
using xrmtb.XrmToolBox.Controls.Controls;
using XrmToolBox.Extensibility;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Helpers;
//using static XTB.CustomApiManager.Entities.CustomAPI;

namespace XTB.CustomApiManager
{
    public partial class CustomApiEditor : Form
    {
        #region Private Fields

        private Control focus;
        private IOrganizationService service;

        #endregion Private Fields

        #region Public Constructors

        public CustomApiEditor(IOrganizationService service)
        {
            InitializeComponent();
            this.service = service;

            dlgLookupPublisher.Service = service;
            dlgLookupPluginType.Service = service;

            cboEntities.Service = service;
            cboEntities.Update();

            cboBindingType.DataSource = Enum.GetValues(typeof(CustomAPI.BindingType_OptionSet));
            cboBindingType.SelectedIndex = -1;
            cboAllowedCustomProcessingStep.DataSource = Enum.GetValues(typeof(CustomAPI.AllowedCustomProcessingStepType_OptionSet));
            cboAllowedCustomProcessingStep.SelectedIndex = -1;

        }

        #endregion Public Constructors

        #region Public Properties

        public object FormattedResult { get; private set; }

        public object Result { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public DialogResult ShowDialog(Entity input, IWin32Window owner)
        {
            //var type = GetType(input);
            //lblName.Text = input["name"].ToString();
            //lblType.Text = type.ToString();
            //txtRecord.OrganizationService = service;
            ////if (!ParseInput(type, input))
            ////{
            ////    MessageBox.Show($"Type {type} is not yet supported by CAT.", "Input Parameter", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            ////    return DialogResult.Cancel;
            ////}
            //var result = ShowDialog(owner);
            //if (result == DialogResult.OK)
            //{
            //    result = HandleInput(type);
            //}
            //return result;
            return DialogResult.OK;
        }

        #endregion Public Methods

        #region Private Event Handlers

       

        

        private void InputValue_Shown(object sender, EventArgs e)
        {
            focus?.Focus();
        }

        #endregion Private Event Handlers

        #region Private Methods



        #endregion Private Methods

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

        private void btnLookupPublisher_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (dlgLookupPublisher.ShowDialog(this))
            {
                case DialogResult.OK:
                    txtLookupPublisher.Entity = dlgLookupPublisher.Entity;
                    txtLookupPublisher.Text = dlgLookupPublisher.Entity.Attributes[Publisher.PrimaryName].ToString();
                    var prefix = service.GetPublisherPrefix((Guid)dlgLookupPublisher.Entity.Attributes[Publisher.PrimaryKey]);
                    txtPrefix.Text = $"{prefix}_";

                    //unlock

                    break;
                case DialogResult.Abort:
                    //txtLookupPluginType.Entity = null;
                    break;
            }
            //cmbValue.Text = (txtLookup?.Entity?.Id ?? Guid.Empty).ToString();
            Cursor = Cursors.Default;
        }


        private Entity AsEntity() 
        {
            var api = new Entity(CustomAPI.EntityName);

            api[CustomAPI.UniqueName] = txtPrefix.Text + txtUniqueName.Text;  

            api[CustomAPI.AllowedCustomProcessingStepType] = new OptionSetValue(cboAllowedCustomProcessingStep.SelectedIndex);  //none
            api[CustomAPI.BindingType] = new OptionSetValue(cboBindingType.SelectedIndex);  //Global
            api[CustomAPI.Description] = txtDescription.Text;
            api[CustomAPI.DisplayName] = txtDisplayName.Text;
            //api[CustomAPI.ExecutePrivilegeName] = null; TODO
            api[CustomAPI.IsFunction] = chkIsFunction.Checked;
            api[CustomAPI.IsPrivate] = chkIsPrivate.Checked;
            api[CustomAPI.PrimaryName] = txtName.Text;

            if (IsBoundToEntity()) 
            {
                api[CustomAPI.BoundEntityLogicalName] = cboEntities.SelectedEntity?.LogicalName;
            }

            if (!string.IsNullOrEmpty(txtLookupPluginType.Text)) 
            {
                api[CustomAPI.PluginType] = new EntityReference(Plug_inType.EntityName, txtLookupPluginType.Id); //todo skip if null
            }


            return api;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                service.Create(AsEntity());
            }
            catch (Exception)
            {

                throw;
            }

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
    }
}
