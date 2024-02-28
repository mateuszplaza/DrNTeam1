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
            //TODO: Export trial data in a .csv file at specified location

            int[] trialStimulusRepeats = trialData.trialStimulusRepeats;
            string[] correctResponse = trialData.correctResponse;
            string[] childResponse = trialData.childResponse;

            string separator = ",";
            StringBuilder output = new StringBuilder();

            string[] nLine = { "Practice Trials Required", trialData.practiceTrialsRequired.ToString() };
            output.AppendLine(string.Join(separator, nLine));

            string[] practiceHeadings = { "Practice Trial #", "Stimulus Repeats", "Correct Response", "Child Response" };
            output.AppendLine(string.Join(separator, practiceHeadings));
            for (int i = 0; i < 6; i++)
            {
                int trialId = i + 1;
                string newLine = string.Format("{0}, {1}, {2}, {3}", trialId.ToString(), trialStimulusRepeats[i].ToString(), correctResponse[i], childResponse[i]);
                output.AppendLine(string.Join(separator, newLine));
            }

            string[] headings = { "Trial #", "Stimulus Repeats", "Correct Response", "Child Response" };
            for (int i = 0; i < 48; i++)
            {
                int trialId = i + 1;
                string newLine = string.Format("{0}, {1}, {2}, {3}", trialId.ToString(), trialStimulusRepeats[i + 6].ToString(), correctResponse[i + 6], childResponse[i + 6]);
                output.AppendLine(string.Join(separator, newLine));
            }

            try
            {
                File.AppendAllText(@filePath, output.ToString());
            }
            catch(Exception ex)
            {
                throw new ApplicationException("There was an error exporting the csv file:", ex);
            }

            Console.WriteLine("The data has been successfully saved to the CSV file");
        }

    }
}
