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
            this.gridCustomApiResponseProperty = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridCustomApiRequestParameter = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.gridCustomApi = new System.Windows.Forms.DataGridView();
            this.colCustomApiName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkUnmanaged = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSolution = new System.Windows.Forms.ComboBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.cboBindingType = new System.Windows.Forms.ComboBox();
            this.cboAllowedCustomProcessingStep = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiResponseProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiRequestParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApi)).BeginInit();
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
            // gridCustomApiResponseProperty
            // 
            this.gridCustomApiResponseProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomApiResponseProperty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.gridCustomApiResponseProperty.Location = new System.Drawing.Point(435, 435);
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
            this.gridCustomApiRequestParameter.Location = new System.Drawing.Point(435, 279);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(788, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cboBindingType
            // 
            this.cboBindingType.FormattingEnabled = true;
            this.cboBindingType.Location = new System.Drawing.Point(532, 206);
            this.cboBindingType.Name = "cboBindingType";
            this.cboBindingType.Size = new System.Drawing.Size(180, 21);
            this.cboBindingType.TabIndex = 6;
            // 
            // cboAllowedCustomProcessingStep
            // 
            this.cboAllowedCustomProcessingStep.FormattingEnabled = true;
            this.cboAllowedCustomProcessingStep.Location = new System.Drawing.Point(649, 233);
            this.cboAllowedCustomProcessingStep.Name = "cboAllowedCustomProcessingStep";
            this.cboAllowedCustomProcessingStep.Size = new System.Drawing.Size(180, 21);
            this.cboAllowedCustomProcessingStep.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(454, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Binding type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(454, 236);
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
            // CustomApiManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboAllowedCustomProcessingStep);
            this.Controls.Add(this.cboBindingType);
            this.Controls.Add(this.button1);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiResponseProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApiRequestParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomApi)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboBindingType;
        private System.Windows.Forms.ComboBox cboAllowedCustomProcessingStep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDisplayName;
    }
}
