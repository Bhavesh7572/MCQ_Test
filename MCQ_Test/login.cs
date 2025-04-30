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
    public partial class login : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True");
        public login()
        {
            InitializeComponent();
            design();
        }
        private void design()
        {
            this.BackColor = Color.FromArgb(134, 134, 172);
            this.ForeColor = Color.FromArgb(255, 255, 240);
            button2.BackColor = Color.FromArgb(80, 80, 129);
            log.BackColor = Color.FromArgb(80,80,129);
            unm.ForeColor = Color.FromArgb(39, 39, 87);
            pss.ForeColor = Color.FromArgb(39, 39, 87);
            toppn.BackColor = Color.Gray;
            pss.UseSystemPasswordChar = true;
            MaximizeBox = false;

        }
        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void Log_Click(object sender, EventArgs e)
        {
            string username = unm.Text.Trim();
            string password = pss.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf; Integrated Security = True"))
            {
                //string query = "SELECT * FROM logstd WHERE uname=@user AND pword=@pass";
                string query = "SELECT * FROM logstd WHERE uname COLLATE SQL_Latin1_General_CP1_CS_AS = @user AND pword COLLATE SQL_Latin1_General_CP1_CS_AS = @pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    this.Hide();
                    MainContenar quiz = new MainContenar(username);
                    quiz.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
                conn.Close();
            }
        }
        private void Button2_Click_1(object sender, EventArgs e)
        {
            signIn spg = new signIn();
            spg.Show();
            this.Hide();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            pss.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

