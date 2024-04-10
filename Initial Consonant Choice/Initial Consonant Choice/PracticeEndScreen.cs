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
        TrialData data;
        TrialSettings settings;

        // Once practice session is complete, display the participant's score and show options to either practice again or continue to the main exercises
        public PracticeEndScreen(TrialData data, TrialSettings settings)
        {
            InitializeComponent();
            this.data = data;
            this.settings = settings;
            DisplayScore();
            // If participant has completed 3 practice trials, disable the practice again button
            if(data.practiceTrialsRequired >= 3)
            {
                PracticeAgainButton.Enabled = false;
            }
            else
            {
                PracticeAgainButton.Enabled = true;
            }
            this.FormClosing += FormUtils.HandleFormClosing;
        }

        private void DisplayScore()
        {
            // Display participant's score
            this.ParticipantScoreLabel.Text = $"Participant score: {data.getLastPracticeScore()}/6";
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
            ExerciseFacilitator fac = new ExerciseFacilitator(false, settings, data);
            fac.Show();
            this.FormClosing -= FormUtils.HandleFormClosing;
            this.Close();
        }

        private void PracticeAgainButton_Click(object sender, EventArgs e)
        {
            ExerciseFacilitator fac = new ExerciseFacilitator(true, settings, data);
            fac.Show();
            this.FormClosing -= FormUtils.HandleFormClosing;
            this.Close();
        }
    }
}
