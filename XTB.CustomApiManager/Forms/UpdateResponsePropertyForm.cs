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
    public partial class UpdateResponsePropertyForm : Form
    {
        #region Private Fields

        //private Control focus;
        private IOrganizationService _service;
        private CustomApiResponsePropertyProxy _responsepropertyproxi;
        private bool _shouldupdate = false;

        #endregion Private Fields

        #region Public Constructors

        public UpdateResponsePropertyForm(IOrganizationService service,CustomApiProxy customapi, CustomApiResponsePropertyProxy responseproperty)
        {
            InitializeComponent();
            _service = service;


            cdsCustomApiName.Entity = customapi.CustomApiRow;

            _responsepropertyproxi = responseproperty;

            txtUniqueName.Text = _responsepropertyproxi.UniqueName;
            txtName.Text = _responsepropertyproxi.Name;
            txtDisplayName.Text = _responsepropertyproxi.DisplayName;     
            txtDescription.Text = _responsepropertyproxi.Description;
            txtBoundEntityName.Text = _responsepropertyproxi.BoundEntityLogicalName;

            cboType.DataSource = Enum.GetValues(typeof(CustomAPIResponseProperty.Type_OptionSet));
            cboType.SelectedIndex = (int)_responsepropertyproxi.Type;


        }

        #endregion Public Constructors

        #region Public Properties

       
        public bool ResponsePropertyUpdated { get; private set; }

        #endregion Public Properties



        #region Private Event Handlers
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //todo modify for Update
                var responsepropertytoupdate = ResponsePropertyToUpdate();
                if (_shouldupdate)
                {

                    Cursor = Cursors.WaitCursor;
                    _service.Update(responsepropertytoupdate);
                    ResponsePropertyUpdated = true;
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


        



        #endregion Private Event Handlers

        #region Private Methods



        private Entity ResponsePropertyToUpdate() 
        {
            var requestparam = new Entity(CustomAPIResponseProperty.EntityName, _responsepropertyproxi.ResponsePropertyRow.Id);

            //Update only if needed
            _shouldupdate = false;
            if (_responsepropertyproxi.Name != txtName.Text)
            {
                requestparam[CustomAPIResponseProperty.PrimaryName] = txtName.Text;
                _shouldupdate = true;
            };

            if (_responsepropertyproxi.Description != txtDescription.Text)
            {
                requestparam[CustomAPIResponseProperty.Description] = txtDescription.Text;
                _shouldupdate = true;
            };

            if (_responsepropertyproxi.DisplayName != txtDisplayName.Text)
            {
                requestparam[CustomAPIResponseProperty.DisplayName] = txtDisplayName.Text;
                _shouldupdate = true;
            };



            return requestparam;
        }

        #endregion Private Methods

    }
}
