namespace MCQ_Test
{
    partial class scoreboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewScoreboard = new System.Windows.Forms.DataGridView();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.RadioButton();
            this.Category = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScoreboard)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewScoreboard
            // 
            this.dataGridViewScoreboard.AllowUserToAddRows = false;
            this.dataGridViewScoreboard.AllowUserToDeleteRows = false;
            this.dataGridViewScoreboard.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewScoreboard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewScoreboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScoreboard.Location = new System.Drawing.Point(238, 333);
            this.dataGridViewScoreboard.Name = "dataGridViewScoreboard";
            this.dataGridViewScoreboard.ReadOnly = true;
            this.dataGridViewScoreboard.RowTemplate.Height = 24;
            this.dataGridViewScoreboard.Size = new System.Drawing.Size(1075, 309);
            this.dataGridViewScoreboard.TabIndex = 0;
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(660, 167);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(219, 33);
            this.comboBoxFilter.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(724, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(778, 114);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(123, 29);
            this.Username.TabIndex = 3;
            this.Username.TabStop = true;
            this.Username.Text = "Username";
            this.Username.UseVisualStyleBackColor = true;
            this.Username.CheckedChanged += new System.EventHandler(this.Username_CheckedChanged);
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category.Location = new System.Drawing.Point(626, 114);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(113, 29);
            this.Category.TabIndex = 4;
            this.Category.TabStop = true;
            this.Category.Text = "Category";
            this.Category.UseVisualStyleBackColor = true;
            this.Category.CheckedChanged += new System.EventHandler(this.Category_CheckedChanged_1);
            // 
            // scoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 746);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.dataGridViewScoreboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "scoreboard";
            this.Text = "scoreboard";
            this.Load += new System.EventHandler(this.Scoreboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScoreboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewScoreboard;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton Username;
        private System.Windows.Forms.RadioButton Category;
    }
}