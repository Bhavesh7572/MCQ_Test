using System;
using System.Windows.Forms;
using System.Drawing;
using RJCodeAdvance.RJControls;

namespace MCQ_Test
{
    public partial class MainContenar : Form
    {
        public static string allshowuser = "";

        public MainContenar(string uname)
        {
            InitializeComponent();
            this.Text = "DBR Quiz";
            allshowuser = uname;
            //loadform(new QuizIntroForm());
            design();
            loadform(new wel());

            ThemeManager.SaveOriginalColors(this); // Save original colors when form is initialized
            ThemeManager.ApplyTheme(this);

        }

        //For A Dark Mode
        private void RjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle Dark Mode based on the RJToggleButton
            ThemeManager.IsDarkMode = rjToggleButton1.Checked;

            // Apply the theme (dark or original) to all open forms
            foreach (Form form in Application.OpenForms)
            {
                ThemeManager.ApplyTheme(form);
                form.Invalidate();  // Forces a redraw
                form.Refresh();     // Forces an immediate refresh
            }
        }
        private void ApplyThemeToAllForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                ThemeManager.ApplyTheme(form);
                
            }
        }


        //For A Form Design
        private void design()
        {
            button1.BackColor = Color.FromArgb(80, 80, 129);
            button2.BackColor = Color.FromArgb(80, 80, 129);
            button3.BackColor = Color.FromArgb(80, 80, 129);
            button4.BackColor = Color.FromArgb(80, 80, 129);
            button5.BackColor = Color.FromArgb(80, 80, 129);
            button6.BackColor = Color.FromArgb(80, 80, 129);
            label1.ForeColor = Color.Lavender;
            panel1.BackColor = Color.FromArgb(134, 134, 172);
            panel2.BackColor = Color.FromArgb(134, 134, 172);
            Mainpane1.BackColor = Color.FromArgb(80, 80, 129);        
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        public void loadform(object Form)
        {
            label2.Text = allshowuser;

            if (this.Mainpane1.Controls.Count > 0)
                this.Mainpane1.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Mainpane1.Controls.Add(f);
            this.Mainpane1.Tag = f;
            f.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            loadform(new wel());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            loadform(new quiz(this)); // Passing this instance
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            adminlog adpg = new adminlog(this);
            adpg.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            loadform(new certificate(allshowuser));
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            loadform(new scoreboard());
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            var quizForm = Application.OpenForms["MainQuiz"] as MainQuiz;
            quizForm?.PauseQuizTimer();
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void MainContenar_Load(object sender, EventArgs e)
        {

        }
    }
}
