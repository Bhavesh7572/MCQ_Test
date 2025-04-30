using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MCQ_Test
{
    public partial class adminlog : Form
    {
        private MainContenar parentContainer; // Store reference to container form

        public adminlog(MainContenar container)
        {
            InitializeComponent();
            //this.Text = "Log In" ;
            parentContainer = container;
            design();
        }

        private void design()
        {
            this.BackColor = Color.FromArgb(134, 134, 172);
            this.ForeColor = Color.FromArgb(255, 255, 240);
            log.BackColor = Color.FromArgb(80, 80, 129);
            aun.ForeColor = Color.FromArgb(39, 39, 87);
            aps.ForeColor = Color.FromArgb(39, 39, 87);
            aps.UseSystemPasswordChar = true;

        }
        private void Log_Click_1(object sender, EventArgs e)
        {
            string username = aun.Text.Trim();
            string password = aps.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True"))
            {
                try
                {
                    conn.Open();
                    //string str = "select count(1) from logad where adname=@u and adword=@p";
                    string str = "select count(1) from logad where adname COLLATE SQL_Latin1_General_CP1_CS_AS = @u and adword COLLATE SQL_Latin1_General_CP1_CS_AS = @p";

                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        // Load adminpg into main panel
                        parentContainer.loadform(new apg());
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or Password do not match. Try again.");
                        return;
                    }

                    this.Close(); // Close login form after successful login
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            aps.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

        private void Aps_TextChanged(object sender, EventArgs e)
        {

        }

        private void Adminlog_Load(object sender, EventArgs e)
        {
            
        }
    }
}
