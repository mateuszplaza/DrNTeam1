using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    internal class TrialSettings
    {

        private String participantID;
        private bool practice;
        private bool idResponse;
        private bool idCorrect;

        public TrialSettings(String participantID, bool practice, bool idResponse, bool idCorrect)
        {
            this.participantID = participantID;
            this.practice = practice;
            this.idResponse = idResponse;
            this.idCorrect = idCorrect;
        }
    }
}
