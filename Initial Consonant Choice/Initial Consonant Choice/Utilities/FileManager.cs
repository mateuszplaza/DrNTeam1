using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Initial_Consonant_Choice.Utilities
{
    // Class that handles the exporting of the trial data to a CSV file
    internal class FileManager
    {
        // Need to access the trial data to export it
        private TrialData trialData;

        public FileManager(TrialData trialData)
        {
            this.trialData = trialData;
        }

        // Exports the trial data to a CSV file
        public void exportTrialData(string filePath)
        {
            // retrieves all data from the trialData object
            string participantID = trialData.participantID;
            int practiceTrialsRequired = trialData.practiceTrialsRequired;
            int isi = trialData.interstimulusInterval;
            int numCorrect = trialData.numCorrect;
            int[] practiceScores = trialData.practiceScores;
            int[] trialStimulusRepeats = trialData.trialStimulusRepeats;
            int[] trialTargetRepeats = trialData.trialTargetRepeats;
            bool[] targetCorrect = trialData.targetCorrect;
            string[] correctResponse = trialData.correctResponse;
            string[] childResponse = trialData.childResponse;
            bool[] responseCorrect = trialData.responseCorrect;
            string[] responseTime = trialData.responseTime;

            // StringBuilder turns the data into a comma separated string
            string separator = ",";
            StringBuilder output = new StringBuilder();

            string[] idLine = { "Participant ID:", participantID };
            output.AppendLine(string.Join(separator, idLine));

            string[] practiceLine = { "# Practice Trials", practiceTrialsRequired.ToString() };
            output.AppendLine(string.Join(separator, practiceLine));
            
            string[] practiceScoresLine = { "Practice Scores", "=\"" + practiceScores[0].ToString() + "/6\"" };
            output.AppendLine(string.Join(separator, practiceScoresLine));
            for (int i = 1; i < practiceTrialsRequired; i++)
            {
                string newLine = string.Format("{0}, {1}", "", "=\"" + practiceScores[i].ToString() + "/6\"");
                output.AppendLine(string.Join(separator, newLine));
            }

            string[] isiLine = { "ISI (ms)", isi.ToString() };
            output.AppendLine(string.Join(separator, isiLine));

            string[] scoreLine = { "Test Score", "=\"" + numCorrect.ToString() + "/48\"" };
            output.AppendLine(string.Join(separator, scoreLine));

            string[] headings = { "Question #", "Target Correct?", "Target Repeats", "Response Correct?", "Participant Response", "Correct Response", "Trial Repeats", "Response Time" };

            output.AppendLine(string.Join(separator, headings));
            for (int i = 0; i < 48; i++)
            {
                int trialId = i + 1;
                string newLine = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", trialId.ToString(), targetCorrect[i]? "Yes" : "No", trialTargetRepeats[i].ToString(), responseCorrect[i]? "Yes" : "No", childResponse[i], correctResponse[i], trialStimulusRepeats[i].ToString(), responseTime[i]);
                output.AppendLine(string.Join(separator, newLine));
            }


            // Writes the data to a file
            try
            {
                File.WriteAllText(@filePath, output.ToString());
            }
            catch(Exception ex)
            {
                throw new ApplicationException("There was an error exporting the csv file:", ex);
            }

            Console.WriteLine("The data has been successfully saved to the CSV file");
        }

    }
}
