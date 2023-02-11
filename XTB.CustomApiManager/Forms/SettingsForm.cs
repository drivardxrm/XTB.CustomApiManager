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

namespace XTB.CustomApiManager.Forms
{
    public partial class SettingsForm : Form
    {
        #region Private Fields

        //private Control focus;
        private IOrganizationService _service;
        private SolutionProxy _selectedSolution;
        private Settings _globalsettings;
        private Settings _connectionsettings;
        private ConnectionDetail _connectiondetail;

        #endregion Private Fields

        #region Public Constructors

        public SettingsForm(IOrganizationService service,ConnectionDetail connectiondetail,  Settings globalsettings, Settings connectionsettings)
        {
            InitializeComponent();
            _service = service;
            _globalsettings = globalsettings;
            _connectionsettings = connectionsettings;
            _connectiondetail = connectiondetail;
            dlgLookupPublisher.Service = service;

            lblConnection.Text = _connectiondetail.ConnectionName;


            txtRequestParameterTemplate.Text = _globalsettings.RequestParameterDefaultName;
            txtResponsePropertyTemplate.Text = _globalsettings.ResponsePropertyDefaultName;

            if (_connectionsettings.DefaultPublisherId != Guid.Empty) 
            {
                var publisher  = _service.GetPublisher(_connectionsettings.DefaultPublisherId);

                if (publisher != null)
                {
                    txtLookupPublisher.EntityReference = new EntityReference(Publisher.EntityName, _connectionsettings.DefaultPublisherId);
                    txtLookupPublisher.Text = publisher.Attributes[Publisher.PrimaryName].ToString();
                    txtPrefix.Text = $"{publisher.Attributes[Publisher.Prefix]}_";
                }
                else 
                {
                    txtLookupPublisher.EntityReference = new EntityReference(Publisher.EntityName, Guid.Empty);
                    txtLookupPublisher.Text = string.Empty;
                    txtPrefix.Text = string.Empty;
                }
                
            }

        }

        #endregion Public Constructors

       




        #region Private Event Handlers
        


        #endregion Private Event Handlers

        #region Private Methods



        #endregion Private Methods

        
        private bool SaveButtonEnabled()
        {
            return true; //todo
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Global
            if(txtRequestParameterTemplate.Text != _globalsettings.RequestParameterDefaultName) 
            {
                _globalsettings.RequestParameterDefaultName = txtRequestParameterTemplate.Text;
            }
            if (txtResponsePropertyTemplate.Text != _globalsettings.ResponsePropertyDefaultName)
            {
                _globalsettings.ResponsePropertyDefaultName = txtResponsePropertyTemplate.Text;
            }
            SettingsManager.Instance.Save(typeof(CustomApiManagerPlugin), _globalsettings);

            // connection related settings
            if (txtLookupPublisher.Id != _connectionsettings.DefaultPublisherId) 
            {
                _connectionsettings.DefaultPublisherId = txtLookupPublisher.Id;
            }
            SettingsManager.Instance.Save(typeof(CustomApiManagerPlugin), _connectionsettings, _connectiondetail.ConnectionId.ToString());

        }

        private void btnLookupPublisher_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (dlgLookupPublisher.ShowDialog(this))
            {
                case DialogResult.OK:
                    txtLookupPublisher.Entity = dlgLookupPublisher.Entity;
                    var prefix = _service.GetPublisherPrefix((Guid)dlgLookupPublisher.Entity.Attributes[Publisher.PrimaryKey]);
                    txtPrefix.Text = $"{prefix}_";

                    //unlock

                    break;
                case DialogResult.Abort:

                    break;
            }

            Cursor = Cursors.Default;
        }

        private void btnPublisherClear_Click(object sender, EventArgs e)
        {
            txtLookupPublisher.EntityReference = new EntityReference(Publisher.EntityName, Guid.Empty);
            txtLookupPublisher.Text = string.Empty;
            txtPrefix.Text = string.Empty;
        }

        
    }
}
