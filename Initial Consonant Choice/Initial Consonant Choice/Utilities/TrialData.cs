using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    internal class TrialData
    {
        private int practiceTrialsRequired = 0;
        private int[] trialStimulusRepeats = new int[54];
        private string[] correctResponse = new string[54];
        private string[] childResponse = new string[54];

        //Input path to trials and their answers to initialize the correct response array. 
        public TrialData(String trialPath)
        {
            /* TODO: Initialize correctResponse array according to answers from trialPath
            If we randomize order of trials we need to store the new order of trials somewhere for the correct response
            Array to make sense */
        }
        
    }
}
