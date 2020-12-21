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
using static XTB.CustomApiManager.Entities.CustomAPI;
using xrmtb.XrmToolBox.Controls.Controls;
using xrmtb.XrmToolBox.Controls;

namespace XTB.CustomApiManager
{
    public partial class CustomApiManagerControl : PluginControlBase
    {
        private Settings mySettings;


        public CustomApiManagerControl()
        {
            InitializeComponent();
        }

        private void CustomApiManagerControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("Disclaimer : Dataverse Custom APIs are still considered a preview feature.", new Uri("https://docs.microsoft.com/en-us/powerapps/developer/common-data-service/custom-api"));

            //cboBindingType.DataSource = Enum.GetValues(typeof(BindingType_OptionSet));
            //cboBindingType.SelectedIndex = -1;
            //cboAllowedCustomProcessingStep.DataSource = Enum.GetValues(typeof(AllowedCustomProcessingStepType_OptionSet));
            //cboAllowedCustomProcessingStep.SelectedIndex = -1;


            

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

            //LoadSolutions();
            Initialize();
        }

        private void Initialize()
        {
            solutionsDropdownControl1.Service = Service;
            solutionsDropdownControl1.LoadData();

            dlgLookupPluginType.Service = Service;
            dlgLookupPublisher.Service = Service;

            cdsCboCustomApi.OrganizationService = Service;
            cdsTxtPluginType.OrganizationService = Service;
            cdsTxtUniqueName.OrganizationService = Service;
            
            cdsTxtName.OrganizationService = Service;
            cdsTxtDisplayName.OrganizationService = Service;
            cdsTxtDescription.OrganizationService = Service;
            cdsTxtAllowedCustomProcessingStep.OrganizationService = Service;
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


            LoadCustomApis();
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
                Initialize();
            }
        }


        


        private void LoadCustomApis()
        {
            cdsCboCustomApi.DataSource = null;

            
            //TODO Apply filters

            

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions customapis...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetAllCustomApis();

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
                           
                            UpdateUI(() =>
                            {
                                cdsCboCustomApi.DataSource = customapis;
                                cdsCboCustomApi.SelectedIndex = -1;
                                cdsCboCustomApi.Enabled = true;
                            });
                        }
                    }
                }
            });

        }

        

        

        



        

        private void tslAbout_Click(object sender, EventArgs e)
        {
            //LogUse("OpenAbout");
            var about = new About(this);
            about.StartPosition = FormStartPosition.CenterParent;
            about.lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            about.ShowDialog();
        }

       

        internal void UpdateUI(Action action)
        {
            MethodInvoker mi = delegate
            {
                action();
            };
            if (InvokeRequired)
            {
                Invoke(mi);
            }
            else
            {
                mi();
            }
        }

        

       

        private void solutionsDropdownControl1_SelectedItemChanged(object sender, EventArgs e)
        {
            var selected = solutionsDropdownControl1.SelectedSolution;
        }

        private void menuNewCustomApi_Click(object sender, EventArgs e)
        {
            

        }

        private void cdsCboCustomApi_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cdsCboCustomApi.SelectedEntity != null)
            {
                var customapiref = cdsCboCustomApi.SelectedEntity.ToEntityReference();
                var customapiproxy = new CustomApiProxy(cdsCboCustomApi.SelectedEntity);


                cdsTxtUniqueName.EntityReference = customapiref;
                cdsTxtName.EntityReference = customapiref;
                cdsTxtDisplayName.EntityReference = customapiref;
                cdsTxtDescription.EntityReference = customapiref;
                cdsTxtAllowedCustomProcessingStep.EntityReference = customapiref;
                cdsTxtBindingType.EntityReference = customapiref;
                cdsTxtBoundEntity.EntityReference = customapiref;

                cdsTxtPluginType.EntityReference = customapiproxy.PluginType;
                cdsTxtIsFunction.EntityReference = customapiref;
                cdsTxtExecutePrivilegeName.EntityReference = customapiref;
                cdsTxtIsPrivate.EntityReference = customapiref;


                //Get Inputs
                cdsGridInputs.DataSource = Service.GetCustomApisRequestParametersFor(customapiref.Id);

                cdsGridOutputs.DataSource = Service.GetCustomApisResponsePropertiesFor(customapiref.Id);

            }
            else 
            {
                cdsTxtUniqueName.EntityReference = null;
                cdsTxtName.EntityReference = null;
                cdsTxtDisplayName.EntityReference = null;
                cdsTxtDescription.EntityReference = null;
                cdsTxtAllowedCustomProcessingStep.EntityReference = null;
                cdsTxtBindingType.EntityReference = null;
                cdsTxtBoundEntity.EntityReference = null;

                cdsTxtPluginType.EntityReference = null;
                cdsTxtIsFunction.EntityReference = null;
                cdsTxtExecutePrivilegeName.EntityReference = null;
                cdsTxtIsPrivate.EntityReference = null;


                //Get Inputs
                cdsGridInputs.DataSource = null;

                cdsGridOutputs.DataSource = null;
            }
            
        }

        private void cdsGridInputs_RecordClick(object sender, CRMRecordEventArgs e)
        {

            cdsTxtRequestUniqueName.EntityReference = e.Entity.ToEntityReference();
            cdsTxtRequestName.EntityReference = e.Entity.ToEntityReference();
            cdsTxtRequestDisplayName.EntityReference = e.Entity.ToEntityReference();
            cdsTxtRequestDescription.EntityReference = e.Entity.ToEntityReference();
            cdsTxtRequestBoundEntity.EntityReference = e.Entity.ToEntityReference();
            cdsTxtRequestType.EntityReference = e.Entity.ToEntityReference();
            cdsTxtRequestIsOptional.EntityReference = e.Entity.ToEntityReference();


        }

        private void cdsGridOutputs_RecordClick(object sender, CRMRecordEventArgs e)
        {
            cdsTxtResponseUniqueName.EntityReference = e.Entity.ToEntityReference();
            cdsTxtResponseName.EntityReference = e.Entity.ToEntityReference();
            cdsTxtResponseDisplayName.EntityReference = e.Entity.ToEntityReference();
            cdsTxtResponseDescription.EntityReference = e.Entity.ToEntityReference();
            cdsTxtResponseBoundEntity.EntityReference = e.Entity.ToEntityReference();
            cdsTxtResponseType.EntityReference = e.Entity.ToEntityReference();
            
        }

        private void btnNewApi_Click(object sender, EventArgs e)
        {
            CreateApiDialog();
        }

        private void CreateApiDialog() 
        {
            var inputdlg = new CustomApiEditor(Service, null, FormAction.Create);
            var dlgresult = inputdlg.ShowDialog();
            if (dlgresult == DialogResult.Cancel)
            {
                return;
            }
            if (dlgresult == DialogResult.OK && inputdlg.Result != null)
            {
                //e.Entity["rawvalue"] = inputdlg.Result;
                //e.Entity["value"] = inputdlg.FormattedResult;

                //refresh custom api list
                LoadCustomApis();

                //SElect newly created
                cdsCboCustomApi.SelectedItem = new Entity(CustomAPI.EntityName, inputdlg.Result);


            }
            else if (dlgresult == DialogResult.Ignore)
            {
                //e.Entity.Attributes.Remove("value");
                //e.Entity.Attributes.Remove("rawvalue");
            }
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomApis();
        }
    }
}