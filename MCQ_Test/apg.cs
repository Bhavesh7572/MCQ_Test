using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class apg : Form
    {
        public apg()
        {
            InitializeComponent();
            Design();
            ThemeManager.SaveOriginalColors(this); // Save original colors when form is initialized
            ThemeManager.ApplyTheme(this);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string qu = textBox2.Text;
            string op1 = textBox3.Text;
            string op2 = textBox4.Text;
            string op3 = textBox5.Text;
            string op4 = textBox6.Text;
            string ans = "";
            string cet = textBox7.Text;

            if (radioButton1.Checked)
                ans = textBox3.Text;
            if (radioButton2.Checked)
                ans = textBox4.Text;
            if (radioButton3.Checked)
                ans = textBox5.Text;
            if (radioButton4.Checked)
                ans = textBox6.Text;

            if (qu == "" || op1 == "" || op2 == "" || op3 == "" || op4 == "" || ans == "" || cet == "")
            {
                MessageBox.Show("Please fill all the fieds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            conn.Open();
            string str = "insert into maths(que,opa,opb,opc,opd,ans,cet) values(@q,@a,@b,@c,@d,@s,@t)";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@q", qu);
            cmd.Parameters.AddWithValue("@a", op1);
            cmd.Parameters.AddWithValue("@b", op2);
            cmd.Parameters.AddWithValue("@c", op3);
            cmd.Parameters.AddWithValue("@d", op4);
            cmd.Parameters.AddWithValue("@s", ans);
            cmd.Parameters.AddWithValue("@t", cet);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Question Added.");
            LoadCategories();
            ClearAll();
        }

        private void Apg_Load(object sender, EventArgs e)
        {
            LoadCategories();
            var quizForm = Application.OpenForms["MainQuiz"] as MainQuiz;
            quizForm?.PauseQuizTimer();
        }
        private void Design()
        {
            this.BackColor = Color.FromArgb(80, 80, 129);
            this.ForeColor = Color.FromArgb(255, 255, 240);
            panel1.ForeColor = Color.FromArgb(255, 255, 240);
            panel2.ForeColor = Color.FromArgb(255, 255, 240);
            panel3.ForeColor = Color.FromArgb(255, 255, 240);
            label1.ForeColor = Color.FromArgb(255, 255, 240);
            label2.ForeColor = Color.FromArgb(255, 255, 240);
            label3.ForeColor = Color.FromArgb(255, 255, 240);
            label4.ForeColor = Color.FromArgb(255, 255, 240);
            label5.ForeColor = Color.FromArgb(255, 255, 240);
            label6.ForeColor = Color.FromArgb(255, 255, 240);
            label7.ForeColor = Color.FromArgb(255, 255, 240);
            label8.ForeColor = Color.FromArgb(255, 255, 240);
            radioButton1.ForeColor = Color.FromArgb(255, 255, 240);
            radioButton2.ForeColor = Color.FromArgb(255, 255, 240);
            radioButton3.ForeColor = Color.FromArgb(255, 255, 240);
            radioButton4.ForeColor = Color.FromArgb(255, 255, 240);
            label9.ForeColor = Color.FromArgb(255, 255, 240);
            comboBoxCategory.ForeColor = Color.FromArgb(39, 39, 87);
            button1.BackColor = Color.FromArgb(80, 80, 129);
            button1.ForeColor = Color.Lavender;
            button5.BackColor = Color.FromArgb(80, 80, 129);
            button5.ForeColor = Color.Lavender;
            button3.BackColor = Color.FromArgb(80, 80, 129);
            button3.ForeColor = Color.Lavender;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.BackgroundColor = Color.FromArgb(212, 210, 244);
            dataGridView1.CurrentCell = null;
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(134, 134, 172);

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\question.mdf;Integrated Security=True");

        private void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\question.mdf; Integrated Security = True"))
            {
                string query = "DELETE FROM maths WHERE Id = @Id";
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please Enter No. of Question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", textBox1.Text);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row deleted successfully.");
                            textBox1.Clear();
                            LoadCategories();
                        }
                        else
                            MessageBox.Show("No row found with the given Id.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
            private void LoadCategories()
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\question.mdf;Integrated Security=True";
                string query = "SELECT DISTINCT cet FROM maths";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBoxCategory.Items.Clear();
                        while (reader.Read())
                        {
                            comboBoxCategory.Items.Add(reader["cet"].ToString());
                        }
                    }
                }
                if (comboBoxCategory.Items.Count > 0)
                {
                    comboBoxCategory.SelectedIndex = 0;
                }
            }
        public void ClearAll()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            textBox7.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string cet = comboBoxCategory.SelectedItem.ToString();
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\question.mdf;Integrated Security=True"))
            {
                string query = "SELECT * FROM maths WHERE cet = @cet";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cet", cet);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].Width = 280;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].Width = 120;
                dataGridView1.Columns[6].Width = 120;
                dataGridView1.Columns[7].Width = 60;
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            }
        }
    }
    
}
