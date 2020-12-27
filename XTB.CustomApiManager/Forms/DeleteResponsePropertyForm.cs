using Microsoft.Xrm.Sdk;
using System;
using System.Windows.Forms;
using XTB.CustomApiManager.Entities;


namespace XTB.CustomApiManager.Forms
{
    public partial class DeleteResponsePropertyForm : Form
    {

        private IOrganizationService _service;
        private Entity _responsepropertytodelete;

        public DeleteResponsePropertyForm(IOrganizationService service, Entity customapi, Entity responsepropertytodelete)
        {
            InitializeComponent();
            _service = service;
            _responsepropertytodelete = responsepropertytodelete;

            cdsCustomApiName.Entity = customapi;
            cdsRequestParameterName.Entity = _responsepropertytodelete;

        }

       

       

        public bool ResponseParameterDeleted { get; private set; }



        

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                _service.Delete(CustomAPIResponseProperty.EntityName, _responsepropertytodelete.Id);
                ResponseParameterDeleted = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            }

        }










    }
}
