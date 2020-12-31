using Microsoft.Xrm.Sdk;
using System;
using System.Windows.Forms;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Proxy;

namespace XTB.CustomApiManager.Forms
{
    public partial class DeleteRequestParameterForm : Form
    {

        private IOrganizationService _service;
        private CustomApiRequestParameterProxy _requestparametertodelete;

        public DeleteRequestParameterForm(IOrganizationService service, CustomApiProxy customapi, CustomApiRequestParameterProxy requestparametertodelete)
        {
            InitializeComponent();
            _service = service;
            _requestparametertodelete = requestparametertodelete;

            cdsCustomApiName.Entity = customapi?.CustomApiRow;
            cdsRequestParameterName.Entity = _requestparametertodelete.RequestParameterRow;

        }

       

       

        public bool RequestParameterDeleted { get; private set; }



        

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _service.Delete(CustomAPIRequestParameter.EntityName, _requestparametertodelete.RequestParameterRow.Id);
                RequestParameterDeleted = true;
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
