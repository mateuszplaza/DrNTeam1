using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initial_Consonant_Choice.Utilities
{
    internal class FormUtils
    {
        // Handle the form closing event. Adds a popup dialog to confirm the user wants to exit the application when the x button is clicked.
        public static void HandleFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Display a confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks "No," cancel the form closing
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                } else
                {
                       // Otherwise, close the form
                    Application.Exit();
                }
            }
        }
    }
}
