using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using MCQ_Test;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Media;
using System.Drawing;

namespace MCQ_Test
{
    public partial class MainQuiz : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private int timeLeft = 30;
        private Timer timer;

        //Load Questions Based on Category
        private string quizCategory;
        private string un = MainContenar.allshowuser;

        public MainQuiz(string category)
        {
            InitializeComponent();
            quizCategory = category; //  Save the category
            questions = QuestionService.GetQuestions(quizCategory); //  Use it here
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            LoadQuestion();
            design();
            ThemeManager.SaveOriginalColors(this); // Save original colors when form is initialized
            ThemeManager.ApplyTheme(this);
        }

        private void design()
        {
            this.BackColor = Color.FromArgb(80, 80, 129);
            btnNext.BackColor = Color.FromArgb(80, 80, 129);
            btnNext.ForeColor = Color.Lavender;
            btnDownloadPdf.BackColor = Color.FromArgb(80, 80, 129);
            btnDownloadPdf.ForeColor = Color.Lavender;
        }

        private void LoadQuestion()
        {

            if (currentQuestionIndex >= questions.Count)
            {
                timer.Stop();
                SaveScore(un, score, quizCategory);
                //btnDownloadPdf.Enabled = true; 
                btnDownloadPdf.Visible = true;
                clearAll();
                MessageBox.Show($"Quiz Over! Your Score: {score}/{questions.Count}");
                return;
            }

            var q = questions[currentQuestionIndex];

            label1.Text = $"Que. {currentQuestionIndex + 1}";
            timeLeft = 30;
            lblTimer.Text = $"Time Left: {timeLeft}s";

            lblQuestion.Text = q.Text;
            radioButton1.Text = q.Options[0];
            radioButton2.Text = q.Options[1];
            radioButton3.Text = q.Options[2];
            radioButton4.Text = q.Options[3];

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            timer.Start();

        }

        void SaveScore(string username, int score, string category)
        {
            string insertQuery = "INSERT INTO scoreboard (username, score, total, category) VALUES (@name, @score, @total, @cat)";
            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\logindb.mdf; Integrated Security = True"))
            {
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", username);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.Parameters.AddWithValue("@total", 10);
                cmd.Parameters.AddWithValue("@cat", category);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ExportResultsToPDF()
        {
            Document doc = new Document();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "QuizResult.pdf");
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            doc.Add(new Paragraph($"{quizCategory} Quiz Results"));
            doc.Add(new Paragraph($"Date: {DateTime.Now}\n\n"));

            foreach (var q in questions)
            {
                doc.Add(new Paragraph($"Q: {q.Text}"));
                doc.Add(new Paragraph($"Your Answer: {q.UserAnswer ?? "No Answer"}"));
                doc.Add(new Paragraph($"Correct Answer: {q.CorrectAnswerText}"));
                doc.Add(new Paragraph($"Result: {(q.IsCorrect ? "✔ Correct" : "✖ Wrong")}\n\n\n"));
            }
            doc.Close();
            MessageBox.Show("PDF saved to Desktop!");

        }


        private void Timer_Tick(object sender, EventArgs e)
        {

            timeLeft--;
            lblTimer.Text = $"Time Left: {timeLeft}s";

            if (timeLeft <= 0)
            {
                timer.Stop();
                // Auto-select Option A
                radioButton1.Checked = true;
                SoundPlayer player = new SoundPlayer(@"C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\buzzerwav-14769.wav");
                player.Play();
                MessageBox.Show("Time's up!");
                if (currentQuestionIndex < questions.Count)
                {
                    CheckAnswer();
                    currentQuestionIndex++;
                    LoadQuestion(); // This now runs only if it's safe
                }
            }
        }

        private void BtnNext_Click_1(object sender, EventArgs e)
        {
            timer.Stop();

            if (currentQuestionIndex < questions.Count)
            {
                NextQuestion(); // this includes CheckAnswer() and LoadQuestion() safely
            }
        }
        private void NextQuestion()
        {
            if (currentQuestionIndex >= questions.Count)
                return;

            string selectedText = null;
            if (radioButton1.Checked) selectedText = radioButton1.Text;
            else if (radioButton2.Checked) selectedText = radioButton2.Text;
            else if (radioButton3.Checked) selectedText = radioButton3.Text;
            else if (radioButton4.Checked) selectedText = radioButton4.Text;

            if (selectedText == null)
            {
                MessageBox.Show("Please select an option before proceeding.");
                timer.Start(); // Resume the timer
                return;
            }

            questions[currentQuestionIndex].UserAnswer = selectedText;

            if (selectedText.Equals(questions[currentQuestionIndex].CorrectAnswerText, StringComparison.OrdinalIgnoreCase))
            {
                SoundPlayer player = new SoundPlayer(@"C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\correct-6033.wav");
                player.Play();
                score++;
            }
            else
            {
                SoundPlayer player = new SoundPlayer(@"C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\buzzer-or-wrong-answer-20582.wav");
                player.Play();
            }

            currentQuestionIndex++;
            LoadQuestion();
        }
        private void CheckAnswer()
        {
            string selectedText = null;
            if (radioButton1.Checked) selectedText = radioButton1.Text;
            else if (radioButton2.Checked) selectedText = radioButton2.Text;
            else if (radioButton3.Checked) selectedText = radioButton3.Text;
            else if (radioButton4.Checked) selectedText = radioButton4.Text;

            var q = questions[currentQuestionIndex];
            q.UserAnswer = selectedText;

            score++;
            /*if (q.IsCorrect)
            {
                SoundPlayer player = new SoundPlayer(@"C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\correct-6033.wav");
                player.Play(); // Or .PlayLooping(), .PlaySync()
            }
            else
            {
                SoundPlayer player = new SoundPlayer(@"C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\buzzer-or-wrong-answer-20582.wav");
                player.Play();
            }*/
        }

        private void BtnDownloadPdf_Click(object sender, EventArgs e)
        {
            //ExportResultsToPDF();
            try
            {
                ExportResultsToPDF();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Could not save PDF. Is it already open?\n" + ex.Message);
            }

        }

        private void MainQuiz_Load(object sender, EventArgs e)
        {
            questions = QuestionService.GetQuestions(quizCategory);
            LoadQuestion();
        }
        private void clearAll()
        {
            lblQuestion.Text = "";
            lblTimer.Text = "";
            label1.Text = "";
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            btnNext.Visible = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void PauseQuizTimer()
        {
            if (timer != null && timer.Enabled)
            {
                timer.Stop();
            }
        }
    }
}