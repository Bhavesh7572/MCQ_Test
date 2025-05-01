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
    
    public partial class signIn : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True");
        public signIn()
        {
            InitializeComponent();
            design();
        }
        private void design()
        {
            this.BackColor = Color.FromArgb(134, 134, 172);
            this.ForeColor = Color.FromArgb(255, 255, 240);
            button2.BackColor = Color.FromArgb(80, 80, 129);
            button1.BackColor = Color.FromArgb(80, 80, 129);
            textBox1.ForeColor = Color.FromArgb(39, 39, 87);
            textBox2.ForeColor = Color.FromArgb(39, 39, 87);
            confirmPasswordTextBox.ForeColor = Color.FromArgb(39, 39, 87);
            label5.ForeColor = Color.Red;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            login lpg = new login();
            lpg.Show();
            this.Hide();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string confirmPassword = confirmPasswordTextBox.Text.Trim();

            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords Do Not Match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True"))
            {
                //string query = "INSERT INTO logstd (uname, pword) VALUES (@user, @pass)";
                string query = "INSERT INTO logstd (uname, pword) VALUES (@user, @pass)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registered successfully!");
                    cleardt();
                    login loginpg = new login();
                    this.Hide();
                    loginpg.Show();

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601) // Unique constraint violation
                    {
                        MessageBox.Show("Username already exists.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            conn.Close();
        }
        private void cleardt()
        {
            textBox1.Clear();
            textBox2.Clear();
            confirmPasswordTextBox.Clear();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            /*string pass = textBox2.Text.Trim();
            if (pass.Length < 5)
                label5.Text = "Password must be at least 5 characters long.";
            else
                label5.Text = "";*/
        }
    }
}