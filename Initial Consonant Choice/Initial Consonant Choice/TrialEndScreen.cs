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
    public partial class TrialEndScreen : Form
    {
        public TrialData data;

        public TrialEndScreen(TrialData data)
        {
            InitializeComponent();
            this.data = data;
            SaveAndQuitButton.Enabled = false;
        }

        private void FilePathTextbox_TextChanged(object sender, EventArgs e)
        {
            if (IsFilePathValid(FilePathTextbox.Text))
            {
                SaveAndQuitButton.Enabled = true;
            }
            else 
            {
                SaveAndQuitButton.Enabled = false;
            }
        }

        private void SaveAndQuitButton_Click(object sender, EventArgs e)
        {
            data = new TrialData();
            FileManager FM = new FileManager(data);

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Save CSV File";
                saveFileDialog.InitialDirectory = FilePathTextbox.Text;
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

        static bool IsFilePathValid(string filePath)
        {
            try
            {
                // Check if the file path is rooted
                if (!Path.IsPathRooted(filePath))
                {
                    return false;
                }

                // Check if the directory is valid
                string directory = Path.GetFullPath(filePath);
               if (string.IsNullOrEmpty(directory) || directory.IndexOfAny(Path.GetInvalidPathChars()) != -1 || !System.IO.Directory.Exists(filePath))
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
