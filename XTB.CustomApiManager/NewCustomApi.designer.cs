namespace XTB.CustomApiManager
{
    partial class NewCustomApi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCustomApi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboEntities = new xrmtb.XrmToolBox.Controls.EntitiesDropdownControl();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.txtLookupPublisher = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.btnLookupPublisher = new System.Windows.Forms.Button();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtLookupPluginType = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.btnLookupPluginType = new System.Windows.Forms.Button();
            this.lblPlugintype = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboAllowedCustomProcessingStep = new System.Windows.Forms.ComboBox();
            this.cboBindingType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUniqueName = new System.Windows.Forms.TextBox();
            this.chkIsPrivate = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsFunction = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dlgLookupPublisher = new xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog();
            this.dlgLookupPluginType = new xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(40, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 31);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(413, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(332, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboEntities);
            this.panel2.Controls.Add(this.txtPrefix);
            this.panel2.Controls.Add(this.txtLookupPublisher);
            this.panel2.Controls.Add(this.btnLookupPublisher);
            this.panel2.Controls.Add(this.lblPublisher);
            this.panel2.Controls.Add(this.txtLookupPluginType);
            this.panel2.Controls.Add(this.btnLookupPluginType);
            this.panel2.Controls.Add(this.lblPlugintype);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtDisplayName);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cboAllowedCustomProcessingStep);
            this.panel2.Controls.Add(this.cboBindingType);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtUniqueName);
            this.panel2.Controls.Add(this.chkIsPrivate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.chkIsFunction);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 343);
            this.panel2.TabIndex = 5;
            // 
            // cboEntities
            // 
            this.cboEntities.AutoLoadData = false;
            this.cboEntities.LanguageCode = 1033;
            this.cboEntities.Location = new System.Drawing.Point(95, 258);
            this.cboEntities.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboEntities.Name = "cboEntities";
            this.cboEntities.Service = null;
            this.cboEntities.Size = new System.Drawing.Size(265, 25);
            this.cboEntities.SolutionFilter = null;
            this.cboEntities.TabIndex = 63;
            // 
            // txtPrefix
            // 
            this.txtPrefix.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPrefix.Location = new System.Drawing.Point(99, 50);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(55, 20);
            this.txtPrefix.TabIndex = 62;
            // 
            // txtLookupPublisher
            // 
            this.txtLookupPublisher.BackColor = System.Drawing.SystemColors.Window;
            this.txtLookupPublisher.Clickable = true;
            this.txtLookupPublisher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtLookupPublisher.DisplayFormat = "";
            this.txtLookupPublisher.Entity = null;
            this.txtLookupPublisher.EntityReference = null;
            this.txtLookupPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.txtLookupPublisher.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtLookupPublisher.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtLookupPublisher.Location = new System.Drawing.Point(99, 23);
            this.txtLookupPublisher.LogicalName = "plugintype";
            this.txtLookupPublisher.Name = "txtLookupPublisher";
            this.txtLookupPublisher.OrganizationService = null;
            this.txtLookupPublisher.Size = new System.Drawing.Size(232, 20);
            this.txtLookupPublisher.TabIndex = 61;
            // 
            // btnLookupPublisher
            // 
            this.btnLookupPublisher.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupPublisher.Image")));
            this.btnLookupPublisher.Location = new System.Drawing.Point(337, 21);
            this.btnLookupPublisher.Name = "btnLookupPublisher";
            this.btnLookupPublisher.Size = new System.Drawing.Size(23, 23);
            this.btnLookupPublisher.TabIndex = 60;
            this.btnLookupPublisher.UseVisualStyleBackColor = true;
            this.btnLookupPublisher.Click += new System.EventHandler(this.btnLookupPublisher_Click);
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(21, 24);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(50, 13);
            this.lblPublisher.TabIndex = 59;
            this.lblPublisher.Text = "Publisher";
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
            this.txtLookupPluginType.Location = new System.Drawing.Point(99, 290);
            this.txtLookupPluginType.LogicalName = "plugintype";
            this.txtLookupPluginType.Name = "txtLookupPluginType";
            this.txtLookupPluginType.OrganizationService = null;
            this.txtLookupPluginType.Size = new System.Drawing.Size(232, 20);
            this.txtLookupPluginType.TabIndex = 57;
            // 
            // btnLookupPluginType
            // 
            this.btnLookupPluginType.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupPluginType.Image")));
            this.btnLookupPluginType.Location = new System.Drawing.Point(337, 289);
            this.btnLookupPluginType.Name = "btnLookupPluginType";
            this.btnLookupPluginType.Size = new System.Drawing.Size(23, 23);
            this.btnLookupPluginType.TabIndex = 56;
            this.btnLookupPluginType.UseVisualStyleBackColor = true;
            this.btnLookupPluginType.Click += new System.EventHandler(this.btnLookupPluginType_Click);
            // 
            // lblPlugintype
            // 
            this.lblPlugintype.AutoSize = true;
            this.lblPlugintype.Location = new System.Drawing.Point(21, 293);
            this.lblPlugintype.Name = "lblPlugintype";
            this.lblPlugintype.Size = new System.Drawing.Size(60, 13);
            this.lblPlugintype.TabIndex = 55;
            this.lblPlugintype.Text = "PluginType";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "BoundEntity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Display Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(99, 102);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(359, 20);
            this.txtDisplayName.TabIndex = 51;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Allowed Custom Processing Step Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Binding type";
            // 
            // cboAllowedCustomProcessingStep
            // 
            this.cboAllowedCustomProcessingStep.FormattingEnabled = true;
            this.cboAllowedCustomProcessingStep.Location = new System.Drawing.Point(216, 206);
            this.cboAllowedCustomProcessingStep.Name = "cboAllowedCustomProcessingStep";
            this.cboAllowedCustomProcessingStep.Size = new System.Drawing.Size(180, 21);
            this.cboAllowedCustomProcessingStep.TabIndex = 48;
            // 
            // cboBindingType
            // 
            this.cboBindingType.FormattingEnabled = true;
            this.cboBindingType.Location = new System.Drawing.Point(99, 233);
            this.cboBindingType.Name = "cboBindingType";
            this.cboBindingType.Size = new System.Drawing.Size(180, 21);
            this.cboBindingType.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "IsPrivate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Unique Name";
            // 
            // txtUniqueName
            // 
            this.txtUniqueName.Location = new System.Drawing.Point(156, 50);
            this.txtUniqueName.Name = "txtUniqueName";
            this.txtUniqueName.Size = new System.Drawing.Size(302, 20);
            this.txtUniqueName.TabIndex = 45;
            // 
            // chkIsPrivate
            // 
            this.chkIsPrivate.AutoSize = true;
            this.chkIsPrivate.Location = new System.Drawing.Point(99, 182);
            this.chkIsPrivate.Name = "chkIsPrivate";
            this.chkIsPrivate.Size = new System.Drawing.Size(15, 14);
            this.chkIsPrivate.TabIndex = 44;
            this.chkIsPrivate.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "IsFunction";
            // 
            // chkIsFunction
            // 
            this.chkIsFunction.AutoSize = true;
            this.chkIsFunction.Location = new System.Drawing.Point(99, 154);
            this.chkIsFunction.Name = "chkIsFunction";
            this.chkIsFunction.Size = new System.Drawing.Size(15, 14);
            this.chkIsFunction.TabIndex = 42;
            this.chkIsFunction.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(359, 20);
            this.txtName.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(99, 128);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(359, 20);
            this.txtDescription.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 343);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(40, 32);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(543, 343);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(40, 32);
            this.panel4.TabIndex = 7;
            // 
            // dlgLookupPublisher
            // 
            this.dlgLookupPublisher.Entity = null;
            this.dlgLookupPublisher.LogicalName = "publisher";
            this.dlgLookupPublisher.LogicalNames = new string[] {
        "publisher"};
            this.dlgLookupPublisher.Service = null;
            this.dlgLookupPublisher.Title = null;
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
            // NewCustomApi
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(583, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewCustomApi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Custon Api";
            this.Shown += new System.EventHandler(this.InputValue_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblPublisher;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtLookupPluginType;
        private System.Windows.Forms.Button btnLookupPluginType;
        private System.Windows.Forms.Label lblPlugintype;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboAllowedCustomProcessingStep;
        private System.Windows.Forms.ComboBox cboBindingType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUniqueName;
        private System.Windows.Forms.CheckBox chkIsPrivate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsFunction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog dlgLookupPublisher;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtLookupPublisher;
        private System.Windows.Forms.Button btnLookupPublisher;
        private System.Windows.Forms.TextBox txtPrefix;
        private xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog dlgLookupPluginType;
        private xrmtb.XrmToolBox.Controls.EntitiesDropdownControl cboEntities;
    }
}