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
        int incorrectStreak = 0;
        bool isPractice;
        bool inReinforcement = false;
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

        public void setLabels()
        {
            oneButton.Text = "1: " + exercises[curExercise].choices[0];
            twoButton.Text = "2: " + exercises[curExercise].choices[1];
            threeButton.Text = "3: " + exercises[curExercise].choices[2];

            exerciseNumLabel.Text = "Exercise " + (curExercise + 1) + " / " + exercises.Count;
            currentScoreLabel.Text = "Current Score: " + data.numCorrect + " / " + data.numAttempted;
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

            setLabels();
            checkStreak();
            setPhase(0);

            participantScreen = new ExerciseParticipantScreen(this);
            participantScreen.Show();
            participantScreen.randomizeFaces();
            participantScreen.enterPhase1();

            audioManager = new AudioManager();
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
                    data.finishPractice();
                    PracticeEndScreen endScreen = new PracticeEndScreen(data, settings);
                    endScreen.Show();
                    quit();
                }
                else
                {
                    TrialEndScreen endScreen = new TrialEndScreen(data);
                    endScreen.Show();
                    quit();
                }
            }
            else
            {
                setLabels();
                participantScreen.randomizeFaces();
                participantScreen.enterPhase1();
                setPhase(0);
            }
        }

        private void quit()
        {
            participantScreen.FormClosing -= FormUtils.HandleFormClosing;
            participantScreen.Close();
            this.FormClosing -= FormUtils.HandleFormClosing;
            this.Close();
        }

        private bool checkStreak()
        {
            if (isPractice)
            {
                return false;
            }

            if (incorrectStreak >= 3)
            {
                alertLabel.Visible = true;
                alertLabel.Text = "! " + incorrectStreak + " incorrect responses in a row";
            }
            else
            {
                alertLabel.Visible = false;
            }

            if (incorrectStreak >= 6)
            {
                string message = "" + incorrectStreak + " incorrect responses in a row. Exit?";
                string caption = "Form Closing";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.Yes)
                {
                    TrialEndScreen tes = new TrialEndScreen(data);
                    tes.Show();
                    quit();
                }

                return true;
            }
            return false;
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            phase1();
        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            data.targetCorrect[curExercise] = true;
            phase2();
        }

        private void incorrectButton_Click(object sender, EventArgs e)
        {
            data.targetCorrect[curExercise] = false;
            phase2();
        }

        private async void oneButton_Click(object sender, EventArgs e)
        {
            if (exercises[curExercise].correctChoiceIndex == 0)
            {
                oneButton.BackColor = Color.PaleGreen;
                incorrectStreak = 0;
                checkStreak();
            }
            else
            {
                oneButton.BackColor = Color.PaleVioletRed;
                incorrectStreak++;
                checkStreak();
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            oneButton.BackColor = default(Color);
            oneButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[0];
            nextExercise();
        }

        private async void twoButton_Click(object sender, EventArgs e)
        {
            if (exercises[curExercise].correctChoiceIndex == 1)
            {
                twoButton.BackColor = Color.PaleGreen;
                incorrectStreak = 0;
                checkStreak();
            }
            else
            {
                twoButton.BackColor = Color.PaleVioletRed;
                incorrectStreak++;
                checkStreak();
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
                incorrectStreak = 0;
                checkStreak();
            }
            else
            {
                threeButton.BackColor = Color.PaleVioletRed;
                incorrectStreak++;
                checkStreak();
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            threeButton.BackColor = default(Color);
            threeButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[2];
            nextExercise();
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            if (phase == 1)
            {
                phase1();
                data.trialTargetRepeats[curExercise]++;
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
            TrialEndScreen tes = new TrialEndScreen(data);
            tes.Show();
            quit();
        }

        private void progressButton_Click(object sender, EventArgs e)
        {
            if(!inReinforcement)
            {
                enableButtons(false);
                participantScreen.beginReinforcement(curExercise + 1, exercises.Count);
                progressButton.Text = "Back To Exercises";
            } else
            {
                participantScreen.endReinforcement();
                enableButtons(true);
                progressButton.Text = "Show Progress";
            }
            inReinforcement = !inReinforcement;
        }
    }
}
