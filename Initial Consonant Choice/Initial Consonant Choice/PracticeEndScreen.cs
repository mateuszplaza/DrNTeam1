using Initial_Consonant_Choice.Utilities;
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
        static bool practiceAgain = true;


        public PracticeEndScreen(int participantScore)
        {
            InitializeComponent();
            Hide();
            this.participantScore = participantScore;
            DisplayScore();
            PracticeAgainButton.Enabled = practiceAgain;
            Show();
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

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            ExerciseFacilitator fac = new ExerciseFacilitator(false, new TrialSettings("", true, false, false, 1000), new TrialData());
            this.Hide();
            fac.Show();
        }

        private void PracticeAgainButton_Click(object sender, EventArgs e)
        {
            practiceAgain = false;
            ExerciseFacilitator fac = new ExerciseFacilitator(true, new TrialSettings("", true, false, false, 1000), new TrialData());
            this.Hide();
            fac.Show();
        }
    }
}
