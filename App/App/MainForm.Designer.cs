namespace App
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mappingComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModifyMapping = new System.Windows.Forms.Button();
            this.btnCreateMapping = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mappingComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateMapping);
            this.splitContainer1.Panel2.Controls.Add(this.btnModifyMapping);
            this.splitContainer1.Size = new System.Drawing.Size(284, 135);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // mappingComboBox
            // 
            this.mappingComboBox.DisplayMember = "AppName";
            this.mappingComboBox.FormattingEnabled = true;
            this.mappingComboBox.Location = new System.Drawing.Point(116, 13);
            this.mappingComboBox.Name = "mappingComboBox";
            this.mappingComboBox.Size = new System.Drawing.Size(156, 21);
            this.mappingComboBox.TabIndex = 1;
            this.mappingComboBox.ValueMember = "AppName";
            this.mappingComboBox.SelectedValueChanged += new System.EventHandler(this.mappingComboBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aplicativo:";
            // 
            // btnModifyMapping
            // 
            this.btnModifyMapping.Location = new System.Drawing.Point(12, 14);
            this.btnModifyMapping.Name = "btnModifyMapping";
            this.btnModifyMapping.Size = new System.Drawing.Size(88, 36);
            this.btnModifyMapping.TabIndex = 0;
            this.btnModifyMapping.Text = "Modificar atalhos";
            this.btnModifyMapping.UseVisualStyleBackColor = true;
            this.btnModifyMapping.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCreateMapping
            // 
            this.btnCreateMapping.Location = new System.Drawing.Point(184, 14);
            this.btnCreateMapping.Name = "btnCreateMapping";
            this.btnCreateMapping.Size = new System.Drawing.Size(88, 36);
            this.btnCreateMapping.TabIndex = 1;
            this.btnCreateMapping.Text = "Cadastrar novo aplicativo";
            this.btnCreateMapping.UseVisualStyleBackColor = true;
            this.btnCreateMapping.Click += new System.EventHandler(this.btnCreateMapping_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "knob";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox mappingComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModifyMapping;
        private System.Windows.Forms.Button btnCreateMapping;

    }
}

