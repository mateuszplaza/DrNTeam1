using Initial_Consonant_Choice.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace Initial_Consonant_Choice
{
    // Trial end page, allows user to save data
    public partial class TrialEndScreen : Form
    {
        public TrialData data;


        // Constructor, needs trial data from experiment to save
        public TrialEndScreen(TrialData data)
        {
            InitializeComponent();
            this.data = data;
            SaveAndQuitButton.Enabled = false;
            SaveAndReturnButton.Enabled = false;
            FilePathTextbox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            this.FormClosing += FormUtils.HandleFormClosing;
        }

        private void FilePathTextbox_TextChanged(object sender, EventArgs e)
        {
            if (IsFilePathValid(FilePathTextbox.Text))
            {
                SaveAndQuitButton.Enabled = true;
                SaveAndReturnButton.Enabled = true;

            }
            else 
            {
                SaveAndQuitButton.Enabled = false;
                SaveAndReturnButton.Enabled = false;
            }
        }

        private void SaveAndQuitButton_Click(object sender, EventArgs e)
        {
            SaveData();
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

        private void SaveAndReturnButton_Click(object sender, EventArgs e)
        {
            SaveData();
            Start start = new Start();
            this.Hide();
            start.ShowDialog();
        }

        // Save data to a CSV file, exports to FileManager
        private void SaveData()
        {
            FileManager FM = new FileManager(data);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save CSV File";
                saveFileDialog.InitialDirectory = FilePathTextbox.Text;
                saveFileDialog.FileName = data.participantID + "_icc.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Writing data to the CSV file
                    try
                    {
                        FM.exportTrialData(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        static bool IsFilePathValid(string filePath)
        {
            try
            {
                // Check if the file path is rooted
                if (!Path.IsPathRooted(filePath))
                {
                    return false;
                }

                // Check if the file path is valid
                //Path.GetFullPath(filePath); // Will throw exception for invalid path
                if (string.IsNullOrEmpty(filePath) || filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1 || !System.IO.Directory.Exists(filePath))
                {
                    return false;
                }

                // If all checks pass, path valid
                return true;
            }
            catch (Exception)
            {
                return false; // An exception occurred, invalid file path
            }
        }
    }
}
