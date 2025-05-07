using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using System.Reflection;
using XTB.CustomApiManager.Helpers;
using XTB.CustomApiManager.Proxy;
using XTB.CustomApiManager.Entities;
using xrmtb.XrmToolBox.Controls.Controls;
using xrmtb.XrmToolBox.Controls;
using XTB.CustomApiManager.Forms;
using XrmToolBox.Extensibility.Interfaces;
using System.Web.Services.Description;
using static ScintillaNET.Style;
using System.ComponentModel.Composition.Hosting;

namespace XTB.CustomApiManager
{
    public partial class CustomApiManagerControl : PluginControlBase, IMessageBusHost, IGitHubPlugin
    {

        private Settings _globalsettings;

        private Settings _connectionsettings;

        private SolutionProxy _selectedSolution;

        private CustomApiProxy _selectedCustomApi;

        private CustomApiRequestParameterProxy _selectedRequestParameter;

        private CustomApiResponsePropertyProxy _selectedResponseProperty;

        private FxExpressionProxy _selectedFxExpression;

        //private Entity _selectedPublisher;

        public string RepositoryName => "XTB.CustomApiManager";

        public string UserName => "drivardxrm";



        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        public CustomApiManagerControl()
        {
            InitializeComponent();
        }

        private void CustomApiManagerControl_Load(object sender, EventArgs e)
        {
            LoadGlobalSettings();
            LoadConnectionSettings();

            ExecuteMethod(InitializeService);

            //select the all radio button
            rbAll.Checked = true;
            //ExecuteMethod(LoadCustomApis);
            cdsCboCustomApi.Select();
        }

        private void LoadConnectionSettings()
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out _connectionsettings, ConnectionDetail.ConnectionId.ToString()))
            {
                _connectionsettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void LoadGlobalSettings()
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out _globalsettings))
            {
                _globalsettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void InitializeService()
        {

            dlgLookupPluginType.Service = Service;
            dlgLookupPublisher.Service = Service;

            cdsCboCustomApi.OrganizationService = Service;
            cdsTxtPluginType.OrganizationService = Service;
            cdsTxtUniqueName.OrganizationService = Service;

            cdsTxtName.OrganizationService = Service;
            cdsTxtDisplayName.OrganizationService = Service;
            cdsTxtDescription.OrganizationService = Service;
            cdsTxtAllowedCustomProcessingStep.OrganizationService = Service;
            cdsTxtBindingType.OrganizationService = Service;
            cdsTxtBoundEntity.OrganizationService = Service;
            cdsTxtExecutePrivilegeName.OrganizationService = Service;

            cdsTxtIsFunction.OrganizationService = Service;
            if (ConnectionDetail.UseOnline) // WFEnabled is not available in OnPremise
            {
                cdsTxtIsWFEnabled.OrganizationService = Service;
            }
            else 
            {
                cdsTxtIsWFEnabled.Visible = false;
                pictureBox1.Visible = false;
                label29.Visible = false;
            }
            cdsTxtIsPrivate.OrganizationService = Service;
            cdsTxtIsManaged.OrganizationService = Service;
            cdsTxtIsCustomizable.OrganizationService = Service;

            //input params
            cdsGridInputs.OrganizationService = Service;
            cdsTxtRequestUniqueName.OrganizationService = Service;
            cdsTxtRequestName.OrganizationService = Service;
            cdsTxtRequestDisplayName.OrganizationService = Service;
            cdsTxtRequestDescription.OrganizationService = Service;
            cdsTxtRequestIsOptional.OrganizationService = Service;
            cdsTxtRequestType.OrganizationService = Service;
            cdsTxtRequestIsCustomizable.OrganizationService = Service;
            cdsTxtRequestIsManaged.OrganizationService = Service;

            //output props
            cdsGridOutputs.OrganizationService = Service;
            cdsTxtResponseUniqueName.OrganizationService = Service;
            cdsTxtResponseName.OrganizationService = Service;
            cdsTxtResponseDisplayName.OrganizationService = Service;
            cdsTxtResponseDescription.OrganizationService = Service;
            cdsTxtResponseType.OrganizationService = Service;
            cdsTxtResponseIsCustomizable.OrganizationService = Service;
            cdsTxtResponseIsManaged.OrganizationService = Service;


        }

        //If Plugin is opened from Integration with another plugin
        //TargetArgumet = GUID of Custom API to display (string format)	Id
        public void OnIncomingMessage(MessageBusEventArgs message)
        {

            if (message.TargetArgument is string arg && Guid.TryParse(arg, out Guid argid))
            {
                var customapi = Service.GetCustomApi(argid);
                SetSelectedCustomApi(customapi);

            }
        }


        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomApiManagerControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), _globalsettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);


            if (_globalsettings != null && detail != null)
            {
                LoadConnectionSettings();

                _globalsettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);

                SetCdsCboCustomApiDataSource(null);


                //LoadSolutions();
                ExecuteMethod(InitializeService);


                //select the all radio button
                rbAll.Checked = true;
                ExecuteMethod(LoadCustomApis);
                cdsCboCustomApi.Select();
            }
        }



        #region Form Events
        private void menuRefresh_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadCustomApis);
        }


        private void menuNewApi_Click(object sender, EventArgs e)
        {
            CreateApiDialog();
        }
        private void menuTestApi_Click(object sender, EventArgs e)
        {

            try
            {
                OnOutgoingMessage(this, new MessageBusEventArgs("Custom API Tester") { TargetArgument = _selectedCustomApi.CustomApiRow.Id.ToString() });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void menuPluginTrace_Click(object sender, EventArgs e)
        {
            try
            {
                var filter = $"message={_selectedCustomApi.UniqueName}";
                
                OnOutgoingMessage(this, new MessageBusEventArgs("Plugin Trace Viewer") { TargetArgument = filter });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            SettingsDialog();
        }

        private void btnNewApi_Click(object sender, EventArgs e)
        {
            CreateApiDialog();
        }

        private void btnEditCustomApi_Click(object sender, EventArgs e)
        {
            UpdateApiDialog();
        }



        private void btnAddInput_Click(object sender, EventArgs e)
        {
            CreateRequestParameterDialog();
        }

        private void btnEditInput_Click(object sender, EventArgs e)
        {
            UpdateRequestParameterDialog();
        }



        private void btnAddOutput_Click(object sender, EventArgs e)
        {
            CreateResponsePropertyDialog();
        }



        private void btnEditOutput_Click(object sender, EventArgs e)
        {
            UpdateResponsePropertyDialog();
        }


        private void btnDeleteApi_Click(object sender, EventArgs e)
        {
            DeleteApiDialog();
        }



        private void btnDeleteInput_Click(object sender, EventArgs e)
        {
            DeleteRequestParameterDialog();
        }

        private void btnDeleteOutput_Click(object sender, EventArgs e)
        {
            DeleteResponsePropertyDialog();
        }


        private void tslAbout_Click(object sender, EventArgs e)
        {


            var about = new About();
            about.StartPosition = FormStartPosition.CenterParent;
            about.lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            about.ShowDialog();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                ExecuteMethod(LoadCustomApis);
            }
        }

        private void rbSolution_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSolution.Checked)
            {

                SetCdsCboCustomApiDataSource(null);


                cdsCboCustomApi.SelectedIndex = -1;

                cdsCboSolutions.Enabled = true;

                ExecuteMethod(LoadSolutions, Guid.Empty);
                cdsCboSolutions.Select();

            }
            else
            {
                cdsCboSolutions.Enabled = false;


                SetCdsCboSolutionsDataSource(null);


                cdsCboSolutions.SelectedIndex = -1;
                _selectedSolution = null;

            }
        }


        private void cdsCboSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSolution = cdsCboSolutions.SelectedIndex != -1 ?
                                            new SolutionProxy(cdsCboSolutions.SelectedEntity) :
                                            null;

            ExecuteMethod(LoadCustomApis);

        }







        private void cdsCboCustomApi_SelectedIndexChanged(object sender, EventArgs e)
        {


            //Clear SElected Input / Output if needed
            SetSelectedRequestParameter(null);
            SetSelectedResponseProperty(null);


            var customapi = cdsCboCustomApi.SelectedIndex == -1 ? null : cdsCboCustomApi.SelectedEntity;
            SetSelectedCustomApi(customapi);


            //Refresh Inputs / Outputs
            LoadRequestParameters();
            LoadResponseProperties();

            menuTestApi.Enabled = cdsCboCustomApi.SelectedIndex != -1;
            menuPluginTrace.Enabled = cdsCboCustomApi.SelectedIndex != -1;

        }



        private void cdsGridInputs_RecordEnter(object sender, CRMRecordEventArgs e)
        {
            SetSelectedRequestParameter(Service.GetRequestParameter(e.Entity.Id));
        }

        private void cdsGridOutputs_RecordEnter(object sender, CRMRecordEventArgs e)
        {
            SetSelectedResponseProperty(Service.GetResponseProperty(e.Entity.Id));
        }


        #endregion

        #region Private Methods

        private void LoadSolutions(Guid selected)
        {

            SetCdsCboSolutionsDataSource(null);

            //TODO Apply filters



            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetSolutions();

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else
                    {
                        if (args.Result is EntityCollection)
                        {


                            var solutions = (EntityCollection)args.Result;
                            //Find the index of the selected solution
                            var index = solutions.Entities.Select(e => e.Id).ToList().IndexOf(selected);

                            SetCdsCboSolutionsDataSource(solutions);


                            cdsCboSolutions.SelectedIndex = index;
                            cdsCboSolutions.Enabled = true;

                        }
                    }
                }
            });

        }

        private void LoadCustomApis()
        {

            SetCdsCboCustomApiDataSource(null);



            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading customapis...",
                Work = (worker, args) =>
                {
                    if (rbAll.Checked)
                    {
                        args.Result = ConnectionDetail.UseOnline ? Service.GetAllCustomApis() : Service.GetAllCustomApisOnPrem();
                    }
                    else if (rbSolution.Checked && _selectedSolution != null)
                    {
                        args.Result = ConnectionDetail.UseOnline ? Service.GetCustomApisFor(_selectedSolution.SolutionRow.Id) : Service.GetCustomApisOnPremFor(_selectedSolution.SolutionRow.Id);
                    }
                    else
                    {
                        args.Result = null;
                    }




                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else
                    {
                        if (args.Result is EntityCollection)
                        {

                            var customapis = (EntityCollection)args.Result;
                            //Remove managed apis from list
                            if (!chkManaged.Checked) 
                            {
                                var entities = customapis.Entities.ToList();
                                entities.RemoveAll(e => e.GetAttributeValue<bool>(CustomAPI.IsManaged));

                                customapis = new EntityCollection(entities);
                            }
                            //Remove unmanaged apis from list
                            if (!chkUnmanaged.Checked)
                            {
                                var entities = customapis.Entities.ToList();
                                entities.RemoveAll(e => !e.GetAttributeValue<bool>(CustomAPI.IsManaged));

                                customapis = new EntityCollection(entities);
                            }

                            //Find the index of the selected API in the list
                            var index = customapis.Entities.Select(e => e.Id).ToList().IndexOf(_selectedCustomApi?.CustomApiRow.Id ?? Guid.Empty);

                            SetCdsCboCustomApiDataSource(customapis);

                            //hack to force a refresh... must be a better way
                            if (cdsCboCustomApi.SelectedIndex == index)
                            {
                                cdsCboCustomApi.SelectedIndex = -1;
                            }
                            cdsCboCustomApi.SelectedIndex = index;
                            cdsCboCustomApi.Enabled = true;

                        }
                        else
                        {
                            SetCdsCboCustomApiDataSource(null);

                            cdsCboCustomApi.SelectedIndex = -1;
                            cdsCboCustomApi.Enabled = false;
                        }
                    }
                }
            });

        }

        /// Will set the DataSource of the control. Disabling the event handlers will prevent unessesary triggers.
        private void SetCdsCboSolutionsDataSource(object datasource)
        {
            cdsCboSolutions.SelectedIndexChanged -= new EventHandler(cdsCboSolutions_SelectedIndexChanged);
            cdsCboSolutions.DataSource = datasource;
            cdsCboSolutions.SelectedIndexChanged += new EventHandler(cdsCboSolutions_SelectedIndexChanged);
        }


        private void SetCdsCboCustomApiDataSource(object datasource)
        {
            cdsCboCustomApi.SelectedIndexChanged -= new EventHandler(cdsCboCustomApi_SelectedIndexChanged);
            cdsCboCustomApi.DataSource = datasource;
            cdsCboCustomApi.SelectedIndexChanged += new EventHandler(cdsCboCustomApi_SelectedIndexChanged);
        }



        private void SetGridInputsDataSource(object datasource)
        {
            cdsGridInputs.RecordEnter -= new CRMRecordEventHandler(cdsGridInputs_RecordEnter);
            cdsGridInputs.DataSource = datasource;
            cdsGridInputs.RecordEnter += new CRMRecordEventHandler(cdsGridInputs_RecordEnter);
        }
        private void SetGridOutputsDataSource(object datasource)
        {
            cdsGridOutputs.RecordEnter -= new CRMRecordEventHandler(cdsGridOutputs_RecordEnter);
            cdsGridOutputs.DataSource = datasource;
            cdsGridOutputs.RecordEnter += new CRMRecordEventHandler(cdsGridOutputs_RecordEnter);
        }

        private void SetSelectedCustomApi(Entity customapi)
        {
            _selectedCustomApi = customapi != null ? new CustomApiProxy(customapi) : null;



            cdsTxtUniqueName.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtName.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtDisplayName.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtDescription.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtAllowedCustomProcessingStep.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtBindingType.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtBoundEntity.Entity = _selectedCustomApi?.CustomApiRow;

            cdsTxtPluginType.EntityReference = _selectedCustomApi?.PluginType; //todo try to move out from proxy
            cdsTxtIsFunction.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtIsWFEnabled.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtExecutePrivilegeName.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtIsPrivate.Entity = _selectedCustomApi?.CustomApiRow;

            cdsTxtIsManaged.Entity = _selectedCustomApi?.CustomApiRow;
            cdsTxtIsCustomizable.Entity = _selectedCustomApi?.CustomApiRow;

            if (_selectedCustomApi != null)
            {
                txtCustomizableWarning.Visible = !_selectedCustomApi.CanCustomize;
                btnEditCustomApi.Enabled = _selectedCustomApi.CanCustomize;
                btnDeleteApi.Enabled = _selectedCustomApi.CanCustomize;
                btnAddInput.Enabled = _selectedCustomApi.CanCustomize;
                btnAddOutput.Enabled = _selectedCustomApi.CanCustomize;

            }

            if (_selectedCustomApi?.IsPowerFxFunc == true)
            {
                var fxExpression = Service.GetFxExpression(_selectedCustomApi.FxExpressionRef.Id);
                _selectedFxExpression = new FxExpressionProxy(fxExpression);
                imgPowerFxFunction.Visible = true;
               
                
                txtFxExpression.Text = _selectedFxExpression.Expression;
                txtFxWarning.Visible = true;
                btnAddInput.Enabled = false;
                btnAddOutput.Enabled = false;
               
                btnDeleteApi.Enabled = false;
                
            }
            else 
            {
                _selectedFxExpression = null;
                imgPowerFxFunction.Visible = false;

                
                
                txtFxExpression.Text = string.Empty;
                txtFxWarning.Visible = false;
            }
            UpdateTreeContext();


            imgGrpCustomApi.Enabled = _selectedCustomApi != null;
            imgGrpInputs.Enabled = _selectedCustomApi != null;
            imgGrpOutputs.Enabled = _selectedCustomApi != null;



        }

        private void LoadRequestParameters(Guid? selected = null)
        {

            SetGridInputsDataSource(null);

            SetSelectedRequestParameter(null);

            //Get Inputs
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading customapirequestparameters...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetCustomApisRequestParametersFor(_selectedCustomApi?.CustomApiRow);

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else
                    {
                        if (args.Result is EntityCollection)
                        {
                            var requestparameters = (EntityCollection)args.Result;

                            SetGridInputsDataSource(requestparameters);


                            cdsGridInputs.ClearSelection();

                            if (cdsGridInputs.Rows.Count > 0)
                            {
                                int index = GetGridSelectedIndex(cdsGridInputs, selected);
                                cdsGridInputs.CurrentCell = cdsGridInputs.Rows[index].Cells[2];

                            }
                            else
                            {
                                SetSelectedRequestParameter(null);
                            }
                        }
                    }
                }
            });
        }




        private void SetSelectedRequestParameter(Entity requestparameter)
        {

            _selectedRequestParameter = new CustomApiRequestParameterProxy(requestparameter, ConnectionDetail.UseOnline);

            cdsTxtRequestUniqueName.Entity = _selectedRequestParameter?.RequestParameterRow;
            cdsTxtRequestName.Entity = _selectedRequestParameter?.RequestParameterRow;
            cdsTxtRequestDisplayName.Entity = _selectedRequestParameter?.RequestParameterRow;
            cdsTxtRequestDescription.Entity = _selectedRequestParameter?.RequestParameterRow;
            // cdsTxtRequestBoundEntity.Entity = _selectedRequestParameter?.RequestParameterRow;
            txtRequestBoundEntity.Text = _selectedRequestParameter?.BoundEntityLogicalName;
            cdsTxtRequestType.Entity = _selectedRequestParameter?.RequestParameterRow;
            cdsTxtRequestIsOptional.Entity = _selectedRequestParameter?.RequestParameterRow;
            cdsTxtRequestIsCustomizable.Entity = _selectedRequestParameter?.RequestParameterRow;
            cdsTxtRequestIsManaged.Entity = _selectedRequestParameter?.RequestParameterRow;


            //enable buttons
            btnEditInput.Enabled = _selectedRequestParameter?.RequestParameterRow != null
                                        && _selectedRequestParameter.CanCustomize && _selectedFxExpression == null;

            btnDeleteInput.Enabled = _selectedRequestParameter?.RequestParameterRow != null
                                        && _selectedRequestParameter.CanCustomize && _selectedFxExpression == null;

        }


        private void LoadResponseProperties(Guid? selected = null)
        {
            SetGridOutputsDataSource(null);


            SetSelectedResponseProperty(null);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading customapiresponseproperties...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetCustomApisResponsePropertiesFor(_selectedCustomApi?.CustomApiRow);

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else
                    {
                        if (args.Result is EntityCollection)
                        {
                            var responseproperties = (EntityCollection)args.Result;

                            SetGridOutputsDataSource(responseproperties);

                            cdsGridOutputs.ClearSelection();

                            if (cdsGridOutputs.Rows.Count > 0)
                            {
                                int index = GetGridSelectedIndex(cdsGridOutputs, selected);
                                cdsGridOutputs.CurrentCell = cdsGridOutputs.Rows[index].Cells[2];

                            }
                            else
                            {
                                SetSelectedResponseProperty(null);
                            }

                        }
                    }
                }
            });
        }

        private void SetSelectedResponseProperty(Entity responseproperty)
        {
            _selectedResponseProperty = new CustomApiResponsePropertyProxy(responseproperty, ConnectionDetail.UseOnline);

            cdsTxtResponseUniqueName.Entity = _selectedResponseProperty.ResponsePropertyRow;
            cdsTxtResponseName.Entity = _selectedResponseProperty.ResponsePropertyRow;
            cdsTxtResponseDisplayName.Entity = _selectedResponseProperty.ResponsePropertyRow;
            cdsTxtResponseDescription.Entity = _selectedResponseProperty.ResponsePropertyRow;
            //cdsTxtResponseBoundEntity.Entity = _selectedResponseProperty.ResponsePropertyRow;
            txtResponseBoundEntity.Text = _selectedResponseProperty?.BoundEntityLogicalName;
            cdsTxtResponseType.Entity = _selectedResponseProperty.ResponsePropertyRow;
            cdsTxtResponseIsCustomizable.Entity = _selectedResponseProperty.ResponsePropertyRow;
            cdsTxtResponseIsManaged.Entity = _selectedResponseProperty.ResponsePropertyRow;

            //enable buttons
            btnEditOutput.Enabled = _selectedResponseProperty?.ResponsePropertyRow != null
                                        && _selectedResponseProperty.CanCustomize;

            btnDeleteOutput.Enabled = _selectedResponseProperty?.ResponsePropertyRow != null
                                        && _selectedResponseProperty.CanCustomize;

        }


        /// Method to find the index of a given ID (Guid) in a CRMGridView. A bit shady but it works.
        private int GetGridSelectedIndex(CRMGridView crmgridview, Guid? selected)
        {
            var index = 0;
            if (selected != null)
            {

                foreach (DataGridViewRow row in crmgridview.Rows)
                {

                    DataRow datarow = ((DataRowView)row.DataBoundItem).Row;
                    if (datarow != null && datarow.Field<Guid>("#id") == selected)
                    {
                        index = datarow.Field<int>("#no") - 1;
                    }
                }
            }
            return index;
        }

        private void SettingsDialog()
        {
            var inputdlg = new SettingsForm(Service, ConnectionDetail, _globalsettings, _connectionsettings);
            var dlgresult = inputdlg.ShowDialog();

        }

        private void CreateApiDialog()
        {
            var inputdlg = new NewCustomApiForm(Service, _selectedSolution, _connectionsettings, ConnectionDetail);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.NewCustomApiId != null)
            {

                //refresh custom api list and select newly created
                SetSelectedCustomApi(Service.GetCustomApi(inputdlg.NewCustomApiId));
                ExecuteMethod(LoadCustomApis);
            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void UpdateApiDialog()
        {
            //todo validations = api must be selected
            var inputdlg = new UpdateCustomApiForm(Service, _selectedCustomApi, ConnectionDetail);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.CustomApiUpdated)
            {


                //refresh custom api list and select newly updated
                SetSelectedCustomApi(Service.GetCustomApi(_selectedCustomApi.CustomApiRow.Id));
                ExecuteMethod(LoadCustomApis);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void DeleteApiDialog()
        {
            //todo validations = api must be selected
            var inputdlg = new DeleteCustomApiForm(Service, _selectedCustomApi);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.CustomApiDeleted)
            {

                SetSelectedCustomApi(null);
                SetSelectedRequestParameter(null);
                SetSelectedResponseProperty(null);

                ExecuteMethod(LoadCustomApis);


            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }


        private void CreateRequestParameterDialog()
        {
            var inputdlg = new NewRequestParameterForm(Service, _selectedCustomApi, _selectedSolution, _globalsettings, ConnectionDetail);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.NewCustomApiRequestParameterId != null)
            {

                LoadRequestParameters(inputdlg.NewCustomApiRequestParameterId);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void UpdateRequestParameterDialog()
        {
            //todo validations = api must be selected
            var inputdlg = new UpdateRequestParameterForm(Service, _selectedCustomApi, _selectedRequestParameter);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.RequestParameterUpdated)
            {

                LoadRequestParameters(_selectedRequestParameter.RequestParameterRow.Id);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void DeleteRequestParameterDialog()
        {

            var inputdlg = new DeleteRequestParameterForm(Service, _selectedCustomApi, _selectedRequestParameter);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.RequestParameterDeleted)
            {

                SetSelectedRequestParameter(null);
                LoadRequestParameters();

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void DeleteResponsePropertyDialog()
        {

            var inputdlg = new DeleteResponsePropertyForm(Service, _selectedCustomApi, _selectedResponseProperty);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.ResponseParameterDeleted)
            {

                SetSelectedResponseProperty(null);
                LoadResponseProperties();

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void CreateResponsePropertyDialog()
        {
            var inputdlg = new NewResponsePropertyForm(Service, _selectedCustomApi, _selectedSolution, _globalsettings, ConnectionDetail);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.NewCustomApiResponsePropertyId != null)
            {

                //refresh custom api list and select newly created
                LoadResponseProperties(inputdlg.NewCustomApiResponsePropertyId);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }


        private void UpdateResponsePropertyDialog()
        {
            //todo validations = api must be selected
            var inputdlg = new UpdateResponsePropertyForm(Service, _selectedCustomApi, _selectedResponseProperty);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.ResponsePropertyUpdated)
            {

                //refresh custom api list and select newly updated
                LoadResponseProperties(_selectedResponseProperty.ResponsePropertyRow.Id);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void UpdateTreeContext()
        {
            treeContext.Nodes.Clear();

            if (_selectedFxExpression != null)
            {
                //var rootname = $"{_selectedFxExpression.Name} ({_selectedFxExpression.UniqueName})";

                //var rootnode = treeContext.Nodes.Add(rootname);

                //rootnode.ImageIndex = 0;
                //rootnode.SelectedImageIndex = 0;




                var tablesnode = treeContext.Nodes.Add("Tables");
                

                foreach (var table in _selectedFxExpression.ContextObject.Tables)
                {
                    var tablenode = tablesnode.Nodes.Add(table);
                    //tablenode.ImageIndex = 100;
                    //tablenode.SelectedImageIndex = 100;
                }

                tablesnode.ImageIndex = 1;
                tablesnode.SelectedImageIndex = 1;
            }
            treeContext.ExpandAll();



        }


        #endregion

        private void chkManaged_CheckedChanged(object sender, EventArgs e)
        {
            LoadCustomApis();
        }

        private void chkUnmanaged_CheckedChanged(object sender, EventArgs e)
        {
            LoadCustomApis();
        }

        
    }
}