namespace App
{
    partial class ModifyMapping
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbAppName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSINGLE_CLICK = new System.Windows.Forms.TextBox();
            this.tbDOUBLE_CLICK = new System.Windows.Forms.TextBox();
            this.tbTRIPLE_CLICK = new System.Windows.Forms.TextBox();
            this.tbROTATE_CCW = new System.Windows.Forms.TextBox();
            this.tbROTATE_CW = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aplicativo:";
            // 
            // tbAppName
            // 
            this.tbAppName.Location = new System.Drawing.Point(74, 13);
            this.tbAppName.Name = "tbAppName";
            this.tbAppName.Size = new System.Drawing.Size(198, 20);
            this.tbAppName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelBtn);
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.tbROTATE_CW);
            this.groupBox1.Controls.Add(this.tbROTATE_CCW);
            this.groupBox1.Controls.Add(this.tbTRIPLE_CLICK);
            this.groupBox1.Controls.Add(this.tbDOUBLE_CLICK);
            this.groupBox1.Controls.Add(this.tbSINGLE_CLICK);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 217);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Eventos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Clique simples:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Clique duplo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Clique triplo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giro anti-horário:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Giro horário:";
            // 
            // tbSINGLE_CLICK
            // 
            this.tbSINGLE_CLICK.Location = new System.Drawing.Point(132, 27);
            this.tbSINGLE_CLICK.Name = "tbSINGLE_CLICK";
            this.tbSINGLE_CLICK.Size = new System.Drawing.Size(100, 20);
            this.tbSINGLE_CLICK.TabIndex = 5;
            this.tbSINGLE_CLICK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeystroke);
            // 
            // tbDOUBLE_CLICK
            // 
            this.tbDOUBLE_CLICK.Location = new System.Drawing.Point(132, 50);
            this.tbDOUBLE_CLICK.Name = "tbDOUBLE_CLICK";
            this.tbDOUBLE_CLICK.Size = new System.Drawing.Size(100, 20);
            this.tbDOUBLE_CLICK.TabIndex = 6;
            this.tbDOUBLE_CLICK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeystroke);
            // 
            // tbTRIPLE_CLICK
            // 
            this.tbTRIPLE_CLICK.Location = new System.Drawing.Point(132, 72);
            this.tbTRIPLE_CLICK.Name = "tbTRIPLE_CLICK";
            this.tbTRIPLE_CLICK.Size = new System.Drawing.Size(100, 20);
            this.tbTRIPLE_CLICK.TabIndex = 7;
            this.tbTRIPLE_CLICK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeystroke);
            // 
            // tbROTATE_CCW
            // 
            this.tbROTATE_CCW.Location = new System.Drawing.Point(132, 94);
            this.tbROTATE_CCW.Name = "tbROTATE_CCW";
            this.tbROTATE_CCW.Size = new System.Drawing.Size(100, 20);
            this.tbROTATE_CCW.TabIndex = 8;
            this.tbROTATE_CCW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeystroke);
            // 
            // tbROTATE_CW
            // 
            this.tbROTATE_CW.Location = new System.Drawing.Point(132, 116);
            this.tbROTATE_CW.Name = "tbROTATE_CW";
            this.tbROTATE_CW.Size = new System.Drawing.Size(100, 20);
            this.tbROTATE_CW.TabIndex = 9;
            this.tbROTATE_CW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.handleKeystroke);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(89, 160);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Salvar";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(178, 160);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancelar";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ModifyMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbAppName);
            this.Controls.Add(this.label1);
            this.Name = "ModifyMapping";
            this.Text = "Criar/Modificar Mapeamento";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAppName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbROTATE_CW;
        private System.Windows.Forms.TextBox tbROTATE_CCW;
        private System.Windows.Forms.TextBox tbTRIPLE_CLICK;
        private System.Windows.Forms.TextBox tbDOUBLE_CLICK;
        private System.Windows.Forms.TextBox tbSINGLE_CLICK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}