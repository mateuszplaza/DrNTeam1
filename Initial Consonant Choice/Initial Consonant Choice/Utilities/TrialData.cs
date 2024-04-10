using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    // Class to store data for a single trial
    // Keeps track of all results to be passed to the end screen and FileManager
    public class TrialData
    {
        public string participantID = "";
        public int practiceTrialsRequired = 0;
        public int[] practiceScores = new int[3];
        public int interstimulusInterval = 0;

        public int numCorrect = 0;
        public int numAttempted = 0;

        public bool[] targetCorrect = new bool[48];
        public int[] trialTargetRepeats = new int[48];

        public bool[] responseCorrect = new bool[48];
        public string[] childResponse = new string[48];
        public string[] correctResponse = new string[48];
        public int[] trialStimulusRepeats = new int[48];

        public string[] responseTime = new string[48];


        // This method is used to clear the saved results after a practice session
        // The exercise page does not distinguish between practice and test trials, so extra data is saved and must be cleared
        public void finishPractice()
        {
            practiceScores[practiceTrialsRequired] = numCorrect;
            practiceTrialsRequired++;
            numCorrect = 0;
            numAttempted = 0;

            targetCorrect = new bool[48];
            trialTargetRepeats = new int[48];
            responseCorrect = new bool[48];
            childResponse = new string[48];
            correctResponse = new string[48];
            trialStimulusRepeats = new int[48];
            responseTime = new string[48];
    }

        public int getLastPracticeScore()
        {
            return practiceScores[practiceTrialsRequired - 1];
        }
        
    }
}
