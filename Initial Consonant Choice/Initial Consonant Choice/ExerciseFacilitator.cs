using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Initial_Consonant_Choice.Utilities;

namespace Initial_Consonant_Choice
{
    public partial class ExerciseFacilitator : Form
    {
        int phase = 0;
        bool isPractice;
        List<Exercise> exercises;
        TrialSettings settings;
        TrialData data;
        int curExercise = 0;
        ExerciseParticipantScreen participantScreen;
        AudioManager audioManager;

        const int FEEDBACK_TIME = 200;

        public void setPhase(int phase)
        {
            if (phase != 0 && phase != 1 && phase != 2)
            {
                throw new ArgumentException("Phase must be 0, 1, or 2");
            }

            this.phase = phase;
            if (phase == 0)
            {
                phase0Panel.Visible = true;
                phase1Panel.Visible = false;
                phase2Panel.Visible = false;
                controlLabel1.Text = "Ready?";
            }
            else if (phase == 1)
            {
                phase0Panel.Visible = false;
                phase1Panel.Visible = true;
                phase2Panel.Visible = false;
                controlLabel1.Text = "Participant Speech:";
            }
            else
            {
                phase0Panel.Visible = false;
                phase1Panel.Visible = false;
                phase2Panel.Visible = true;
                controlLabel1.Text = "Participant Selection:";
            }
        }

        public void setLabels(int exerciseNum)
        {
            oneButton.Text = "1: " + exercises[exerciseNum].choices[0];
            twoButton.Text = "2: " + exercises[exerciseNum].choices[1];
            threeButton.Text = "3: " + exercises[exerciseNum].choices[2];

            exerciseNumLabel.Text = "Exercise " + (exerciseNum + 1) + " / " + exercises.Count;
        }

        public void enableButtons(bool enable)
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    c.Enabled = enable;
                }
                else if (c is Panel)
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2 is Button)
                        {
                            c2.Enabled = enable;
                        }
                    }
                }
            }
        }

        public ExerciseFacilitator(bool isPractice, TrialSettings settings, TrialData data)
        {
            InitializeComponent();

            this.FormClosing += FormUtils.HandleFormClosing;

            this.isPractice = isPractice;
            if (isPractice)
            {
                exercises = ExerciseManager.practiceExercises;
            }
            else
            {
                exercises = ExerciseManager.exercises;
            }

            this.settings = settings;
            this.data = data;
            if (isPractice)
            {
                data.practiceTrialsRequired++;
            }

            setLabels(0);
            setPhase(0);

            participantScreen = new ExerciseParticipantScreen();
            participantScreen.Show();
            participantScreen.randomizeFaces();
            participantScreen.enterPhase1();

            audioManager = new AudioManager(@"..\..\..\..\..\audio_files");
        }

        public async void phase1()
        {
            setPhase(1);
            participantScreen.setSpeaker(2);
            enableButtons(false);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, 0, isPractice));
            enableButtons(true);
            participantScreen.setSpeaker(-1);
        }

        public async void phase2()
        {
            setPhase(2);
            participantScreen.enterPhase2();
            enableButtons(false);

            participantScreen.setSpeaker(1);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, 1, isPractice));
            participantScreen.setSpeaker(-1);
            await Task.Run(() => Thread.Sleep(settings.stimulusDelay));
            participantScreen.setSpeaker(2);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, 2, isPractice));
            participantScreen.setSpeaker(-1);
            await Task.Run(() => Thread.Sleep(settings.stimulusDelay));
            participantScreen.setSpeaker(3);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, 3, isPractice));
            participantScreen.setSpeaker(-1);
            await Task.Run(() => Thread.Sleep(settings.stimulusDelay));
            participantScreen.setSpeaker(-1);

            enableButtons(true);
        }

        public void nextExercise()
        {
            data.numAttempted++;
            data.correctResponse[curExercise] = exercises[curExercise].correctChoice;
            if (data.childResponse[curExercise] == data.correctResponse[curExercise])
            {
                data.numCorrect++;
            }

            curExercise++;
            if (curExercise == exercises.Count)
            {
                if (isPractice)
                {
                    PracticeEndScreen endScreen = new PracticeEndScreen(data.numCorrect);
                    endScreen.ShowDialog();
                    this.Close();
                }
                else
                {
                    TrialEndScreen endScreen = new TrialEndScreen(data);
                    endScreen.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                setLabels(curExercise);
                participantScreen.randomizeFaces();
                participantScreen.enterPhase1();
                setPhase(0);
            }
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            phase1();
        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            phase2();
        }

        private void incorrectButton_Click(object sender, EventArgs e)
        {
            phase2();
        }

        private async void oneButton_Click(object sender, EventArgs e)
        {
            if (exercises[curExercise].correctChoiceIndex == 0)
            {
                oneButton.BackColor = Color.PaleGreen;
            }
            else
            {
                oneButton.BackColor = Color.PaleVioletRed;
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            oneButton.BackColor = default(Color);
            twoButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[0];
            nextExercise();
        }

        private async void twoButton_Click(object sender, EventArgs e)
        {
            if (exercises[curExercise].correctChoiceIndex == 1)
            {
                twoButton.BackColor = Color.PaleGreen;
            }
            else
            {
                twoButton.BackColor = Color.PaleVioletRed;
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            twoButton.BackColor = default(Color);
            twoButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[1];
            nextExercise();
        }

        private async void threeButton_Click(object sender, EventArgs e)
        {
            if (exercises[curExercise].correctChoiceIndex == 2)
            {
                threeButton.BackColor = Color.PaleGreen;
            }
            else
            {
                threeButton.BackColor = Color.PaleVioletRed;
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            threeButton.BackColor = default(Color);
            twoButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[2];
            nextExercise();
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            if (phase == 1)
            {
                phase1();
                data.trialStimulusRepeats[curExercise]++;
            }
            else if (phase == 2)
            {
                phase2();
                data.trialStimulusRepeats[curExercise]++;
            }
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            nextExercise();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
