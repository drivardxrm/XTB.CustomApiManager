namespace XTB.CustomApiManager.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPublisherClear = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.txtLookupPublisher = new xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox();
            this.btnLookupPublisher = new System.Windows.Forms.Button();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRequestParameterTemplate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResponsePropertyTemplate = new System.Windows.Forms.TextBox();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.dlgLookupPublisher = new xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.btnPublisherClear);
            this.panel2.Controls.Add(this.lblConnection);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtPrefix);
            this.panel2.Controls.Add(this.txtLookupPublisher);
            this.panel2.Controls.Add(this.btnLookupPublisher);
            this.panel2.Controls.Add(this.lblPublisher);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtRequestParameterTemplate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtResponsePropertyTemplate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(891, 561);
            this.panel2.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Always",
            "Async Only",
            "Never"});
            this.comboBox1.Location = new System.Drawing.Point(273, 469);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 99;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label13.Location = new System.Drawing.Point(27, 471);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(227, 17);
            this.label13.TabIndex = 98;
            this.label13.Text = "Show Business Events section";
            this.ttInfo.SetToolTip(this.label13, "Template for Response Property Name");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(52, 89);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 17);
            this.label12.TabIndex = 97;
            this.label12.Text = "Connection : ";
            // 
            // btnPublisherClear
            // 
            this.btnPublisherClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPublisherClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublisherClear.Image = ((System.Drawing.Image)(resources.GetObject("btnPublisherClear.Image")));
            this.btnPublisherClear.Location = new System.Drawing.Point(720, 52);
            this.btnPublisherClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnPublisherClear.Name = "btnPublisherClear";
            this.btnPublisherClear.Size = new System.Drawing.Size(33, 31);
            this.btnPublisherClear.TabIndex = 96;
            this.btnPublisherClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPublisherClear.UseVisualStyleBackColor = true;
            this.btnPublisherClear.Click += new System.EventHandler(this.btnPublisherClear_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnection.Location = new System.Drawing.Point(151, 89);
            this.lblConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(139, 17);
            this.lblConnection.TabIndex = 94;
            this.lblConnection.Text = "{connectiondetail}";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(371, 89);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 93;
            this.label11.Text = "Prefix";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Enabled = false;
            this.txtPrefix.Location = new System.Drawing.Point(423, 85);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(104, 22);
            this.txtPrefix.TabIndex = 92;
            // 
            // txtLookupPublisher
            // 
            this.txtLookupPublisher.BackColor = System.Drawing.SystemColors.Window;
            this.txtLookupPublisher.Clickable = true;
            this.txtLookupPublisher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtLookupPublisher.DisplayFormat = "{{friendlyname}}";
            this.txtLookupPublisher.Entity = null;
            this.txtLookupPublisher.EntityReference = null;
            this.txtLookupPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.txtLookupPublisher.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtLookupPublisher.Id = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.txtLookupPublisher.Location = new System.Drawing.Point(368, 55);
            this.txtLookupPublisher.LogicalName = "plugintype";
            this.txtLookupPublisher.Margin = new System.Windows.Forms.Padding(4);
            this.txtLookupPublisher.Name = "txtLookupPublisher";
            this.txtLookupPublisher.OrganizationService = null;
            this.txtLookupPublisher.Size = new System.Drawing.Size(308, 23);
            this.txtLookupPublisher.TabIndex = 89;
            // 
            // btnLookupPublisher
            // 
            this.btnLookupPublisher.Image = ((System.Drawing.Image)(resources.GetObject("btnLookupPublisher.Image")));
            this.btnLookupPublisher.Location = new System.Drawing.Point(683, 50);
            this.btnLookupPublisher.Margin = new System.Windows.Forms.Padding(4);
            this.btnLookupPublisher.Name = "btnLookupPublisher";
            this.btnLookupPublisher.Size = new System.Drawing.Size(33, 31);
            this.btnLookupPublisher.TabIndex = 90;
            this.btnLookupPublisher.UseVisualStyleBackColor = true;
            this.btnLookupPublisher.Click += new System.EventHandler(this.btnLookupPublisher_Click);
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublisher.Location = new System.Drawing.Point(36, 59);
            this.lblPublisher.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(299, 17);
            this.lblPublisher.TabIndex = 91;
            this.lblPublisher.Text = "Default Publisher for current connection";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(41, 439);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(333, 18);
            this.label10.TabIndex = 88;
            this.label10.Text = "Example :  {customapiname}-Out-{uniquename} ";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 273);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(333, 18);
            this.label9.TabIndex = 87;
            this.label9.Text = "Example :  {customapiname}-In-{uniquename} ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 41);
            this.label1.TabIndex = 86;
            this.label1.Text = "{customapiname} = current Custom Api Name  {uniquename} = current Parameter Uniqu" +
    "e name ";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 210);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 21);
            this.label7.TabIndex = 85;
            this.label7.Text = "Available tokens : ";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(40, 178);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(713, 53);
            this.label8.TabIndex = 84;
            this.label8.Text = "Template for Request Parameter Name, applied when UniqueName is set. Tokens will " +
    "be replaced dynamically.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 398);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(335, 41);
            this.label5.TabIndex = 83;
            this.label5.Text = "{customapiname} = current Custom Api Name  {uniquename} = current Property Unique" +
    " name ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 21);
            this.label4.TabIndex = 82;
            this.label4.Text = "Available tokens : ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(39, 348);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(715, 27);
            this.label3.TabIndex = 81;
            this.label3.Text = "Template for Response Property Name, applied when UniqueName is set. Tokens will " +
    "be replaced dynamically.";
            // 
            // txtRequestParameterTemplate
            // 
            this.txtRequestParameterTemplate.Location = new System.Drawing.Point(307, 144);
            this.txtRequestParameterTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRequestParameterTemplate.Name = "txtRequestParameterTemplate";
            this.txtRequestParameterTemplate.Size = new System.Drawing.Size(401, 22);
            this.txtRequestParameterTemplate.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Request Parameter Default Name";
            this.ttInfo.SetToolTip(this.label2, "Template for Request Parameter Name");
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(25, 14);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(91, 25);
            this.lblTitle.TabIndex = 73;
            this.lblTitle.Text = "Settings";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(753, 480);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 39);
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
            this.btnOk.Location = new System.Drawing.Point(583, 480);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(163, 39);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Save Changes";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label6.Location = new System.Drawing.Point(27, 321);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "Response Property Default Name";
            this.ttInfo.SetToolTip(this.label6, "Template for Response Property Name");
            // 
            // txtResponsePropertyTemplate
            // 
            this.txtResponsePropertyTemplate.Location = new System.Drawing.Point(301, 319);
            this.txtResponsePropertyTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.txtResponsePropertyTemplate.Name = "txtResponsePropertyTemplate";
            this.txtResponsePropertyTemplate.Size = new System.Drawing.Size(404, 22);
            this.txtResponsePropertyTemplate.TabIndex = 1;
            // 
            // ttInfo
            // 
            this.ttInfo.AutoPopDelay = 10000;
            this.ttInfo.InitialDelay = 500;
            this.ttInfo.ReshowDelay = 100;
            this.ttInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttInfo.ToolTipTitle = "Attribute Info";
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(891, 570);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Api Manager - Settings";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResponsePropertyTemplate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip ttInfo;
        private System.Windows.Forms.TextBox txtRequestParameterTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataTextBox txtLookupPublisher;
        private System.Windows.Forms.Button btnLookupPublisher;
        private System.Windows.Forms.Label lblPublisher;
        private xrmtb.XrmToolBox.Controls.Controls.CDSLookupDialog dlgLookupPublisher;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Button btnPublisherClear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}