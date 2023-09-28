using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
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
        private ConnectionDetail _connection;
        private IOrganizationService _service;
        private SolutionProxy _selectedSolution;
        private Settings _settings;

        #endregion Private Fields

        #region Public Constructors

        public NewRequestParameterForm(IOrganizationService service, CustomApiProxy customapi, SolutionProxy solution, Settings settings, ConnectionDetail connection)
        {
            InitializeComponent();
            _service = service;
            _settings = settings;
            _connection = connection;

            cboEntities.Service = service;

            cboType.DataSource = Enum.GetValues(typeof(CustomAPIRequestParameter.Type_OptionSet));

            cboType.SelectedIndex = (int)CustomAPIRequestParameter.Type_OptionSet.Boolean;

            cdsCustomApiName.Entity = customapi.CustomApiRow;

            cdsCboSolutions.OrganizationService = service;

            var unmanagedsolutions = _service.GetUnmanagedSolutions();
            cdsCboSolutions.SelectedIndexChanged -= new EventHandler(cdsCboSolutions_SelectedIndexChanged);
            cdsCboSolutions.DataSource = unmanagedsolutions;
            cdsCboSolutions.SelectedIndexChanged += new EventHandler(cdsCboSolutions_SelectedIndexChanged);

            cdsCboSolutions.SelectedIndex = unmanagedsolutions.Entities.Select(e => e.Id).ToList().IndexOf(solution?.SolutionRow?.Id ?? Guid.Empty);

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

            var compositename = _settings.RequestParameterDefaultName
                            .Replace("{customapiname}", cdsCustomApiName.Entity.Attributes[CustomAPI.PrimaryName].ToString())
                            .Replace("{uniquename}", txtUniqueName.Text);

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
                chkExpando.Enabled = true;
                chkExpando.Checked = false;
            }
            else
            {
                cboEntities.ClearData();
                cboEntities.Enabled = false;
                chkExpando.Enabled = false;
                chkExpando.Checked = false;
            }

        }

        private void chkExpando_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpando.Checked)
            {
                cboEntities.ClearData();
                cboEntities.Enabled = false;

            }
            else
            {
                cboEntities.LoadData();
                cboEntities.Enabled = true;
            }


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var createRequest = new CreateRequest
                {
                    Target = RequestParameterToCreate()
                };
                if (_selectedSolution != null)
                {
                    createRequest["SolutionUniqueName"] = _selectedSolution.UniqueName;
                }

                var createResponse = (CreateResponse)_service.Execute(createRequest);

                NewCustomApiRequestParameterId = createResponse.id;
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
            requestparam[CustomAPIRequestParameter.IsCustomizable] = chkIsCustomizable.Checked;


            if (IsBoundToEntity())
            {
                var boundEntityLogicalName = _connection.UseOnline ? CustomAPIRequestParameter.BoundEntityLogicalName : CustomApiHelper.OnPremBoundEntityLogicalName;
                requestparam[boundEntityLogicalName] = cboEntities.SelectedEntity?.LogicalName;
            }




            return requestparam;
        }




        private bool IsBoundToEntity()
        {
            return cboType.SelectedIndex == (int)CustomAPIRequestParameter.Type_OptionSet.Entity
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

        private void cdsCboSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSolution = cdsCboSolutions.SelectedIndex != -1 ?
                                            new SolutionProxy(cdsCboSolutions.SelectedEntity) :
                                            null;

        }

        private void cdsCboSolutions_TextUpdate(object sender, EventArgs e)
        {
            if (cdsCboSolutions.SelectedText == "")
            {
                cdsCboSolutions.SelectedIndex = -1;
            }
        }

        private void lnkInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://powermaverick.dev/2021/11/17/dataverse-custom-api-that-supports-complex-json-schema/");
        }
    }
}
