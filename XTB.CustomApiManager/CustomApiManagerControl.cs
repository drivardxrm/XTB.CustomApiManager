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

namespace XTB.CustomApiManager
{
    public partial class CustomApiManagerControl : PluginControlBase
    {
        private Settings mySettings;
        private Entity SelectedSolution { get; set; } = null;

        private Entity SelectedCustomApi { get; set; } = null;

        private Entity SelectedRequestParameter { get; set; } = null;

        private Entity SelectedResponseProperty { get; set; } = null;

        private Entity SelectedPublisher { get; set; } = null;

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
        private void menuNewCustomApi_Click(object sender, EventArgs e)
        {
            CreateApiDialog();

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
                cdsCboCustomApi.SelectedIndex = -1;
                ExecuteMethod(LoadCustomApis);
            }
        }

        private void rbSolution_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSolution.Checked)
            {
                cdsCboCustomApi.DataSource = null;
                cdsCboCustomApi.SelectedIndex = -1;

                cdsCboSolutions.Enabled = true;

                ExecuteMethod(LoadSolutions, Guid.Empty);
                cdsCboSolutions.Select();

            }
            else
            {
                cdsCboSolutions.Enabled = false;
                cdsCboSolutions.DataSource = null;
                
                cdsCboSolutions.Text = null;
            }
        }


        private void cdsCboSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSolution = cdsCboSolutions.SelectedIndex != -1 ?
                                            cdsCboSolutions.SelectedEntity :
                                            null;

            SelectedPublisher = cdsCboSolutions.SelectedIndex != -1 ?
                                            Service.GetPublisher(((EntityReference)SelectedSolution.Attributes[Solution.Publisher]).Id)  
                                            : null; 

        }




        private void cdsCboCustomApi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear SElected Input / Output if needed
            SelectedRequestParameter = null;
            SelectedResponseProperty = null;
            ExecuteMethod(SetRequestParameter);
            ExecuteMethod(SetResponseProperty);


            if (cdsCboCustomApi.SelectedIndex != -1)
            {
                SelectedCustomApi = cdsCboCustomApi.SelectedEntity;
                ExecuteMethod(SetCustomApi);

                
            }
            else 
            {
                SelectedCustomApi = null;
                ExecuteMethod(SetCustomApi);
            }


            
        }

        

        private void cdsGridInputs_RecordEnter(object sender, CRMRecordEventArgs e)
        {
            SelectedRequestParameter = Service.GetRequestParameter(e.Entity.Id);
            ExecuteMethod(SetRequestParameter);
        }

        private void cdsGridOutputs_RecordEnter(object sender, CRMRecordEventArgs e)
        {
            SelectedResponseProperty = Service.GetResponseProperty(e.Entity.Id);
            ExecuteMethod(SetResponseProperty);
        }


        #endregion

        #region Private Methods

        private void LoadSolutions(Guid selected)
        {
            cdsCboSolutions.DataSource = null;


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


                            cdsCboSolutions.DataSource = solutions;
                            cdsCboSolutions.SelectedIndex = index;
                            cdsCboSolutions.Enabled = true;

                        }
                    }
                }
            });

        }

        private void LoadCustomApis()
        {
            cdsCboCustomApi.DataSource = null;


            //TODO Apply filters



            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading customapis...",
                Work = (worker, args) =>
                {
                    if (rbAll.Checked)
                    {
                        args.Result = Service.GetAllCustomApis();
                    }
                    else if (rbSolution.Checked && SelectedSolution != null) 
                    {
                        args.Result = Service.GetCustomApisFor(SelectedSolution.Id);
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
                            var index = customapis.Entities.Select(e => e.Id).ToList().IndexOf(SelectedCustomApi?.Id ?? Guid.Empty);


                            cdsCboCustomApi.DataSource = customapis;
                            cdsCboCustomApi.SelectedIndex = index;
                            cdsCboCustomApi.Enabled = true;

                        }
                        else 
                        {
                            cdsCboCustomApi.DataSource = null;
                            cdsCboCustomApi.SelectedIndex = -1;
                            cdsCboCustomApi.Enabled = false;
                        }
                    }
                }
            });

        }

        private void SetCustomApi() 
        {

            var customapiproxy = SelectedCustomApi != null ? new CustomApiProxy(SelectedCustomApi) : null;

            cdsTxtUniqueName.Entity = SelectedCustomApi;
            cdsTxtName.Entity = SelectedCustomApi;
            cdsTxtDisplayName.Entity = SelectedCustomApi;
            cdsTxtDescription.Entity = SelectedCustomApi;
            cdsTxtAllowedCustomProcessingStep.Entity = SelectedCustomApi;
            cdsTxtBindingType.Entity = SelectedCustomApi;
            cdsTxtBoundEntity.Entity = SelectedCustomApi;

            cdsTxtPluginType.EntityReference = customapiproxy?.PluginType; //todo try to move out from proxy
            cdsTxtIsFunction.Entity = SelectedCustomApi;
            cdsTxtExecutePrivilegeName.Entity = SelectedCustomApi;
            cdsTxtIsPrivate.Entity = SelectedCustomApi;


            grpInputs.Enabled = SelectedCustomApi != null;
            grpOutputs.Enabled = SelectedCustomApi != null;


            LoadRequestParameters();
            LoadResponseProperties();


            
           
        }

        private void LoadRequestParameters(Guid? selected = null) 
        {
            //Get Inputs
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading customapirequestparameters...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetCustomApisRequestParametersFor(SelectedCustomApi);

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
                            cdsGridInputs.DataSource = requestparameters;
                            cdsGridInputs.ClearSelection();

                            if (cdsGridInputs.Rows.Count > 0)
                            {
                                int index = GetGridSelectedIndex(cdsGridInputs, selected);
                                cdsGridInputs.CurrentCell = cdsGridInputs.Rows[index].Cells[2];

                            }
                        }
                    }
                }
            });
        }


        

        private void SetRequestParameter() 
        {

            
            cdsTxtRequestUniqueName.Entity = SelectedRequestParameter;
            cdsTxtRequestName.Entity = SelectedRequestParameter;
            cdsTxtRequestDisplayName.Entity = SelectedRequestParameter;
            cdsTxtRequestDescription.Entity = SelectedRequestParameter;
            cdsTxtRequestBoundEntity.Entity = SelectedRequestParameter;
            cdsTxtRequestType.Entity = SelectedRequestParameter;
            cdsTxtRequestIsOptional.Entity = SelectedRequestParameter;


            //enable buttons
            btnEditInput.Enabled = SelectedRequestParameter != null;
            btnDeleteInput.Enabled = SelectedRequestParameter != null;

        }


        private void LoadResponseProperties(Guid? selected = null)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading customapiresponseproperties...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetCustomApisResponsePropertiesFor(SelectedCustomApi);

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
                            cdsGridOutputs.DataSource = responseproperties;
                            cdsGridOutputs.ClearSelection();

                            if (cdsGridOutputs.Rows.Count > 0)
                            {
                                int index = GetGridSelectedIndex(cdsGridOutputs, selected);
                                cdsGridOutputs.CurrentCell = cdsGridOutputs.Rows[index].Cells[2];

                            }

                        }
                    }
                }
            });
        }

        private void SetResponseProperty()
        {

            cdsTxtResponseUniqueName.Entity = SelectedResponseProperty;
            cdsTxtResponseName.Entity = SelectedResponseProperty;
            cdsTxtResponseDisplayName.Entity = SelectedResponseProperty;
            cdsTxtResponseDescription.Entity = SelectedResponseProperty;
            cdsTxtResponseBoundEntity.Entity = SelectedResponseProperty;
            cdsTxtResponseType.Entity = SelectedResponseProperty;

            //enable buttons
            btnEditOutput.Enabled = SelectedResponseProperty != null;
            btnDeleteOutput.Enabled = SelectedResponseProperty != null;

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
            var inputdlg = new NewCustomApiForm(Service, SelectedPublisher);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.NewCustomApiId != null)
            {

                //refresh custom api list and select newly created
                SelectedCustomApi = Service.GetCustomApi(inputdlg.NewCustomApiId);
                ExecuteMethod(LoadCustomApis);
            }
            else if (dlgresult == DialogResult.Ignore)
            {
                
            }
        }

        private void UpdateApiDialog()
        {
            //todo validations = api must be selected
            var inputdlg = new UpdateCustomApiForm(Service, SelectedCustomApi);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.CustomApiUpdated)
            {


                //refresh custom api list and select newly updated
                SelectedCustomApi = Service.Retrieve(CustomAPI.EntityName, SelectedCustomApi.Id, new ColumnSet() { AllColumns = true });
                ExecuteMethod(LoadCustomApis);

            }
            else if (dlgresult == DialogResult.Ignore)
            {
                
            }
        }

        private void DeleteApiDialog()
        {
            //todo validations = api must be selected
            var inputdlg = new DeleteCustomApiForm(Service, SelectedCustomApi);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.CustomApiDeleted)
            {


                //refresh custom api list and select newly updated
                
                SelectedCustomApi = null;
                ExecuteMethod(LoadCustomApis);

                //Clear SElected Input / Output if needed
                SelectedRequestParameter = null;
                SelectedResponseProperty = null;
                ExecuteMethod(SetRequestParameter);
                ExecuteMethod(SetResponseProperty);


            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }


        private void CreateRequestParameterDialog()
        {
            var inputdlg = new NewRequestParameterForm(Service, SelectedCustomApi);
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
            var inputdlg = new UpdateRequestParameterForm(Service, SelectedCustomApi, SelectedRequestParameter);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.RequestParameterUpdated)
            {


                //refresh custom api list and refresh form
                LoadRequestParameters(SelectedRequestParameter.Id);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void DeleteRequestParameterDialog()
        {

            var inputdlg = new DeleteRequestParameterForm(Service, SelectedCustomApi, SelectedRequestParameter);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.RequestParameterDeleted)
            {

                SelectedRequestParameter = null;
                SetRequestParameter();
                LoadRequestParameters();

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void DeleteResponsePropertyDialog()
        {

            var inputdlg = new DeleteResponsePropertyForm(Service, SelectedCustomApi, SelectedResponseProperty);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.ResponseParameterDeleted)
            {

                SelectedResponseProperty = null;
                SetResponseProperty();
                LoadResponseProperties();

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }

        private void CreateResponsePropertyDialog()
        {
            var inputdlg = new NewResponsePropertyForm(Service, SelectedCustomApi);
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
            var inputdlg = new UpdateResponsePropertyForm(Service, SelectedCustomApi, SelectedResponseProperty);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.ResponsePropertyUpdated)
            {

                //refresh custom api list and select newly updated
                LoadResponseProperties(SelectedResponseProperty.Id);

            }
            else if (dlgresult == DialogResult.Ignore)
            {

            }
        }










        #endregion

        
    }
}