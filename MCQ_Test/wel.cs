using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCQ_Test
{
    public partial class wel : Form
    {
        public wel()
        {
            InitializeComponent();
            LoadContent();

            this.BackColor = Color.FromArgb(80, 80, 129);
            ThemeManager.SaveOriginalColors(this); // Save original colors in this form
            ThemeManager.ApplyTheme(this); // Apply the theme (dark or original)
        }
     
        private void LoadContent()
        {
            ApplyLabelStyle(Welcome, Color.FromArgb(80, 80, 129));
            ApplyLabelStyle(Features, Color.FromArgb(80, 80, 129));
            ApplyLabelStyle(Control, Color.FromArgb(80, 80, 129));
            ApplyLabelStyle(Start, Color.FromArgb(80, 80, 129));

            // Welcome Tab
            Welcome.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━\n" +
        "🎉 Welcome to DBR Quiz! 🎉\n" +
        "━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +//"🎉 Welcome to DBR Quiz! 🎉\n\n" +
                "Challenge your knowledge, improve your skills, and earn 🏅 certificates!\n" +
                "Whether you're preparing for exams, brushing up on 🧠 IT,\n" +
                "or just playing for fun — DBR Quiz is your go-to platform.";


            // Features Tab
            Features.Text =
                "✨ Features:\n\n" +
                " 🔁 10 Randomized Questions per quiz — no repeats.\n" +
                " ⏱️ 30 Seconds Timer per question to keep it exciting.\n" +
                " 📚 Multiple Categories — Java, C#, Maths, HTML & more.\n" +
                " 🏅 Earn Certificates — pass and get a personalized certificate.\n" +
                " 🌍 Global Scoreboard — compare scores worldwide.\n";

            // Control Tab
            Control.Text =
                "🎮 Controls:\n\n" +
                " 🎯 Select quiz categories that match your interests.\n" +
                " 🛠️ Build private quizzes with your own questions.\n" +
                " 🧾 PDF Downloads for every quiz result.\n" +
                " ✍️ Create Your Own Questions.";

            // Start Quiz Tab
            Start.Text =
                "📝 How It Works:\n\n" +
                " 🚀 Click “Start Quiz” to begin your journey!\n" +
                " 🎯 Choose your category.\n" +
                " 🧩 10 questions per quiz.\n" +
                " ⏰ 30 seconds per question.\n\n\n\n";
        }

        private void ApplyLabelStyle(Label lbl, Color backColor)
        {
            lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.BackColor = backColor;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Padding = new Padding(10);
        }

        private void Wel_Load(object sender, EventArgs e)
        {
            var quizForm = Application.OpenForms["MainQuiz"] as MainQuiz;
            quizForm?.PauseQuizTimer();
        }
    }
}