using Microsoft.Xrm.Sdk;
using System;
using System.Windows.Forms;
using XTB.CustomApiManager.Entities;


namespace XTB.CustomApiManager.Forms
{
    public partial class DeleteRequestParameterForm : Form
    {

        private IOrganizationService _service;
        private Entity _requestparametertodelete;

        public DeleteRequestParameterForm(IOrganizationService service, Entity customapi, Entity requestparametertodelete)
        {
            InitializeComponent();
            _service = service;
            _requestparametertodelete = requestparametertodelete;

            cdsCustomApiName.Entity = customapi;
            cdsRequestParameterName.Entity = _requestparametertodelete;

        }

       

       

        public bool RequestParameterDeleted { get; private set; }



        

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                _service.Delete(CustomAPIRequestParameter.EntityName, _requestparametertodelete.Id);
                RequestParameterDeleted = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.None;
            }

        }










    }
}
