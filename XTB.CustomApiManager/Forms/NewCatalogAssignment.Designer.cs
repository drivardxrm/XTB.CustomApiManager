namespace XTB.CustomApiManager.Forms
{
    partial class NewCatalogAssignment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewCatalogAssignment));
            this.label12 = new System.Windows.Forms.Label();
            this.cdsCboSolutions = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblCustomizable = new System.Windows.Forms.Label();
            this.chkIsCustomizable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblParentCatalog = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cdsDataComboBox1 = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.cdsDataComboBox2 = new xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 260);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(229, 16);
            this.label12.TabIndex = 136;
            this.label12.Text = "Add to unmanaged solution (optional)";
            // 
            // cdsCboSolutions
            // 
            this.cdsCboSolutions.DisplayFormat = "{{friendlyname}} ({{P.customizationprefix}})";
            this.cdsCboSolutions.FormattingEnabled = true;
            this.cdsCboSolutions.Location = new System.Drawing.Point(17, 280);
            this.cdsCboSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.cdsCboSolutions.Name = "cdsCboSolutions";
            this.cdsCboSolutions.OrganizationService = null;
            this.cdsCboSolutions.Size = new System.Drawing.Size(335, 24);
            this.cdsCboSolutions.TabIndex = 135;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(28, 215);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 133;
            this.pictureBox3.TabStop = false;
            // 
            // lblCustomizable
            // 
            this.lblCustomizable.AutoSize = true;
            this.lblCustomizable.Location = new System.Drawing.Point(34, 168);
            this.lblCustomizable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomizable.Name = "lblCustomizable";
            this.lblCustomizable.Size = new System.Drawing.Size(98, 16);
            this.lblCustomizable.TabIndex = 130;
            this.lblCustomizable.Text = "IsCustomizable";
            // 
            // chkIsCustomizable
            // 
            this.chkIsCustomizable.AutoSize = true;
            this.chkIsCustomizable.Location = new System.Drawing.Point(138, 168);
            this.chkIsCustomizable.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsCustomizable.Name = "chkIsCustomizable";
            this.chkIsCustomizable.Size = new System.Drawing.Size(18, 17);
            this.chkIsCustomizable.TabIndex = 129;
            this.chkIsCustomizable.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 20);
            this.label5.TabIndex = 128;
            this.label5.Text = "Assignment Object Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 119;
            this.label4.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(138, 136);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(308, 22);
            this.txtName.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 116;
            this.label1.Text = "Category";
            // 
            // lblParentCatalog
            // 
            this.lblParentCatalog.AutoSize = true;
            this.lblParentCatalog.Location = new System.Drawing.Point(34, 74);
            this.lblParentCatalog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParentCatalog.Name = "lblParentCatalog";
            this.lblParentCatalog.Size = new System.Drawing.Size(86, 16);
            this.lblParentCatalog.TabIndex = 114;
            this.lblParentCatalog.Text = "Root Catalog";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 25);
            this.lblTitle.TabIndex = 111;
            this.lblTitle.Text = "Create Catalog Assignment";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(565, 302);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 39);
            this.btnCancel.TabIndex = 109;
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
            this.btnOk.Location = new System.Drawing.Point(453, 302);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(104, 39);
            this.btnOk.TabIndex = 110;
            this.btnOk.Text = "Create";
            this.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // cdsDataComboBox1
            // 
            this.cdsDataComboBox1.DisplayFormat = "{{friendlyname}} ({{P.customizationprefix}})";
            this.cdsDataComboBox1.FormattingEnabled = true;
            this.cdsDataComboBox1.Location = new System.Drawing.Point(138, 71);
            this.cdsDataComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.cdsDataComboBox1.Name = "cdsDataComboBox1";
            this.cdsDataComboBox1.OrganizationService = null;
            this.cdsDataComboBox1.Size = new System.Drawing.Size(335, 24);
            this.cdsDataComboBox1.TabIndex = 137;
            // 
            // cdsDataComboBox2
            // 
            this.cdsDataComboBox2.DisplayFormat = "{{friendlyname}} ({{P.customizationprefix}})";
            this.cdsDataComboBox2.FormattingEnabled = true;
            this.cdsDataComboBox2.Location = new System.Drawing.Point(138, 98);
            this.cdsDataComboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.cdsDataComboBox2.Name = "cdsDataComboBox2";
            this.cdsDataComboBox2.OrganizationService = null;
            this.cdsDataComboBox2.Size = new System.Drawing.Size(335, 24);
            this.cdsDataComboBox2.TabIndex = 138;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 215);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 22);
            this.textBox1.TabIndex = 139;
            // 
            // NewCatalogAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(711, 356);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cdsDataComboBox2);
            this.Controls.Add(this.cdsDataComboBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cdsCboSolutions);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblCustomizable);
            this.Controls.Add(this.chkIsCustomizable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblParentCatalog);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewCatalogAssignment";
            this.Text = "Create Catalog Assignment";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cdsCboSolutions;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblCustomizable;
        private System.Windows.Forms.CheckBox chkIsCustomizable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblParentCatalog;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cdsDataComboBox1;
        private xrmtb.XrmToolBox.Controls.Controls.CDSDataComboBox cdsDataComboBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}