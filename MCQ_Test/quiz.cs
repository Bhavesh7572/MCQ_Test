using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MCQ_Test
{
    public partial class quiz : Form
    {
        private MainContenar parentContainer; // Reference to MainContenar

        public quiz(MainContenar container)
        {
            InitializeComponent();
            design();
            parentContainer = container; // Store reference
            LoadCategories();
            ThemeManager.SaveOriginalColors(this); // Save original colors when form is initialized
            ThemeManager.ApplyTheme(this);
        }
        private void design()
        {
            this.BackColor = Color.FromArgb(80, 80, 129);
            this.ForeColor = Color.FromArgb(255, 255, 240);
            btnStart.BackColor = Color.FromArgb(80, 80, 129);
            btnStart.ForeColor = Color.Lavender;
            comboBoxCategory.ForeColor = Color.FromArgb(39, 39, 87);
        }
        private void BtnStart_Click_1(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            string selectedCategory = comboBoxCategory.SelectedItem.ToString();

            //Load MainQuiz into parent panel
            parentContainer.loadform(new MainQuiz(selectedCategory));
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


        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            var quizForm = Application.OpenForms["MainQuiz"] as MainQuiz;
            quizForm?.PauseQuizTimer();
        }
    }
}
