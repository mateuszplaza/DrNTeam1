using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    public class TrialData
    {
        public int participantID;
        public int practiceTrialsRequired = 0;
        public int[] trialStimulusRepeats = new int[48];
        public string[] correctResponse = new string[48];
        public string[] childResponse = new string[48];
        public int numCorrect = 0;
        public int numAttempted = 0;

        //Input path to trials and their answers to initialize the correct response array. 
        public TrialData()
        {
            /* TODO: Initialize correctResponse array according to answers from trialPath
            If we randomize order of trials we need to store the new order of trials somewhere for the correct response
            Array to make sense */
        }
        
    }
}
