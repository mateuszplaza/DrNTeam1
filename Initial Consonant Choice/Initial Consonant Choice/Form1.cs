using Initial_Consonant_Choice.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Speech.Synthesis;


namespace Initial_Consonant_Choice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pes_button_Click(object sender, EventArgs e)
        {
            ExerciseFacilitator fac = new ExerciseFacilitator(true, new TrialSettings("", true, false, false, 1000), new TrialData());
            fac.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            setup.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PracticeEndScreen pes = new PracticeEndScreen(4);
            pes.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrialEndScreen tes = new TrialEndScreen(new TrialData());
            tes.Show();
        }
    }
}
