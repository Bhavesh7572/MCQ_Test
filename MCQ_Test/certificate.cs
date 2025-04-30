using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data.SqlClient;

namespace MCQ_Test
{
    public partial class certificate : Form
    {
        public static string userName = "";
        public static int score = 0;
        public static string quizName = "";
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True");
        public certificate(string un)
        {
            InitializeComponent();
            userName = un;
            design();
            LoadCategories(); // Load quiz categories for this user
            ThemeManager.SaveOriginalColors(this);
            ThemeManager.ApplyTheme(this);
        }
        private void design()
        {
            this.BackColor = Color.FromArgb(80, 80, 129);
            this.ForeColor = Color.FromArgb(255, 255, 240);
            button1.BackColor = Color.FromArgb(80, 80, 129);
            button1.ForeColor = Color.Lavender;
            comboBoxCategory.ForeColor = Color.FromArgb(39, 39, 87);
            
        }
        private void LoadCategories()
        {
            comboBoxCategory.Items.Clear();

            string query = "SELECT DISTINCT category FROM scoreboard WHERE username = @username";
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True"))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", userName);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxCategory.Items.Add(reader["category"].ToString());
                }
                connection.Close();
            }

            if (comboBoxCategory.Items.Count > 0)
                comboBoxCategory.SelectedIndex = 0; // select first by default
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a quiz category first.");
                return;
            }

            string selectedCategory = comboBoxCategory.SelectedItem.ToString();
            quizName = selectedCategory;

            string query = @"
        SELECT TOP 1 score
        FROM scoreboard
        WHERE username = @username AND category = @category
        ORDER BY score DESC";

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf;Integrated Security=True"))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", userName);
                command.Parameters.AddWithValue("@category", selectedCategory);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    score = Convert.ToInt32(reader["score"]);
                    connection.Close();
                    GenerateCertificate(); // use your existing method
                }
                else
                {
                    connection.Close();
                    MessageBox.Show("No score found for this category.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
        private void GenerateCertificate()
        {
            string date = DateTime.Now.ToString("MMMM dd, yyyy");
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = Path.Combine(desktopPath, $"{userName}_Certificate.pdf");

            Document doc = new Document(PageSize.A4.Rotate(), 50, 50, 50, 50);

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
                doc.Open();

                PdfContentByte cb = writer.DirectContent;

                // Add background image
                /*string backgroundPath = @"C:\Users\Rohan\source\repos\quiz\quiz\New Project (1).jpg"; // Ensure this file exists
                if (File.Exists(backgroundPath))
                {
                    iTextSharp.text.Image bg = iTextSharp.text.Image.GetInstance(backgroundPath);
                    bg.SetAbsolutePosition(0, 0);
                    bg.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
                    bg.Alignment = iTextSharp.text.Image.UNDERLYING;
                    doc.Add(bg);
                }*/

                // Draw border
                cb.SetLineWidth(3f);
                cb.Rectangle(20, 20, doc.PageSize.Width - 40, doc.PageSize.Height - 40);
                cb.Stroke();

                // Add transparent watermark
                string watermarkPath = @"C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\DBR_Logo.jpg"; // Ensure this file exists
                if (File.Exists(watermarkPath))
                {
                    PdfContentByte under = writer.DirectContentUnder;
                    iTextSharp.text.Image watermark = iTextSharp.text.Image.GetInstance(watermarkPath);
                    watermark.ScalePercent(150f); // size

                    float x = (doc.PageSize.Width - watermark.ScaledWidth) / 2;
                    float y = (doc.PageSize.Height - watermark.ScaledHeight) / 2;

                    PdfGState gs = new PdfGState();
                    gs.FillOpacity = 0.4f; // 40% transparent

                    under.SaveState();
                    under.SetGState(gs);
                    watermark.SetAbsolutePosition(x, y);
                    under.AddImage(watermark);
                    under.RestoreState();
                }

                // Title
                iTextSharp.text.Font titleFont = FontFactory.GetFont("Times New Roman", 32, iTextSharp.text.Font.BOLD, BaseColor.DARK_GRAY);
                Paragraph title = new Paragraph("Certificate of Completion", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingBefore = 50,
                    SpacingAfter = 30
                };
                doc.Add(title);

                // Main body
                iTextSharp.text.Font bodyFont = FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font nameFont = FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD, BaseColor.BLUE);

                Paragraph body = new Paragraph();
                body.Alignment = Element.ALIGN_CENTER;
                body.SpacingBefore = 50;
                body.SpacingAfter = 70;

                string quizLine = string.IsNullOrWhiteSpace(quizName) ? "the quiz" : $"the quiz \"{quizName}\"";

                body.Add(new Phrase("This certifies that\n\n", bodyFont));
                body.Add(new Phrase(userName + "\n\n", nameFont));
                body.Add(new Phrase($"has successfully completed {quizLine} with a score of ", bodyFont));
                body.Add(new Phrase(score + "/10.\n\n", nameFont));
                body.Add(new Phrase($"Date: {date}\n\nCongratulations!", bodyFont));

                doc.Add(body);

                // Footer signature
                /*Paragraph footer = new Paragraph("Authorized Signature", bodyFont)
                {
                    Alignment = Element.ALIGN_RIGHT,
                    SpacingBefore = 60,
                    SpacingAfter = 10
                };
                doc.Add(footer);*/

                doc.Close();
                writer.Close();

                MessageBox.Show($"Certificate saved to Desktop:\n{fileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating certificate: " + ex.Message);
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Certificate_Load(object sender, EventArgs e)
        {
            var quizForm = Application.OpenForms["MainQuiz"] as MainQuiz;
            quizForm?.PauseQuizTimer();
        }
    }
}
