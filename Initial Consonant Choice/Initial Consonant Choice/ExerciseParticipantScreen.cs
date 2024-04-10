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
    // This class is the screen that the participant sees during the exercise.
    // It is controlled by the ExerciseFacilitator class, but contains some helper functions to manage the UI.
    public partial class ExerciseParticipantScreen : Form
    {
        ExerciseFacilitator facilitator;
        const int BASE_WIDTH = 800;
        const int BASE_HEIGHT = 450;
        const int REINFORCEMENT_DURATION = 3000;
        int[] heights;
        int[] widths;
        int[] xLocations;
        int[] yLocations;
        List<int> faceNums = new List<int>() { 1, 2, 3 };
        bool initialized = false;

        // UI Scaling. For a detailed explanation of how this works, see project documentation
        // Under Solution - Additional Features - UI Scaling
        public void UIResize(object sender, System.EventArgs e)
        {
            if(initialized) 
            {
                // Keep a 16:9 panel in the top middle of the screen
                if (this.Height / 9 > this.Width / 16)
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
                for (int i = 0; i < basePanel.Controls.Count; i++)
                {
                    Control c = basePanel.Controls[i];
                    c.Width = widths[i] * basePanel.Width / BASE_WIDTH;
                    c.Height = heights[i] * basePanel.Height / BASE_HEIGHT;
                    c.Location = new Point(xLocations[i] * basePanel.Width / BASE_WIDTH, yLocations[i] * basePanel.Height / BASE_HEIGHT);
                }

                bool wasHorseVisible = reinforcementPanel.Visible;
                reinforcementPanel.Visible = false;

                // Horse Panel
                reinforcementPanel.Width = basePanel.Width;
                reinforcementPanel.Height = basePanel.Height;
                reinforcementPanel.Location = basePanel.Location;
                int baseCount = basePanel.Controls.Count;

                for (int i = 0; i < reinforcementPanel.Controls.Count; i++)
                {
                    Control c = reinforcementPanel.Controls[i];
                    c.Width = widths[i + baseCount] * reinforcementPanel.Width / BASE_WIDTH;
                    c.Height = heights[i + baseCount] * reinforcementPanel.Height / BASE_HEIGHT;
                    c.Location = new Point(xLocations[i + baseCount] * reinforcementPanel.Width / BASE_WIDTH, yLocations[i + baseCount] * reinforcementPanel.Height / BASE_HEIGHT);
                }

                if (wasHorseVisible)
                {
                    reinforcementPanel.Visible = true;
                }

            }
            
        }

        // Randomizes the faces shown to the participant for each trial
        public void randomizeFaces()
        {
            Random rand = new Random();
            faceNums.Clear();
            faceNums.AddRange(Enumerable.Range(1, 7)
                               .OrderBy(i => rand.Next())
                               .Take(3));
            pictureBox1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[0]);
            pictureBox2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[1]);
            pictureBox3.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject("face_" + faceNums[2]);
        }

        // Sets visibility for each phase
        public void enterPhase1()
        {
            setSpeaker(-1);
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        public void enterPhase2()
        {
            setSpeaker(-1);
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
        }

        // Highlights the face of the speaker
        public void setSpeaker(int speaker)
        {
            speaker--;
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

        // Shows the reinforcement panel and animates the horse
        public async void beginReinforcement(int completed, int total)
        {
            basePanel.Visible = false;
            reinforcementPanel.Visible = true;
            this.BackColor = Color.LimeGreen;

            // Progress is calculated based on the number of completed trials
            // Horse moves to the right until it reaches the current proportion of completed trials
            float progress = (float)completed / total;
            int start = trackImage.Location.X;
            int finalX = start + (int)(progress * trackImage.Width) - horseImage.Width;

            int numIncrements = REINFORCEMENT_DURATION / 10;
            AudioManager audioManager = new AudioManager();
            audioManager.StartHorseSound();

            // Increments for each tick are calculated based on the width of the current window
            int increment = (int) Math.Ceiling((double)this.Width / 8500);

            await Task.Run(() => Task.Delay(1000));
            audioManager.HorseRunSound();

            while (horseImage.Location.X < finalX)
            {
                BeginControlUpdate(horseImage);
                horseImage.Location = new Point(horseImage.Location.X + increment, horseImage.Location.Y);
                EndControlUpdate(horseImage);
                await Task.Run(() => Task.Delay(2));
            }

            audioManager.StopSound();

            if(completed == total)
            {
                //flagImage.Image = Properties.Resources.flag_wave_crop;
                confettiImage.Visible = true;
                audioManager.PlayCheer();
            }

            // Allow facilitator to exit reinforcement
            facilitator.progressButton.Enabled = true;
        }

        private const int WM_SETREDRAW = 11;

        public static void BeginControlUpdate(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                  IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
            control.Invalidate();
        }

        public static void EndControlUpdate(Control control)
        {
            // Create a C "true" boolean as an IntPtr
            IntPtr wparam = new IntPtr(1);
            Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                  IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgResumeUpdate);
            control.Invalidate();
            control.Refresh();
        }

        // Return to exercise panel
        public void endReinforcement()
        {
            this.BackColor = Color.White;
            basePanel.Visible = true;
            reinforcementPanel.Visible = false;
        }

        public ExerciseParticipantScreen(ExerciseFacilitator facilitator)
        {
            InitializeComponent();
            this.FormClosing += FormUtils.HandleFormClosing;
            this.facilitator = facilitator;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        // Store initial positions of all controls
        // Again, see documentation for a detailed explanation of how this works
        private void ExerciseParticipantScreen_Load(object sender, EventArgs e)
        {
            int numControls = basePanel.Controls.Count;
            int numReinforcementControls = reinforcementPanel.Controls.Count;
            int totalControls = numControls + numReinforcementControls;

            heights = new int[totalControls];
            widths = new int[totalControls];
            xLocations = new int[totalControls];
            yLocations = new int[totalControls];
            for(int i = 0; i < numControls; i++)
            {
                heights[i] = basePanel.Controls[i].Height;
                widths[i] = basePanel.Controls[i].Width;
                xLocations[i] = basePanel.Controls[i].Location.X;
                yLocations[i] = basePanel.Controls[i].Location.Y;
            }

            for (int i = 0; i < numReinforcementControls; i++)
            {
                heights[i + numControls] = reinforcementPanel.Controls[i].Height;
                widths[i + numControls] = reinforcementPanel.Controls[i].Width;
                xLocations[i + numControls] = reinforcementPanel.Controls[i].Location.X;
                yLocations[i + numControls] = reinforcementPanel.Controls[i].Location.Y;
            }
            confettiImage.Visible = false;
            reinforcementPanel.Visible = false;

            initialized = true;
            UIResize(sender, e);
        }
    }
}
