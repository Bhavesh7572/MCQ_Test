namespace MCQ_Test
{
    partial class adminlog
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
            this.aps = new System.Windows.Forms.TextBox();
            this.log = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.aun = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.showPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // aps
            // 
            this.aps.BackColor = System.Drawing.Color.Lavender;
            this.aps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aps.Location = new System.Drawing.Point(236, 163);
            this.aps.Name = "aps";
            this.aps.Size = new System.Drawing.Size(257, 30);
            this.aps.TabIndex = 21;
            this.aps.TextChanged += new System.EventHandler(this.Aps_TextChanged);
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.Transparent;
            this.log.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(207, 276);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(92, 42);
            this.log.TabIndex = 24;
            this.log.Text = "Log In";
            this.log.UseVisualStyleBackColor = false;
            this.log.Click += new System.EventHandler(this.Log_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Enter User Name : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(186, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 31);
            this.label5.TabIndex = 19;
            this.label5.Text = "Admin Log In";
            // 
            // aun
            // 
            this.aun.BackColor = System.Drawing.Color.Lavender;
            this.aun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aun.Location = new System.Drawing.Point(237, 111);
            this.aun.Name = "aun";
            this.aun.Size = new System.Drawing.Size(256, 30);
            this.aun.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Enter Password : ";
            // 
            // showPasswordCheckBox
            // 
            this.showPasswordCheckBox.AutoSize = true;
            this.showPasswordCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPasswordCheckBox.Location = new System.Drawing.Point(166, 224);
            this.showPasswordCheckBox.Name = "showPasswordCheckBox";
            this.showPasswordCheckBox.Size = new System.Drawing.Size(175, 29);
            this.showPasswordCheckBox.TabIndex = 25;
            this.showPasswordCheckBox.Text = "Show Password";
            this.showPasswordCheckBox.UseVisualStyleBackColor = true;
            this.showPasswordCheckBox.CheckedChanged += new System.EventHandler(this.ShowPasswordCheckBox_CheckedChanged);
            // 
            // adminlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 364);
            this.Controls.Add(this.showPasswordCheckBox);
            this.Controls.Add(this.aps);
            this.Controls.Add(this.log);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.aun);
            this.Controls.Add(this.label6);
            this.Name = "adminlog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "adminlog";
            this.Load += new System.EventHandler(this.Adminlog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox aps;
        private System.Windows.Forms.Button log;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox aun;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox showPasswordCheckBox;
    }
}