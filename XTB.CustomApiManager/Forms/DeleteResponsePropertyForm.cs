using Microsoft.Xrm.Sdk;
using System;
using System.Windows.Forms;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Proxy;

namespace XTB.CustomApiManager.Forms
{
    public partial class DeleteResponsePropertyForm : Form
    {

        private IOrganizationService _service;
        private CustomApiResponsePropertyProxy _responsepropertytodelete;

        public DeleteResponsePropertyForm(IOrganizationService service, CustomApiProxy customapi, CustomApiResponsePropertyProxy responsepropertytodelete)
        {
            InitializeComponent();
            _service = service;
            _responsepropertytodelete = responsepropertytodelete;

            cdsCustomApiName.Entity = customapi.CustomApiRow;
            cdsRequestParameterName.Entity = _responsepropertytodelete.ResponsePropertyRow;

        }

       

       

        public bool ResponseParameterDeleted { get; private set; }



        

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _service.Delete(CustomAPIResponseProperty.EntityName, _responsepropertytodelete.ResponsePropertyRow.Id);
                ResponseParameterDeleted = true;
                Cursor = Cursors.Default;
            }

            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            }

        }










    }
}
