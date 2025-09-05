namespace XTB.CustomApiManager.Forms
{
    partial class OpenApiViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenApiViewerForm));
            this.scinJson = new ScintillaNET.Scintilla();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rdJson = new System.Windows.Forms.RadioButton();
            this.rdYaml = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scinJson
            // 
            this.scinJson.Lexer = ScintillaNET.Lexer.Json;
            this.scinJson.Location = new System.Drawing.Point(12, 72);
            this.scinJson.Name = "scinJson";
            this.scinJson.Size = new System.Drawing.Size(729, 414);
            this.scinJson.TabIndex = 2;
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rdYaml);
            this.grpFormat.Controls.Add(this.rdJson);
            this.grpFormat.Location = new System.Drawing.Point(248, 12);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(139, 54);
            this.grpFormat.TabIndex = 3;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Format";
            // 
            // rdJson
            // 
            this.rdJson.AutoSize = true;
            this.rdJson.Checked = true;
            this.rdJson.Location = new System.Drawing.Point(18, 20);
            this.rdJson.Name = "rdJson";
            this.rdJson.Size = new System.Drawing.Size(53, 17);
            this.rdJson.TabIndex = 0;
            this.rdJson.TabStop = true;
            this.rdJson.Text = "JSON";
            this.rdJson.UseVisualStyleBackColor = true;
            this.rdJson.CheckedChanged += new System.EventHandler(this.rdJson_CheckedChanged);
            // 
            // rdYaml
            // 
            this.rdYaml.AutoSize = true;
            this.rdYaml.Location = new System.Drawing.Point(77, 20);
            this.rdYaml.Name = "rdYaml";
            this.rdYaml.Size = new System.Drawing.Size(54, 17);
            this.rdYaml.TabIndex = 1;
            this.rdYaml.Text = "YAML";
            this.rdYaml.UseVisualStyleBackColor = true;
            this.rdYaml.CheckedChanged += new System.EventHandler(this.rdYaml_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // OpenApiViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 789);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpFormat);
            this.Controls.Add(this.scinJson);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpenApiViewerForm";
            this.Text = "OpenApi Viewer";
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ScintillaNET.Scintilla scinJson;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rdYaml;
        private System.Windows.Forms.RadioButton rdJson;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}