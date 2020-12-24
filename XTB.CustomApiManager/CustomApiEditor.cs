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
        private IOrganizationService _service;
        private FormAction _action;

        #endregion Private Fields

        #region Public Constructors

        public CustomApiEditor(IOrganizationService service, Entity customapitoupdate,Entity publisher, FormAction action)
        {
            InitializeComponent();
            _service = service;
            _action = action; 

            dlgLookupPublisher.Service = service;
            dlgLookupPluginType.Service = service;

            cboEntities.Service = service;
            cboEntities.Update();

            cboBindingType.DataSource = Enum.GetValues(typeof(CustomAPI.BindingType_OptionSet));           
            cboAllowedCustomProcessingStep.DataSource = Enum.GetValues(typeof(CustomAPI.AllowedCustomProcessingStepType_OptionSet));


            if (_action == FormAction.Create) 
            {
                cboBindingType.SelectedIndex = (int)CustomAPI.BindingType_OptionSet.Global;
                cboAllowedCustomProcessingStep.SelectedIndex = (int)CustomAPI.AllowedCustomProcessingStepType_OptionSet.None;
            }

            if(publisher != null) 
            {
                txtLookupPublisher.Entity = publisher;
                txtLookupPublisher.Text = publisher.Attributes[Publisher.PrimaryName].ToString();
                txtPrefix.Text = publisher.Attributes[Publisher.Prefix].ToString();
            }

            //cboBindingType.SelectedIndex = -1;
            //cboAllowedCustomProcessingStep.SelectedIndex = -1;

        }

        #endregion Public Constructors

        #region Public Properties

       

        public Guid Result { get; private set; }

        #endregion Public Properties

        #region Public Methods

        //public DialogResult ShowDialog(Entity input, IWin32Window owner)
        //{
        //    //var type = GetType(input);
        //    //lblName.Text = input["name"].ToString();
        //    //lblType.Text = type.ToString();
        //    //txtRecord.OrganizationService = service;
        //    ////if (!ParseInput(type, input))
        //    ////{
        //    ////    MessageBox.Show($"Type {type} is not yet supported by CAT.", "Input Parameter", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    ////    return DialogResult.Cancel;
        //    ////}
        //    //var result = ShowDialog(owner);
        //    //if (result == DialogResult.OK)
        //    //{
        //    //    result = HandleInput(type);
        //    //}
        //    //return result;
        //    return DialogResult.OK;
        //}

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
                    var prefix = _service.GetPublisherPrefix((Guid)dlgLookupPublisher.Entity.Attributes[Publisher.PrimaryKey]);
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

            api[CustomAPI.AllowedCustomProcessingStepType] = new OptionSetValue(cboAllowedCustomProcessingStep.SelectedIndex);  
            api[CustomAPI.BindingType] = new OptionSetValue(cboBindingType.SelectedIndex); 
            api[CustomAPI.Description] = txtDescription.Text;
            api[CustomAPI.DisplayName] = txtDisplayName.Text;
            api[CustomAPI.ExecutePrivilegeName] = txtExecutePrivilegeName.Text;
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
                //todo modify for Update

                Result = _service.Create(AsEntity());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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

        private bool CanCreate() 
        {
            return !string.IsNullOrEmpty(txtPrefix.Text) &&
                    !string.IsNullOrEmpty(txtUniqueName.Text) &&
                    !string.IsNullOrEmpty(txtName.Text) &&
                    !string.IsNullOrEmpty(txtDisplayName.Text) &&
                    (IsBoundToEntity() && !string.IsNullOrEmpty(cboEntities.SelectedEntity?.LogicalName)
                      ||
                    !IsBoundToEntity());


        }

        private void cboBindingType_SelectedIndexChanged(object sender, EventArgs e)
        {

            cboEntities.Enabled = cboBindingType.SelectedIndex == (int)(CustomAPI.BindingType_OptionSet.Entity);
            if (cboEntities.Enabled == true) 
            {
                cboEntities.LoadData();
            }
            else 
            {
                cboEntities.ClearData();
            }
        }
    }
}
