using Initial_Consonant_Choice.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Initial_Consonant_Choice
{
    // Start page, pretty simple, just a button to go to the setup page
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Setup setup = new Setup();
            this.FormClosing += FormUtils.HandleFormClosing;
            setup.Show();
            this.Hide();
        }
    }
}
