namespace XTB.CustomApiManager.Forms
{
    partial class NewRequestParameterForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRequestParameterForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkInfo = new System.Windows.Forms.LinkLabel();
            this.chkExpando = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cdsCboSolutions = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.lblCustomizable = new System.Windows.Forms.Label();
            this.chkIsCustomizable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cdsCustomApiName = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cboEntities = new xrmtb.XrmToolBox.Controls.EntitiesDropdownControl();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUniqueName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIsOptional = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lnkInfo);
            this.panel2.Controls.Add(this.chkExpando);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.cdsCboSolutions);
            this.panel2.Controls.Add(this.lblCustomizable);
            this.panel2.Controls.Add(this.chkIsCustomizable);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cdsCustomApiName);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.pictureBox13);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.cboEntities);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtDisplayName);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cboType);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtUniqueName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.chkIsOptional);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 370);
            this.panel2.TabIndex = 5;
            // 
            // lnkInfo
            // 
            this.lnkInfo.AutoSize = true;
            this.lnkInfo.Location = new System.Drawing.Point(425, 240);
            this.lnkInfo.Name = "lnkInfo";
            this.lnkInfo.Size = new System.Drawing.Size(24, 13);
            this.lnkInfo.TabIndex = 107;
            this.lnkInfo.TabStop = true;
            this.lnkInfo.Text = "info";
            this.lnkInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInfo_LinkClicked);
            // 
            // chkExpando
            // 
            this.chkExpando.AutoSize = true;
            this.chkExpando.Enabled = false;
            this.chkExpando.Location = new System.Drawing.Point(359, 239);
            this.chkExpando.Name = "chkExpando";
            this.chkExpando.Size = new System.Drawing.Size(67, 17);
            this.chkExpando.TabIndex = 7;
            this.chkExpando.Text = "expando";
            this.chkExpando.UseVisualStyleBackColor = true;
            this.chkExpando.CheckedChanged += new System.EventHandler(this.chkExpando_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(182, 13);
            this.label12.TabIndex = 106;
            this.label12.Text = "Add to unmanaged solution (optional)";
            this.ttInfo.SetToolTip(this.label12, "Controls whether the Custom API can be customized or deleted when deployed as man" +
        "aged.");
            // 
            // cdsCboSolutions
            // 
            this.cdsCboSolutions.DisplayFormat = "{{friendlyname}} ({{P.customizationprefix}})";
            this.cdsCboSolutions.FormattingEnabled = true;
            this.cdsCboSolutions.ItemHeight = 13;
            this.cdsCboSolutions.Location = new System.Drawing.Point(31, 335);
            this.cdsCboSolutions.Name = "cdsCboSolutions";
            this.cdsCboSolutions.OrganizationService = null;
            this.cdsCboSolutions.Size = new System.Drawing.Size(252, 21);
            this.cdsCboSolutions.TabIndex = 10;
            this.cdsCboSolutions.SelectedIndexChanged += new System.EventHandler(this.cdsCboSolutions_SelectedIndexChanged);
            this.cdsCboSolutions.TextUpdate += new System.EventHandler(this.cdsCboSolutions_TextUpdate);
            // 
            // lblCustomizable
            // 
            this.lblCustomizable.AutoSize = true;
            this.lblCustomizable.Location = new System.Drawing.Point(28, 285);
            this.lblCustomizable.Name = "lblCustomizable";
            this.lblCustomizable.Size = new System.Drawing.Size(77, 13);
            this.lblCustomizable.TabIndex = 104;
            this.lblCustomizable.Text = "IsCustomizable";
            this.ttInfo.SetToolTip(this.lblCustomizable, "Controls whether the Custom API Request Parameter can be customized or deleted wh" +
        "en deployed as managed.");
            // 
            // chkIsCustomizable
            // 
            this.chkIsCustomizable.AutoSize = true;
            this.chkIsCustomizable.Location = new System.Drawing.Point(108, 285);
            this.chkIsCustomizable.Name = "chkIsCustomizable";
            this.chkIsCustomizable.Size = new System.Drawing.Size(15, 14);
            this.chkIsCustomizable.TabIndex = 9;
            this.chkIsCustomizable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Custom API";
            // 
            // cdsCustomApiName
            // 
            this.cdsCustomApiName.BackColor = System.Drawing.SystemColors.Window;
            this.cdsCustomApiName.DisplayFormat = "{{name}} ({{uniquename}})";
            this.cdsCustomApiName.Entity = null;
            this.cdsCustomApiName.EntityReference = null;
            this.cdsCustomApiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdsCustomApiName.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.cdsCustomApiName.Location = new System.Drawing.Point(106, 43);
            this.cdsCustomApiName.LogicalName = "customapi";
            this.cdsCustomApiName.Name = "cdsCustomApiName";
            this.cdsCustomApiName.OrganizationService = null;
            this.cdsCustomApiName.Size = new System.Drawing.Size(317, 20);
            this.cdsCustomApiName.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(303, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(213, 13);
            this.label17.TabIndex = 75;
            this.label17.Text = "Fields that cannot be modified after creation";
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox13.InitialImage")));
            this.pictureBox13.Location = new System.Drawing.Point(286, 13);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(20, 19);
            this.pictureBox13.TabIndex = 74;
            this.pictureBox13.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(19, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(263, 20);
            this.lblTitle.TabIndex = 73;
            this.lblTitle.Text = "Create New Request Parameter";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(390, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 32);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(306, 324);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 32);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Create";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.InitialImage")));
            this.pictureBox5.Location = new System.Drawing.Point(123, 263);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 19);
            this.pictureBox5.TabIndex = 70;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(337, 237);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 19);
            this.pictureBox4.TabIndex = 67;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(317, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 19);
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.InitialImage")));
            this.pictureBox3.Location = new System.Drawing.Point(424, 74);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 19);
            this.pictureBox3.TabIndex = 64;
            this.pictureBox3.TabStop = false;
            // 
            // cboEntities
            // 
            this.cboEntities.AutoLoadData = false;
            this.cboEntities.Enabled = false;
            this.cboEntities.LanguageCode = 1033;
            this.cboEntities.Location = new System.Drawing.Point(127, 233);
            this.cboEntities.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboEntities.Name = "cboEntities";
            this.cboEntities.Service = null;
            this.cboEntities.Size = new System.Drawing.Size(215, 25);
            this.cboEntities.SolutionFilter = null;
            this.cboEntities.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(26, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "Logical Entity Name";
            this.ttInfo.SetToolTip(this.label11, "The logical name of the entity bound to the custom API request parameter.\r\nCannot" +
        " be changed after it is saved.");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "Display Name";
            this.ttInfo.SetToolTip(this.label10, "Localized display name for custom API request parameter instances. \r\nFor use when" +
        " the message parameter is exposed to be called in an app.");
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(104, 127);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(319, 20);
            this.txtDisplayName.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Type";
            this.ttInfo.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(104, 209);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(211, 21);
            this.cboType.TabIndex = 5;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Unique Name";
            this.ttInfo.SetToolTip(this.label6, "Unique name for the custom API request parameter. \r\nThis will be the name of the " +
        "parameter when you call the Custom API.\r\nCannot be changed after it is saved.");
            // 
            // txtUniqueName
            // 
            this.txtUniqueName.Location = new System.Drawing.Point(104, 74);
            this.txtUniqueName.Name = "txtUniqueName";
            this.txtUniqueName.Size = new System.Drawing.Size(319, 20);
            this.txtUniqueName.TabIndex = 1;
            this.txtUniqueName.Leave += new System.EventHandler(this.txtUniqueName_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "IsOptional";
            this.ttInfo.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // chkIsOptional
            // 
            this.chkIsOptional.AutoSize = true;
            this.chkIsOptional.Location = new System.Drawing.Point(108, 266);
            this.chkIsOptional.Name = "chkIsOptional";
            this.chkIsOptional.Size = new System.Drawing.Size(15, 14);
            this.chkIsOptional.TabIndex = 8;
            this.chkIsOptional.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Name";
            this.ttInfo.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 101);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(319, 20);
            this.txtName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(104, 153);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(319, 49);
            this.txtDescription.TabIndex = 4;
            this.ttInfo.SetToolTip(this.txtDescription, "Localized description for custom API request parameter instances. \r\nFor use when " +
        "the message parameter is exposed to be called in an app. \r\nFor example, as a Too" +
        "lTip.");
            // 
            // ttInfo
            // 
            this.ttInfo.AutoPopDelay = 10000;
            this.ttInfo.InitialDelay = 500;
            this.ttInfo.ReshowDelay = 100;
            this.ttInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttInfo.ToolTipTitle = "Attribute Info";
            // 
            // NewRequestParameterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(525, 371);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewRequestParameterForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Api Manager";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUniqueName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsOptional;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private xrmtb.XrmToolBox.Controls.EntitiesDropdownControl cboEntities;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pictureBox13;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox cdsCustomApiName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip ttInfo;
        private System.Windows.Forms.Label lblCustomizable;
        private System.Windows.Forms.CheckBox chkIsCustomizable;
        private System.Windows.Forms.Label label12;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cdsCboSolutions;
        private System.Windows.Forms.CheckBox chkExpando;
        private System.Windows.Forms.LinkLabel lnkInfo;
    }
}