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
    // This class controls both the facilitator and the participant screens for the exercise portion, both during practice and testing.
    // All main business logic for the trials is contained here
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

        // constant used for feedback delay
        const int FEEDBACK_TIME = 500;

        // There are three phases
        // Phase 0 is the trial initialization
        // Phase 1 is the initial prompt word
        // Phase 2 is the selection phase
        // This function sets visibility of the relevant panels and controls on the page
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

        // Sets labels for the current exercise
        public void setLabels()
        {
            oneButton.Text = "1: " + exercises[curExercise].choices[0];
            twoButton.Text = "2: " + exercises[curExercise].choices[1];
            threeButton.Text = "3: " + exercises[curExercise].choices[2];

            exerciseNumLabel.Text = "Trial " + (curExercise + 1) + " / " + exercises.Count;
            currentScoreLabel.Text = "Current Score: " + data.numCorrect + " / " + data.numAttempted;

        }

        // Disable or enable all buttons
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

        // Constructor
        public ExerciseFacilitator(bool isPractice, TrialSettings settings, TrialData data)
        {
            InitializeComponent();
            this.FormClosing += FormUtils.HandleFormClosing;

            // Set exercise list
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
            
            // Initialize first exercise and set to initial phase
            setLabels();
            checkStreak();
            setPhase(0);

            participantScreen = new ExerciseParticipantScreen(this);
            participantScreen.Show();
            participantScreen.randomizeFaces();
            participantScreen.enterPhase1();

            // Show horse page if not in practice mode
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

            // initialize response timer
            timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += OnTimeEvent;
        }

        // Timer tick management
        private void OnTimeEvent(Object source, ElapsedEventArgs e)
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

        // Initialize phase 1
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

        // Initialize phase 2
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


        // Called when an exercise is finished
        public void nextExercise()
        {
            // Record data
            data.numAttempted++;
            if(!isPractice && (data.numAttempted % settings.reinforcementFrequency == 0) && data.numAttempted != exercises.Count)
            {
                progressButton_Click(null, null);
            }

            // Mark response as correct or incorrect
            data.correctResponse[curExercise] = exercises[curExercise].correctChoice;
            if (data.childResponse[curExercise] == data.correctResponse[curExercise])
            {
                data.responseCorrect[curExercise] = true;
                data.numCorrect++;
            }

            // Move to next exercise
            curExercise++;
            // If all exercises are done, end practice or trials
            if (curExercise == exercises.Count)
            {
                if (isPractice)
                {
                    timer.Dispose();
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
            // Otherwise, move to next exercise
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

        // Quit the program, disposing of the participant screen and facilitator screen
        private void quit()
        {
            participantScreen.FormClosing -= FormUtils.HandleFormClosing;
            participantScreen.Close();
            this.FormClosing -= FormUtils.HandleFormClosing;
            this.Close();
        }

        // Check if the incorrect streak is too high, and if so, prompt the user to exit
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

                // If the yes button was pressed ...
                if (result == DialogResult.Yes)
                {
                    // End Program
                    curExercise = exercises.Count - 1;
                    nextExercise();
                }

                return true;
            }
            return false;
        }

        // Button click handlers
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


        // Handler for each button in the selection phase
        private async void oneButton_Click(object sender, EventArgs e)
        {
            // Stop timer and record response time
            timer.Stop();
            data.responseTime[curExercise] = timerLabel.Text;

            // Disable buttons and show feedback
            enableButtons(false);
            if (exercises[curExercise].correctChoiceIndex == 0)
            {
                oneButton.BackColor = Color.PaleGreen;
                incorrectStreak = 0;
            }
            else
            {
                oneButton.BackColor = Color.PaleVioletRed;
                incorrectStreak++;
            }

            if(isPractice && settings.idCorrect)
            {
                participantScreen.setSpeaker(exercises[curExercise].correctChoiceIndex + 1);
            } else if (!isPractice && settings.idResponse)
            {
                participantScreen.setSpeaker(1);
            }

            // Wait for feedback time and reset button
            await Task.Run(() => Thread.Sleep(FEEDBACK_TIME));
            oneButton.BackColor = default(Color);
            oneButton.UseVisualStyleBackColor = true;
            data.childResponse[curExercise] = exercises[curExercise].choices[0];
            enableButtons(true);
            nextExercise();
            checkStreak();
        }

        private async void twoButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            data.responseTime[curExercise] = timerLabel.Text;

            enableButtons(false);
            if (exercises[curExercise].correctChoiceIndex == 1)
            {
                twoButton.BackColor = Color.PaleGreen;
                incorrectStreak = 0;
            }
            else
            {
                twoButton.BackColor = Color.PaleVioletRed;
                incorrectStreak++;
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
            checkStreak();
        }

        private async void threeButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            data.responseTime[curExercise] = timerLabel.Text;

            enableButtons(false);
            if (exercises[curExercise].correctChoiceIndex == 2)
            {
                threeButton.BackColor = Color.PaleGreen;
                incorrectStreak = 0;
            }
            else
            {
                threeButton.BackColor = Color.PaleVioletRed;
                incorrectStreak++;
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
            checkStreak();
        }

        // Replay, skip, and quit buttons
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
            // End Program
            curExercise = exercises.Count - 1;
            nextExercise();
        }

        // Show the reinforcement screen
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
