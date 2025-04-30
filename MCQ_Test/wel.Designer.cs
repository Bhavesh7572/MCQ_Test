namespace MCQ_Test
{
    partial class wel
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
            this.Welcome = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Label();
            this.Features = new System.Windows.Forms.Label();
            this.Control = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Welcome
            // 
            this.Welcome.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Welcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.Welcome.Location = new System.Drawing.Point(0, 0);
            this.Welcome.Name = "Welcome";
            this.Welcome.Size = new System.Drawing.Size(1567, 232);
            this.Welcome.TabIndex = 0;
            this.Welcome.Text = "label1";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Start.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Start.Location = new System.Drawing.Point(0, 456);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(1567, 290);
            this.Start.TabIndex = 1;
            this.Start.Text = "label1";
            // 
            // Features
            // 
            this.Features.BackColor = System.Drawing.SystemColors.ControlText;
            this.Features.Dock = System.Windows.Forms.DockStyle.Left;
            this.Features.Location = new System.Drawing.Point(0, 232);
            this.Features.Name = "Features";
            this.Features.Size = new System.Drawing.Size(948, 224);
            this.Features.TabIndex = 2;
            this.Features.Text = "label1";
            // 
            // Control
            // 
            this.Control.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Control.Dock = System.Windows.Forms.DockStyle.Right;
            this.Control.Location = new System.Drawing.Point(755, 232);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(812, 224);
            this.Control.TabIndex = 3;
            this.Control.Text = "label1";
            // 
            // wel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 746);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.Features);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "wel";
            this.Text = "wel";
            this.Load += new System.EventHandler(this.Wel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Welcome;
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Label Features;
        private System.Windows.Forms.Label Control;
    }
}