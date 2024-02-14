using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Speech.Synthesis;
using System.Windows.Forms;



namespace Initial_Consonant_Choice
{
    public partial class PracticeEndScreen : Form
    {
        private int participantScore = 0;  // Variable to hold participant's score
        private FlowLayoutPanel buttonPanel;
        private Label textview;


        public PracticeEndScreen(int participantScore)
        {
            InitializeComponent();
            this.participantScore = participantScore;
            DisplayScore();
        }

        private void DisplayScore()
        {

            // Display participant's score
            this.ParticipantScoreLabel.Text = $"Participant score: {participantScore}/6";
        }

        private void PracticeEndScreen_Load(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
