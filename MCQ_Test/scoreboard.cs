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
    public partial class scoreboard : Form
    {
        public scoreboard()
        {
            InitializeComponent();
            Category.Checked = true; // Set default
            //LoadComboBoxItems(); // Load default (categories)
            design();

            ThemeManager.SaveOriginalColors(this); // Save original colors when form is initialized
            ThemeManager.ApplyTheme(this);
        }
        private void design()
        {
            this.BackColor = Color.FromArgb(80, 80, 129);
            this.ForeColor = Color.FromArgb(255, 255, 240);
            comboBoxFilter.ForeColor = Color.FromArgb(39, 39, 87);
            button1.BackColor = Color.FromArgb(80, 80, 129);
            button1.ForeColor = Color.Lavender;
            dataGridViewScoreboard.ForeColor = Color.Black;
            dataGridViewScoreboard.BackgroundColor = Color.FromArgb(212, 210, 244);
            dataGridViewScoreboard.CurrentCell = null;
            dataGridViewScoreboard.DefaultCellStyle.BackColor = Color.FromArgb(134, 134, 172);

        }
        private void LoadComboBoxItems()
        {
            string columnToLoad = Username.Checked ? "username" : "category";

            comboBoxFilter.Items.Clear(); // Clear existing items
            

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True"))
            {
                string query = $"SELECT DISTINCT {columnToLoad} FROM scoreboard";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxFilter.Items.Add(reader[columnToLoad].ToString());
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string selectedValue = comboBoxFilter.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedValue))
            {
                MessageBox.Show("Please select a value.");
                return;
            }

            string filterColumn = Username.Checked ? "username" : "category";

            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True"))
            {
                string query = $@"SELECT username, score, total, category, date_taken 
                                  FROM scoreboard 
                                  WHERE {filterColumn} = @value 
                                  ORDER BY score DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@value", selectedValue);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewScoreboard.DataSource = dt;
            }
        }

        private void Category_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Category.Checked)
                LoadComboBoxItems();
        }

        private void Username_CheckedChanged(object sender, EventArgs e)
        {
            if (Username.Checked)
                LoadComboBoxItems();
        }

        private void Scoreboard_Load(object sender, EventArgs e)
        {
            var quizForm = Application.OpenForms["MainQuiz"] as MainQuiz;
            quizForm?.PauseQuizTimer();
        }
    }
}