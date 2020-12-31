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
    public partial class NewRequestParameterForm : Form
    {
        #region Private Fields

        //private Control focus;
        private IOrganizationService _service;
        

        #endregion Private Fields

        #region Public Constructors

        public NewRequestParameterForm(IOrganizationService service,CustomApiProxy customapi)
        {
            InitializeComponent();
            _service = service;


            cboEntities.Service = service;

            cboType.DataSource = Enum.GetValues(typeof(CustomAPIRequestParameter.Type_OptionSet));           

            cboType.SelectedIndex = (int)CustomAPIRequestParameter.Type_OptionSet.Boolean;

            cdsCustomApiName.Entity = customapi.CustomApiRow;

        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// GUID of the Custom API Request Parameter Created
        /// </summary>
        public Guid NewCustomApiRequestParameterId { get; private set; }

        #endregion Public Properties



        #region Private Event Handlers
        


        private void txtUniqueName_Leave(object sender, EventArgs e)
        {
            //todo make compositename configurable in settings
            var compositename = $"{cdsCustomApiName.Entity.Attributes[CustomAPI.PrimaryName]}-In-{txtUniqueName.Text}"; 
            if (txtName.Text == string.Empty)
            {
                txtName.Text = compositename;
            }

            if (txtDisplayName.Text == string.Empty)
            {
                txtDisplayName.Text = compositename;
            }

        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBoundToEntity())
            {
                cboEntities.LoadData();
                cboEntities.Enabled = true;
            }
            else 
            {
                cboEntities.ClearData();
                cboEntities.Enabled = false;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                NewCustomApiRequestParameterId = _service.Create(RequestParameterToCreate());
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            }

        }


        #endregion Private Event Handlers

        #region Private Methods



        #endregion Private Methods







        private Entity RequestParameterToCreate() 
        {
            var requestparam = new Entity(CustomAPIRequestParameter.EntityName);
            requestparam[CustomAPIRequestParameter.CustomAPI] = cdsCustomApiName.EntityReference;
            requestparam[CustomAPIRequestParameter.UniqueName] = txtUniqueName.Text;
            requestparam[CustomAPIRequestParameter.PrimaryName] = txtName.Text;
            requestparam[CustomAPIRequestParameter.DisplayName] = txtDisplayName.Text;
            requestparam[CustomAPIRequestParameter.Description] = txtDescription.Text;


            requestparam[CustomAPIRequestParameter.Type] = new OptionSetValue(cboType.SelectedIndex); 
            
            
           
            requestparam[CustomAPIRequestParameter.IsOptional] = chkIsOptional.Checked;
            

            if (IsBoundToEntity()) 
            {
                requestparam[CustomAPIRequestParameter.BoundEntityLogicalName] = cboEntities.SelectedEntity?.LogicalName;
            }

            


            return requestparam;
        }

        

        
        private bool IsBoundToEntity()
        {
            return cboType.SelectedIndex == (int)CustomAPIRequestParameter.Type_OptionSet.Entity
                    ||
                    cboType.SelectedIndex == (int)CustomAPIRequestParameter.Type_OptionSet.EntityCollection
                    ||
                    cboType.SelectedIndex == (int)CustomAPIRequestParameter.Type_OptionSet.EntityReference;
        }

        

        private bool CanCreate() 
        {
            return 
                    !string.IsNullOrEmpty(txtUniqueName.Text) &&
                    !string.IsNullOrEmpty(txtName.Text) &&
                    !string.IsNullOrEmpty(txtDisplayName.Text) &&
                    (IsBoundToEntity() && !string.IsNullOrEmpty(cboEntities.SelectedEntity?.LogicalName)
                      ||
                    !IsBoundToEntity());


        }

        
    }
}
