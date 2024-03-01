using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    internal class FormUtils
    {
        public static void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the user is closing the form using the close button (X)
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                // Display a confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks "No," cancel the form closing
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
