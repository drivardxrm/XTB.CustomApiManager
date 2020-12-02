namespace XTB.CustomApiManager
{
    partial class CustomApiManagerControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomApiManagerControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.tslAbout = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.crmGridView1 = new xrmtb.XrmToolBox.Controls.CRMGridView();
            this.btnAddExisting = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gridCustomApi = new System.Windows.Forms.DataGridView();
            this.colCustomApiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkUnmanaged = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSolution = new System.Windows.Forms.ComboBox();
            this.gridCustomApiResponseProperty = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCustomApiRequestParameter = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkIsFunction = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsPrivate = new System.Windows.Forms.CheckBox();
            this.txtUniqueName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveCustomApi = new System.Windows.Forms.Button();
            this.cboBindingType = new System.Windows.Forms.ComboBox();
            this.cboAllowedCustomProcessingStep = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboBoundEntity = new System.Windows.Forms.ComboBox();
            this.lblPlugintype = new System.Windows.Forms.Label();
            this.dlgLookupPluginType = new xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog();
            this.btnLookupPluginType = new System.Windows.Forms.Button();
            this.txtLookupPluginType = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.solutionsDropdownControl1 = new xrmtb.XrmToolBox.Controls.SolutionsDropdownControl();
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crmGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiResponseProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiRequestParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample,
            this.tslAbout});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(982, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(64, 28);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(46, 28);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // tslAbout
            // 
            this.tslAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslAbout.IsLink = true;
            this.tslAbout.Name = "tslAbout";
            this.tslAbout.Size = new System.Drawing.Size(89, 28);
            this.tslAbout.Text = "by David Rivard";
            this.tslAbout.Click += new System.EventHandler(this.tslAbout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crmGridView1);
            this.groupBox1.Controls.Add(this.btnAddExisting);
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gridCustomApi);
            this.groupBox1.Controls.Add(this.chkUnmanaged);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbSolution);
            this.groupBox1.Location = new System.Drawing.Point(3, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 601);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Api";
            // 
            // crmGridView1
            // 
            this.crmGridView1.AllowUserToOrderColumns = true;
            this.crmGridView1.AllowUserToResizeRows = false;
            this.crmGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crmGridView1.ColumnOrder = "";
            this.crmGridView1.FilterColumns = "";
            this.crmGridView1.Location = new System.Drawing.Point(10, 267);
            this.crmGridView1.Name = "crmGridView1";
            this.crmGridView1.OrganizationService = null;
            this.crmGridView1.Size = new System.Drawing.Size(240, 150);
            this.crmGridView1.TabIndex = 20;
            // 
            // btnAddExisting
            // 
            this.btnAddExisting.Location = new System.Drawing.Point(266, 93);
            this.btnAddExisting.Name = "btnAddExisting";
            this.btnAddExisting.Size = new System.Drawing.Size(75, 23);
            this.btnAddExisting.TabIndex = 19;
            this.btnAddExisting.Text = "Add Existing";
            this.btnAddExisting.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(266, 122);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 18;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Custom Apis";
            // 
            // gridCustomApi
            // 
            this.gridCustomApi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomApi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomApiName});
            this.gridCustomApi.Location = new System.Drawing.Point(10, 93);
            this.gridCustomApi.Name = "gridCustomApi";
            this.gridCustomApi.Size = new System.Drawing.Size(240, 150);
            this.gridCustomApi.TabIndex = 4;
            this.gridCustomApi.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomApi_RowEnter);
            // 
            // colCustomApiName
            // 
            this.colCustomApiName.DataPropertyName = "Name";
            this.colCustomApiName.HeaderText = "Name";
            this.colCustomApiName.Name = "colCustomApiName";
            this.colCustomApiName.Width = 250;
            // 
            // chkUnmanaged
            // 
            this.chkUnmanaged.AutoSize = true;
            this.chkUnmanaged.Location = new System.Drawing.Point(98, 11);
            this.chkUnmanaged.Name = "chkUnmanaged";
            this.chkUnmanaged.Size = new System.Drawing.Size(108, 17);
            this.chkUnmanaged.TabIndex = 2;
            this.chkUnmanaged.Text = "Unmanaged Only";
            this.chkUnmanaged.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Solution";
            // 
            // cmbSolution
            // 
            this.cmbSolution.FormattingEnabled = true;
            this.cmbSolution.Location = new System.Drawing.Point(98, 34);
            this.cmbSolution.Name = "cmbSolution";
            this.cmbSolution.Size = new System.Drawing.Size(310, 21);
            this.cmbSolution.TabIndex = 0;
            this.cmbSolution.SelectedIndexChanged += new System.EventHandler(this.cmbSolution_SelectedIndexChanged);
            // 
            // gridCustomApiResponseProperty
            // 
            this.gridCustomApiResponseProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomApiResponseProperty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.gridCustomApiResponseProperty.Location = new System.Drawing.Point(435, 496);
            this.gridCustomApiResponseProperty.Name = "gridCustomApiResponseProperty";
            this.gridCustomApiResponseProperty.Size = new System.Drawing.Size(240, 150);
            this.gridCustomApiResponseProperty.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // gridCustomApiRequestParameter
            // 
            this.gridCustomApiRequestParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomApiRequestParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.gridCustomApiRequestParameter.Location = new System.Drawing.Point(435, 340);
            this.gridCustomApiRequestParameter.Name = "gridCustomApiRequestParameter";
            this.gridCustomApiRequestParameter.Size = new System.Drawing.Size(240, 150);
            this.gridCustomApiRequestParameter.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(532, 132);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(359, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(532, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(359, 20);
            this.txtName.TabIndex = 9;
            // 
            // chkIsFunction
            // 
            this.chkIsFunction.AutoSize = true;
            this.chkIsFunction.Location = new System.Drawing.Point(532, 158);
            this.chkIsFunction.Name = "chkIsFunction";
            this.chkIsFunction.Size = new System.Drawing.Size(15, 14);
            this.chkIsFunction.TabIndex = 11;
            this.chkIsFunction.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(454, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "IsFunction";
            // 
            // chkIsPrivate
            // 
            this.chkIsPrivate.AutoSize = true;
            this.chkIsPrivate.Location = new System.Drawing.Point(532, 186);
            this.chkIsPrivate.Name = "chkIsPrivate";
            this.chkIsPrivate.Size = new System.Drawing.Size(15, 14);
            this.chkIsPrivate.TabIndex = 13;
            this.chkIsPrivate.UseVisualStyleBackColor = true;
            // 
            // txtUniqueName
            // 
            this.txtUniqueName.Location = new System.Drawing.Point(532, 54);
            this.txtUniqueName.Name = "txtUniqueName";
            this.txtUniqueName.Size = new System.Drawing.Size(359, 20);
            this.txtUniqueName.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Unique Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "IsPrivate";
            // 
            // btnSaveCustomApi
            // 
            this.btnSaveCustomApi.Location = new System.Drawing.Point(833, 354);
            this.btnSaveCustomApi.Name = "btnSaveCustomApi";
            this.btnSaveCustomApi.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCustomApi.TabIndex = 17;
            this.btnSaveCustomApi.Text = "Save";
            this.btnSaveCustomApi.UseVisualStyleBackColor = true;
            // 
            // cboBindingType
            // 
            this.cboBindingType.FormattingEnabled = true;
            this.cboBindingType.Location = new System.Drawing.Point(532, 237);
            this.cboBindingType.Name = "cboBindingType";
            this.cboBindingType.Size = new System.Drawing.Size(180, 21);
            this.cboBindingType.TabIndex = 6;
            // 
            // cboAllowedCustomProcessingStep
            // 
            this.cboAllowedCustomProcessingStep.FormattingEnabled = true;
            this.cboAllowedCustomProcessingStep.Location = new System.Drawing.Point(649, 210);
            this.cboAllowedCustomProcessingStep.Name = "cboAllowedCustomProcessingStep";
            this.cboAllowedCustomProcessingStep.Size = new System.Drawing.Size(180, 21);
            this.cboAllowedCustomProcessingStep.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Binding type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(454, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Allowed Custom Processing Step Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(454, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(532, 106);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(359, 20);
            this.txtDisplayName.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(454, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "BoundEntity";
            // 
            // cboBoundEntity
            // 
            this.cboBoundEntity.FormattingEnabled = true;
            this.cboBoundEntity.Location = new System.Drawing.Point(532, 267);
            this.cboBoundEntity.Name = "cboBoundEntity";
            this.cboBoundEntity.Size = new System.Drawing.Size(180, 21);
            this.cboBoundEntity.TabIndex = 23;
            // 
            // lblPlugintype
            // 
            this.lblPlugintype.AutoSize = true;
            this.lblPlugintype.Location = new System.Drawing.Point(454, 297);
            this.lblPlugintype.Name = "lblPlugintype";
            this.lblPlugintype.Size = new System.Drawing.Size(60, 13);
            this.lblPlugintype.TabIndex = 26;
            this.lblPlugintype.Text = "PluginType";
            // 
            // dlgLookupPluginType
            // 
            this.dlgLookupPluginType.Entity = null;
            this.dlgLookupPluginType.IncludePersonalViews = true;
            this.dlgLookupPluginType.LogicalName = "plugintype";
            this.dlgLookupPluginType.LogicalNames = new string[] {
        "plugintype"};
            this.dlgLookupPluginType.Service = null;
            this.dlgLookupPluginType.Title = "Custom Api - PluginType";
            // 
            // btnLookupPluginType
            // 
            this.btnLookupPluginType.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupPluginType.Image")));
            this.btnLookupPluginType.Location = new System.Drawing.Point(770, 293);
            this.btnLookupPluginType.Name = "btnLookupPluginType";
            this.btnLookupPluginType.Size = new System.Drawing.Size(23, 23);
            this.btnLookupPluginType.TabIndex = 34;
            this.btnLookupPluginType.UseVisualStyleBackColor = true;
            this.btnLookupPluginType.Click += new System.EventHandler(this.btnLookupPluginType_Click);
            // 
            // txtLookupPluginType
            // 
            this.txtLookupPluginType.BackColor = System.Drawing.SystemColors.Window;
            this.txtLookupPluginType.Clickable = true;
            this.txtLookupPluginType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtLookupPluginType.DisplayFormat = "";
            this.txtLookupPluginType.Entity = null;
            this.txtLookupPluginType.EntityReference = null;
            this.txtLookupPluginType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.txtLookupPluginType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtLookupPluginType.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtLookupPluginType.Location = new System.Drawing.Point(532, 294);
            this.txtLookupPluginType.LogicalName = "plugintype";
            this.txtLookupPluginType.Name = "txtLookupPluginType";
            this.txtLookupPluginType.OrganizationService = null;
            this.txtLookupPluginType.Size = new System.Drawing.Size(232, 20);
            this.txtLookupPluginType.TabIndex = 36;
            // 
            // solutionsDropdownControl1
            // 
            this.solutionsDropdownControl1.AutoLoadData = false;
            this.solutionsDropdownControl1.LanguageCode = 1033;
            this.solutionsDropdownControl1.Location = new System.Drawing.Point(72, 665);
            this.solutionsDropdownControl1.Margin = new System.Windows.Forms.Padding(1);
            this.solutionsDropdownControl1.Name = "solutionsDropdownControl1";
            this.solutionsDropdownControl1.PublisherPrefixes = ((System.Collections.Generic.List<string>)(resources.GetObject("solutionsDropdownControl1.PublisherPrefixes")));
            this.solutionsDropdownControl1.Service = null;
            this.solutionsDropdownControl1.Size = new System.Drawing.Size(416, 25);
            this.solutionsDropdownControl1.TabIndex = 37;
            this.solutionsDropdownControl1.SelectedItemChanged += new System.EventHandler(this.solutionsDropdownControl1_SelectedItemChanged);
            // 
            // CustomApiManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.solutionsDropdownControl1);
            this.Controls.Add(this.txtLookupPluginType);
            this.Controls.Add(this.btnLookupPluginType);
            this.Controls.Add(this.lblPlugintype);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboBoundEntity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboAllowedCustomProcessingStep);
            this.Controls.Add(this.cboBindingType);
            this.Controls.Add(this.btnSaveCustomApi);
            this.Controls.Add(this.gridCustomApiResponseProperty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gridCustomApiRequestParameter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUniqueName);
            this.Controls.Add(this.chkIsPrivate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkIsFunction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "CustomApiManagerControl";
            this.Size = new System.Drawing.Size(982, 703);
            this.Load += new System.EventHandler(this.CustomApiManagerControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crmGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiResponseProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiRequestParameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripLabel tslAbout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkUnmanaged;
        private System.Windows.Forms.DataGridView gridCustomApi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomApiName;
        private System.Windows.Forms.DataGridView gridCustomApiResponseProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView gridCustomApiRequestParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkIsFunction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsPrivate;
        private System.Windows.Forms.TextBox txtUniqueName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveCustomApi;
        private System.Windows.Forms.ComboBox cboBindingType;
        private System.Windows.Forms.ComboBox cboAllowedCustomProcessingStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Button btnAddExisting;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboBoundEntity;
        private System.Windows.Forms.Label lblPlugintype;
        private xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog dlgLookupPluginType;
        private System.Windows.Forms.Button btnLookupPluginType;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtLookupPluginType;
        private xrmtb.XrmToolBox.Controls.SolutionsDropdownControl solutionsDropdownControl1;
        private xrmtb.XrmToolBox.Controls.CRMGridView crmGridView1;
    }
}
