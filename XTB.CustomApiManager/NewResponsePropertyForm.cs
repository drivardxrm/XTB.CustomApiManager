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

namespace XTB.CustomApiManager
{
    public partial class NewResponsePropertyForm : Form
    {
        #region Private Fields

        //private Control focus;
        private IOrganizationService _service;
        

        #endregion Private Fields

        #region Public Constructors

        public NewResponsePropertyForm(IOrganizationService service,Entity customapi)
        {
            InitializeComponent();
            _service = service;


            cboEntities.Service = service;
            cboEntities.Update();

            cboType.DataSource = Enum.GetValues(typeof(CustomAPIResponseProperty.Type_OptionSet));           

            cboType.SelectedIndex = (int)CustomAPIResponseProperty.Type_OptionSet.Boolean;

            cdsCustomApiName.Entity = customapi;

        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// GUID of the Custom API Request Parameter Created
        /// </summary>
        public Guid NewCustomApiResponsePropertyId { get; private set; }

        #endregion Public Properties



        #region Private Event Handlers
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                NewCustomApiResponsePropertyId = _service.Create(ResponsePropertyToCreate());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            }

        }


        private void txtUniqueName_Leave(object sender, EventArgs e)
        {
            //todo make compositename configurable in settings
            var compositename = $"{cdsCustomApiName.EntityReference.Name}-Out-{txtUniqueName.Text}"; ;
            if (txtName.Text == string.Empty)
            {
                txtName.Text = compositename;
            }

            if (txtDisplayName.Text == string.Empty)
            {
                txtDisplayName.Text = compositename;
            }

        }

        

        #endregion Private Event Handlers

        #region Private Methods



        #endregion Private Methods

       

        



        private Entity ResponsePropertyToCreate() 
        {
            var requestparam = new Entity(CustomAPIResponseProperty.EntityName);
            requestparam[CustomAPIResponseProperty.CustomAPI] = cdsCustomApiName.EntityReference;
            requestparam[CustomAPIResponseProperty.UniqueName] = txtUniqueName.Text;
            requestparam[CustomAPIResponseProperty.PrimaryName] = txtName.Text;
            requestparam[CustomAPIResponseProperty.DisplayName] = txtDisplayName.Text;
            requestparam[CustomAPIResponseProperty.Description] = txtDescription.Text;


            requestparam[CustomAPIResponseProperty.Type] = new OptionSetValue(cboType.SelectedIndex); 

            

            if (IsBoundToEntity()) 
            {
                requestparam[CustomAPIResponseProperty.BoundEntityLogicalName] = cboEntities.SelectedEntity?.LogicalName;
            }

            


            return requestparam;
        }

        

        
        private bool IsBoundToEntity()
        {
            return cboType.SelectedIndex == (int)CustomAPIResponseProperty.Type_OptionSet.Entity
                    ||
                    cboType.SelectedIndex == (int)CustomAPIResponseProperty.Type_OptionSet.EntityCollection
                    ||
                    cboType.SelectedIndex == (int)CustomAPIResponseProperty.Type_OptionSet.EntityReference;
        }

        

        //private bool CanCreate() 
        //{
        //    return 
        //            !string.IsNullOrEmpty(txtUniqueName.Text) &&
        //            !string.IsNullOrEmpty(txtName.Text) &&
        //            !string.IsNullOrEmpty(txtDisplayName.Text) &&
        //            (IsBoundToEntity() && !string.IsNullOrEmpty(cboEntities.SelectedEntity?.LogicalName)
        //              ||
        //            !IsBoundToEntity());


        //}
        
    }
}
