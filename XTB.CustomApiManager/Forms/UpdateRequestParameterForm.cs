﻿using Microsoft.Xrm.Sdk;
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
    public partial class UpdateRequestParameterForm : Form
    {
        #region Private Fields

        //private Control focus;
        private IOrganizationService _service;
        private CustomApiRequestParameterProxy _requestparameterproxi;
        private bool _shouldupdate = false;

        #endregion Private Fields

        #region Public Constructors

        public UpdateRequestParameterForm(IOrganizationService service,CustomApiProxy customapi, CustomApiRequestParameterProxy requestparameter)
        {
            InitializeComponent();
            _service = service;


            cdsCustomApiName.Entity = customapi.CustomApiRow;

            _requestparameterproxi = requestparameter;

            txtUniqueName.Text = _requestparameterproxi.UniqueName;
            txtName.Text = _requestparameterproxi.Name;
            txtDisplayName.Text = _requestparameterproxi.DisplayName;     
            txtDescription.Text = _requestparameterproxi.Description;
            chkIsOptional.Checked = _requestparameterproxi.IsOptional;
            txtBoundEntityName.Text = _requestparameterproxi.BoundEntityLogicalName;
            chkIsCustomizable.Checked = _requestparameterproxi.IsCustomizable;

            cboType.DataSource = Enum.GetValues(typeof(CustomAPIRequestParameter.Type_OptionSet));
            cboType.SelectedIndex = (int)_requestparameterproxi.Type;


        }

        #endregion Public Constructors

        #region Public Properties

       
        public bool RequestParameterUpdated { get; private set; }

        #endregion Public Properties



        #region Private Event Handlers
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //todo modify for Update
                var requestparamtoupdate = RequestParameterToUpdate();
                if (_shouldupdate)
                {
                    Cursor = Cursors.WaitCursor;
                    _service.Update(requestparamtoupdate);
                    RequestParameterUpdated = true;
                    Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show($"No change detected.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    DialogResult = DialogResult.None;
                }
                
                
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



        private Entity RequestParameterToUpdate() 
        {
            var requestparam = new Entity(CustomAPIRequestParameter.EntityName, _requestparameterproxi.RequestParameterRow.Id);

            //Update only if needed
            _shouldupdate = false;
            if (_requestparameterproxi.Name != txtName.Text)
            {
                requestparam[CustomAPIRequestParameter.PrimaryName] = txtName.Text;
                _shouldupdate = true;
            };

            if (_requestparameterproxi.Description != txtDescription.Text)
            {
                requestparam[CustomAPIRequestParameter.Description] = txtDescription.Text;
                _shouldupdate = true;
            };

            if (_requestparameterproxi.DisplayName != txtDisplayName.Text)
            {
                requestparam[CustomAPIRequestParameter.DisplayName] = txtDisplayName.Text;
                _shouldupdate = true;
            };

            if (_requestparameterproxi.IsCustomizable != chkIsCustomizable.Checked)
            {
                requestparam[CustomAPIRequestParameter.IsCustomizable] = chkIsCustomizable.Checked;
                _shouldupdate = true;
            };



            return requestparam;
        }

        #endregion Private Methods

    }
}
