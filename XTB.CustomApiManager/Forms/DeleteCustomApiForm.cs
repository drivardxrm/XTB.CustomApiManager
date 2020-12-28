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
    public partial class DeleteCustomApiForm : Form
    {

        private IOrganizationService _service;
        private Entity _customapitodelete;

        public DeleteCustomApiForm(IOrganizationService service, Entity customapitodelete)
        {
            InitializeComponent();
            _service = service;
            _customapitodelete = customapitodelete;

            cdsCustomApiName.Entity = customapitodelete;

        }


        public bool CustomApiDeleted { get; private set; }



        

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _service.Delete(CustomAPI.EntityName, _customapitodelete.Id);
                CustomApiDeleted = true;
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
