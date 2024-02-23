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
            ExerciseParticipantScreen eps = new ExerciseParticipantScreen();
            eps.Show();
        }
    }
}
