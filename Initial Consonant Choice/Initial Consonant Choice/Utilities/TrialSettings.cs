using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    public class TrialSettings
    {

        public String participantID;
        public bool practice;
        public bool idResponse;
        public bool idCorrect;
        public int stimulusDelay = 1000;
        public int reinforcementFrequency = 6;

        public TrialSettings(String participantID, bool practice, bool idResponse, bool idCorrect, int stimulusDelay, int reinforcementFrequency)
        {
            this.participantID = participantID;
            this.practice = practice;
            this.idResponse = idResponse;
            this.idCorrect = idCorrect;
            this.stimulusDelay = stimulusDelay;
            this.reinforcementFrequency = reinforcementFrequency;
        }

        public TrialSettings()
        {
            this.participantID = "0";
            this.practice = false;
            this.idResponse = false;
            this.idCorrect = false;
        }


    }
}
