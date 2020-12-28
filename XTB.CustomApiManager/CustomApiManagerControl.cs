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

namespace XTB.CustomApiManager
{
    public partial class CustomApiManagerControl : PluginControlBase, IMessageBusHost, IGitHubPlugin
    {
        private Settings mySettings;

        private Guid _inArgument;

        private Entity _selectedSolution;

        private Entity _selectedCustomApi;

        private Entity _selectedRequestParameter;

        private Entity _selectedResponseProperty;

        private Entity _selectedPublisher;

        public string RepositoryName => "XTB.CustomApiManager";

        public string UserName => "drivardxrm";

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        public CustomApiManagerControl()
        {
            InitializeComponent();
        }

        private void CustomApiManagerControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("Disclaimer : Dataverse Custom APIs are still considered a preview feature.", new Uri("https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/custom-api"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }

            ExecuteMethod(InitializeService);

            //select the all radio button
            rbAll.Checked = true;
            cdsCboCustomApi.Select();
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
            cdsTxtIsPrivate.OrganizationService = Service;

            //input params
            cdsGridInputs.OrganizationService = Service;
            cdsTxtRequestUniqueName.OrganizationService = Service;
            cdsTxtRequestName.OrganizationService = Service;
            cdsTxtRequestDisplayName.OrganizationService = Service;
            cdsTxtRequestDescription.OrganizationService = Service;
            cdsTxtRequestIsOptional.OrganizationService = Service;
            cdsTxtRequestBoundEntity.OrganizationService = Service;
            cdsTxtRequestType.OrganizationService = Service;

            //output props
            cdsGridOutputs.OrganizationService = Service;
            cdsTxtResponseUniqueName.OrganizationService = Service;
            cdsTxtResponseName.OrganizationService = Service;
            cdsTxtResponseDisplayName.OrganizationService = Service;
            cdsTxtResponseDescription.OrganizationService = Service;
            cdsTxtResponseBoundEntity.OrganizationService = Service;
            cdsTxtResponseType.OrganizationService = Service;


        }

        //If Plugin is opened from Integration with another plugin
        //TargetArgumet = GUID of Custom API to display (string format)	Id
        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            
            if (message.TargetArgument is string arg && Guid.TryParse(arg, out Guid argid))
            {
                _inArgument = argid;
                if (cdsCboCustomApi.DataSource != null) 
                {
                    var type = cdsCboCustomApi.DataSource.GetType();


                    var index = ((DataCollection<Entity>)cdsCboCustomApi.DataSource).Select(e => e.Id).ToList().IndexOf(argid);

                    cdsCboCustomApi.SelectedIndex = index;
                    cdsCboCustomApi.Enabled = true;
                }
                

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
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);

                

                //LoadSolutions();
                ExecuteMethod(InitializeService);
                

                //select the all radio button
                rbAll.Checked = true;
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
                OnOutgoingMessage(this, new MessageBusEventArgs("Custom API Tester") { TargetArgument = _selectedCustomApi.Id.ToString() });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

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
            //LogUse("OpenAbout");
            var about = new About(this);
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
                _selectedPublisher = null;
            }
        }


        private void cdsCboSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedSolution = cdsCboSolutions.SelectedIndex != -1 ?
                                            cdsCboSolutions.SelectedEntity :
                                            null;

            _selectedPublisher = cdsCboSolutions.SelectedIndex != -1 ?
                                            Service.GetPublisher(((EntityReference)_selectedSolution.Attributes[Solution.Publisher]).Id)
                                            : null;


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
                        args.Result = Service.GetAllCustomApis();
                    }
                    else if (rbSolution.Checked && _selectedSolution != null) 
                    {
                        args.Result = Service.GetCustomApisFor(_selectedSolution.Id);
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
                            //Find the index of the selected API in the list
                            var index = customapis.Entities.Select(e => e.Id).ToList().IndexOf(_selectedCustomApi?.Id ?? Guid.Empty);

                            SetCdsCboCustomApiDataSource(customapis);

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
            _selectedCustomApi = customapi;

            var customapiproxy = _selectedCustomApi != null ? new CustomApiProxy(_selectedCustomApi) : null;

            cdsTxtUniqueName.Entity = _selectedCustomApi;
            cdsTxtName.Entity = _selectedCustomApi;
            cdsTxtDisplayName.Entity = _selectedCustomApi;
            cdsTxtDescription.Entity = _selectedCustomApi;
            cdsTxtAllowedCustomProcessingStep.Entity = _selectedCustomApi;
            cdsTxtBindingType.Entity = _selectedCustomApi;
            cdsTxtBoundEntity.Entity = _selectedCustomApi;

            cdsTxtPluginType.EntityReference = customapiproxy?.PluginType; //todo try to move out from proxy
            cdsTxtIsFunction.Entity = _selectedCustomApi;
            cdsTxtExecutePrivilegeName.Entity = _selectedCustomApi;
            cdsTxtIsPrivate.Entity = _selectedCustomApi;


            
            grpCustomApi.Enabled = _selectedCustomApi != null;
            grpInputs.Enabled = _selectedCustomApi != null;
            grpOutputs.Enabled = _selectedCustomApi != null;


          
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
                    args.Result = Service.GetCustomApisRequestParametersFor(_selectedCustomApi);

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

            _selectedRequestParameter = requestparameter;

            cdsTxtRequestUniqueName.Entity = _selectedRequestParameter;
            cdsTxtRequestName.Entity = _selectedRequestParameter;
            cdsTxtRequestDisplayName.Entity = _selectedRequestParameter;
            cdsTxtRequestDescription.Entity = _selectedRequestParameter;
            cdsTxtRequestBoundEntity.Entity = _selectedRequestParameter;
            cdsTxtRequestType.Entity = _selectedRequestParameter;
            cdsTxtRequestIsOptional.Entity = _selectedRequestParameter;


            //enable buttons
            btnEditInput.Enabled = _selectedRequestParameter != null;
            btnDeleteInput.Enabled = _selectedRequestParameter != null;

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
                    args.Result = Service.GetCustomApisResponsePropertiesFor(_selectedCustomApi);

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
            _selectedResponseProperty = responseproperty;
            
            cdsTxtResponseUniqueName.Entity = _selectedResponseProperty;
            cdsTxtResponseName.Entity = _selectedResponseProperty;
            cdsTxtResponseDisplayName.Entity = _selectedResponseProperty;
            cdsTxtResponseDescription.Entity = _selectedResponseProperty;
            cdsTxtResponseBoundEntity.Entity = _selectedResponseProperty;
            cdsTxtResponseType.Entity = _selectedResponseProperty;

            //enable buttons
            btnEditOutput.Enabled = _selectedResponseProperty != null;
            btnDeleteOutput.Enabled = _selectedResponseProperty != null;

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


        private void CreateApiDialog() 
        {
            var inputdlg = new NewCustomApiForm(Service, _selectedPublisher);
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
            var inputdlg = new UpdateCustomApiForm(Service, _selectedCustomApi);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.CustomApiUpdated)
            {


                //refresh custom api list and select newly updated
                SetSelectedCustomApi(Service.GetCustomApi(_selectedCustomApi.Id));
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
            var inputdlg = new NewRequestParameterForm(Service, _selectedCustomApi);
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


                //refresh custom api list and refresh form
                LoadRequestParameters(_selectedRequestParameter.Id);

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
            var inputdlg = new NewResponsePropertyForm(Service, _selectedCustomApi);
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
                LoadResponseProperties(_selectedResponseProperty.Id);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }















        #endregion

        

        
    }
}