using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Initial_Consonant_Choice.Utilities;

namespace Initial_Consonant_Choice
{
    public partial class ExerciseFacilitator : Form
    {
        System.Timers.Timer timer;
        int timerH, timerM, timerS, timerMS;
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

        const int FEEDBACK_TIME = 500;

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

            exerciseNumLabel.Text = "Trial " + (curExercise + 1) + " / " + exercises.Count;
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

            if (!isPractice)
            {
                inReinforcement = true;
                enableButtons(false);
                participantScreen.beginReinforcement(0, exercises.Count);
                progressButton.Text = "Ready For Trials";
                label1.Text = "Testing - Facilitator";
            }
            else 
            {
                participantScreen.endReinforcement();
                label1.Text = "Practice - Facilitator";
            }

            audioManager = new AudioManager();

            timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                timerMS += 1;
                if (timerMS == 100)
                {
                    timerMS = 0;
                    timerS += 1;
                }
                if (timerS == 60)
                {
                    timerS = 0;
                    timerM += 1;
                }
                if (timerM == 60)
                {
                    timerM = 0;
                    timerH += 1;
                }

                timerLabel.Text = string.Format("{0}:{1}:{2}:{3}", timerH.ToString().ToString().PadLeft(2,'0'), timerM.ToString().ToString().PadLeft(2, '0'), timerS.ToString().ToString().PadLeft(2, '0'), timerMS.ToString().ToString().PadLeft(2, '0'));

            }));
        }

        public async void phase1()
        {
            setPhase(1);
            participantScreen.setSpeaker(2);
            enableButtons(false);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, 0, isPractice));
            enableButtons(true);
            phase1Panel.Controls.Add(incorrectButton);
            phase1Panel.Controls.Add(correctButton);
            participantScreen.setSpeaker(-1);
        }

        public async void phase2()
        {
            setPhase(2);
            participantScreen.enterPhase2();
            enableButtons(false);

            participantScreen.setSpeaker(1);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, exercises[curExercise].choiceOrder[0], isPractice));
            participantScreen.setSpeaker(-1);
            await Task.Run(() => Thread.Sleep(settings.stimulusDelay));
            participantScreen.setSpeaker(2);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, exercises[curExercise].choiceOrder[1], isPractice));
            participantScreen.setSpeaker(-1);
            await Task.Run(() => Thread.Sleep(settings.stimulusDelay));
            participantScreen.setSpeaker(3);
            await Task.Run(() => audioManager.PlaySoundSync(curExercise + 1, exercises[curExercise].choiceOrder[2], isPractice));
            participantScreen.setSpeaker(-1);
            await Task.Run(() => Thread.Sleep(settings.stimulusDelay));
            participantScreen.setSpeaker(-1);

            timer.Start();

            enableButtons(true);
        }

        public void awaitPhase2() 
        {
            phase1Panel.Controls.Remove(incorrectButton);
            phase1Panel.Controls.Remove(correctButton);
            beginButton.Text = "Continue Trial";
            phase1Panel.Controls.Add(beginButton);
        }

        public void nextExercise()
        {
            timer.Stop();
            data.responseTime[curExercise] = timerLabel.Text;

            data.numAttempted++;
            if(!isPractice && (data.numAttempted % settings.reinforcementFrequency == 0) && data.numAttempted != exercises.Count)
            {
                progressButton_Click(null, null);
            }

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
                    progressButton.Text = "Continue to Exit";
                    inReinforcement = true;
                    enableButtons(false);
                    participantScreen.beginReinforcement(exercises.Count, exercises.Count);
                }
            }
            else
            {
                setLabels();
                participantScreen.randomizeFaces();
                participantScreen.enterPhase1();
                setPhase(0);
                beginButton.Text = "Begin Trial";
                phase0Panel.Controls.Add(beginButton);
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
            if (phase == 0)
            {
                timer.Stop();
                timerH = 0;
                timerM = 0;
                timerS = 0;
                timerMS = 0;
                timerLabel.Text = "00:00:00:00";
                phase1();
            }
            else
            {
                phase2();
            }
        }

        private void correctButton_Click(object sender, EventArgs e)
        {
            data.targetCorrect[curExercise] = true;
            awaitPhase2();
        }

        private void incorrectButton_Click(object sender, EventArgs e)
        {
            data.targetCorrect[curExercise] = false;
            awaitPhase2();
        }

        private async void oneButton_Click(object sender, EventArgs e)
        {
            enableButtons(false);
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

            if(isPractice && settings.idCorrect)
            {
                participantScreen.setSpeaker(exercises[curExercise].correctChoiceIndex + 1);
            } else if (!isPractice && settings.idResponse)
            {
                participantScreen.setSpeaker(1);
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            oneButton.BackColor = default(Color);
            oneButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[0];
            enableButtons(true);
            nextExercise();
        }

        private async void twoButton_Click(object sender, EventArgs e)
        {
            enableButtons(false);
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

            if (isPractice && settings.idCorrect)
            {
                participantScreen.setSpeaker(exercises[curExercise].correctChoiceIndex + 1);
            }
            else if (!isPractice && settings.idResponse)
            {
                participantScreen.setSpeaker(2);
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            twoButton.BackColor = default(Color);
            twoButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[1];
            enableButtons(true);
            nextExercise();
        }

        private async void threeButton_Click(object sender, EventArgs e)
        {
            enableButtons(false);
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

            if (isPractice && settings.idCorrect)
            {
                participantScreen.setSpeaker(exercises[curExercise].correctChoiceIndex + 1);
            }
            else if (!isPractice && settings.idResponse)
            {
                participantScreen.setSpeaker(3);
            }

            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            threeButton.BackColor = default(Color);
            threeButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[2];
            enableButtons(true);
            nextExercise();
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            if (phase == 1)
            {
                phase1Panel.Controls.Remove(beginButton);
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
            if (!inReinforcement)
            {
                enableButtons(false);
                participantScreen.beginReinforcement(curExercise + 1, exercises.Count);
                progressButton.Text = "Back To Trials";
            } 
            else if(progressButton.Text == "Continue to Exit") 
            {
                TrialEndScreen endScreen = new TrialEndScreen(data);
                endScreen.Show();
                quit();
            }
            else
            {
                participantScreen.endReinforcement();
                enableButtons(true);
                progressButton.Text = "Show Progress";
            }

            inReinforcement = !inReinforcement;
        }
    }
}
