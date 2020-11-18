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

            LoadSolutions();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            //ExecuteMethod(GetCustomApis);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (args.Result is EntityCollection result)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        //private void GetCustomApis()
        //{
        //    WorkAsync(new WorkAsyncInfo
        //    {
        //        Message = "Getting Custom Apis",
        //        Work = (worker, args) =>
        //        {
        //             args.Result = Service.GetCustomApis();
                    
        //        },
        //        PostWorkCallBack = (args) =>
        //        {
        //            if (args.Error != null)
        //            {
        //                MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //            if (args.Result is EntityCollection result)
        //            {
        //                MessageBox.Show($"Found {result.Entities.Count} custom apis");
        //            }
        //        }
        //    });
        //}


        private void CreateCustomApi()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Creating Custom Api",
                Work = (worker, args) =>
                {
                    args.Result = Service.CreateCustomApi();

                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (args.Result is Guid result)
                    {
                        MessageBox.Show($"Created custom api : {result}");
                    }
                }
            });
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

                LoadSolutions();
            }
        }

        private void LoadSolutions()
        {
            cmbSolution.Items.Clear();
            cmbSolution.Enabled = false;
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
                            var proxiedsolutions = solutions.Entities.Select(s => new SolutionProxy(s)).OrderBy(s => s.ToString());
                            cmbSolution.Items.AddRange(proxiedsolutions.ToArray());
                            cmbSolution.Enabled = true;
                        }
                    }
                }
            });
                
        }

        private void LoadSolutionCustomApis()
        {
            gridCustomApi.DataSource = null;
            var solution = cmbSolution.SelectedItem as SolutionProxy;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions customapis...",
                Work = (worker, args) =>
                {
                    args.Result = Service.GetCustomApisFor(solution.SolutionRow.Id);

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
                            var proxiedcustomapis = customapis.Entities.Select(c => new CustomApiProxy(c)).OrderBy(s => s.UniqueName).ToList();
                            var bindingList = new BindingList<CustomApiProxy>(proxiedcustomapis);
                            var source = new BindingSource(bindingList, null);
                            UpdateUI(() =>
                            {
                                gridCustomApi.DataSource = source;
                                gridCustomApi.Enabled = true;
                                gridCustomApi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteMethod(CreateCustomApi);
        }

        private void cmbSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSolutionCustomApis();
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

        
    }
}