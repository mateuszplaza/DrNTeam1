using Initial_Consonant_Choice.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Speech.Synthesis;
using System.Windows.Forms;



namespace Initial_Consonant_Choice
{
    public partial class TrialEndScreen : Form
    {
        public TrialData data;

        public TrialEndScreen(TrialData data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void SaveAndQuitButton_Click(object sender, EventArgs e)
        {
            new FileManager();
            Application.Exit();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.Description = "Select a location to save the file";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected folder path
                string selectedFolderPath = folderBrowserDialog.SelectedPath;

                // Display the selected folder path in the textbox
                FilePathTextbox.Text = selectedFolderPath;
            }
        }

        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            this.Hide();
            start.Show();
        }
    }
}
