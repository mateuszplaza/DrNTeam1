using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Initial_Consonant_Choice.Utilities
{
    internal class FileManager
    {
        private TrialData trialData;

        public FileManager(TrialData trialData)
        {
            this.trialData = trialData;
        }

        public void exportTrialData(string filePath)
        {
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

            // Is this out of 48 or numAttempted?
            string[] scoreLine = { "Test Score", "=\"" + numCorrect.ToString() + "/48\"" };
            output.AppendLine(string.Join(separator, scoreLine));

            string[] headings = { "Question #", "Target Correct?", "Target Repeats", "Participant Response", "Correct Response", "Trial Repeats" };
            output.AppendLine(string.Join(separator, headings));
            for (int i = 0; i < 48; i++)
            {
                int trialId = i + 1;
                string newLine = string.Format("{0}, {1}, {2}, {3}, {4}, {5}", trialId.ToString(), targetCorrect[i]? "Yes" : "No", trialTargetRepeats[i].ToString(), childResponse[i], correctResponse[i], trialStimulusRepeats[i].ToString());
                output.AppendLine(string.Join(separator, newLine));
            }

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
