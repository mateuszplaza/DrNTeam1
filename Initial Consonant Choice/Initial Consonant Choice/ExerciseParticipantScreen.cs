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
    public partial class ExerciseParticipantScreen : Form
    {
        const int BASE_WIDTH = 800;
        const int BASE_HEIGHT = 450;
        int[] heights;
        int[] widths;
        int[] xLocations;
        int[] yLocations;
        List<int> faceNums = new List<int>() { 1, 2, 3 };

        public void UIResize(object sender, System.EventArgs e)
        {
            // Keep a 16:9 panel in the top middle of the screen
            if(this.Height / 9 > this.Width / 16)
            {
                basePanel.Width = this.Width;
                basePanel.Height = this.Width / 16 * 9;
                basePanel.Location = new Point(0, 0);
            }
            else
            {
                basePanel.Height = this.Height;
                basePanel.Width = this.Height / 9 * 16;
                basePanel.Location = new Point((this.Width - basePanel.Width) / 2, 0);
            }

            // Resize the images
            for(int i = 0; i < basePanel.Controls.Count; i++)
            {
                Control c = basePanel.Controls[i];
                c.Width = widths[i] * basePanel.Width / BASE_WIDTH;
                c.Height = heights[i] * basePanel.Height / BASE_HEIGHT;
                c.Location = new Point(xLocations[i] * basePanel.Width / BASE_WIDTH, yLocations[i] * basePanel.Height / BASE_WIDTH);
            }
            
        }

        public void randomizeFaces()
        {
            Random rand = new Random();
            faceNums.AddRange(Enumerable.Range(1, 7)
                               .OrderBy(i => rand.Next())
                               .Take(3));
            pictureBox1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[0]);
            pictureBox2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[1]);
            pictureBox3.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[2]);
        }

        public void enterPhase1()
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        public void enterPhase2()
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }

        public void setSpeaker(int speaker)
        {
            PictureBox[] faces = { pictureBox1, pictureBox2, pictureBox3 };
            for(int i = 0; i < 3; i++)
            {
                if(i == speaker)
                {
                    faces[i].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[i]);
                }
                else
                {
                    faces[i].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[i] + "_dim");
                }
            }
        }

        public ExerciseParticipantScreen()
        {
            InitializeComponent();
        }

        private void ExerciseParticipantScreen_Load(object sender, EventArgs e)
        {
            int numControls = basePanel.Controls.Count;
            heights = new int[numControls];
            widths = new int[numControls];
            xLocations = new int[numControls];
            yLocations = new int[numControls];
            for(int i = 0; i < numControls; i++)
            {
                heights[i] = basePanel.Controls[i].Height;
                widths[i] = basePanel.Controls[i].Width;
                xLocations[i] = basePanel.Controls[i].Location.X;
                yLocations[i] = basePanel.Controls[i].Location.Y;
            }
            randomizeFaces();
            setSpeaker(0);
            UIResize(sender, e);
        }
    }
}
