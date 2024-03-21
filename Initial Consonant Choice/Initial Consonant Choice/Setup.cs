using Initial_Consonant_Choice.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Initial_Consonant_Choice
{
    public partial class Setup : Form
    {
        TrialSettings settings;

        public Setup()
        {
            InitializeComponent();
            this.FormClosing += FormUtils.HandleFormClosing;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        // Begin Button
        private void button1_Click(object sender, EventArgs e)
        {
            string participantID = textBox1.Text;
            bool practice = checkBox1.Checked;
            bool idResponse = checkBox2.Checked;
            bool idCorrect = checkBox3.Checked;
            int isi = (int)numericUpDown1.Value;

            // Initialize Trial Settings
            settings = new TrialSettings(participantID, practice, idResponse, idCorrect, isi);
            TrialData data = new TrialData();
            data.interstimulusInterval = isi;
            data.participantID = int.Parse(participantID);
            data.interstimulusInterval = isi;

            // Start practice or trials
            ExerciseFacilitator fac = new ExerciseFacilitator(practice, settings, data);
            fac.Show();
            this.FormClosing -= FormUtils.HandleFormClosing;
            this.Close();
        }

        // Cancel Button
        private void button2_Click_1(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.FormClosing -= FormUtils.HandleFormClosing;
            this.Close();
        }
    }
}
