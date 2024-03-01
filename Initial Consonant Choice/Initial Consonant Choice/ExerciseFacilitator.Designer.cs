namespace Initial_Consonant_Choice
{
    partial class ExerciseFacilitator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            exerciseNumLabel = new Label();
            controlLabel1 = new Label();
            label4 = new Label();
            replayButton = new Button();
            skipButton = new Button();
            quitButton = new Button();
            phase1Panel = new Panel();
            incorrectButton = new Button();
            correctButton = new Button();
            phase2Panel = new Panel();
            threeButton = new Button();
            twoButton = new Button();
            oneButton = new Button();
            phase0Panel = new Panel();
            beginButton = new Button();
            phase1Panel.SuspendLayout();
            phase2Panel.SuspendLayout();
            phase0Panel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(51, 20);
            label1.Name = "label1";
            label1.Size = new Size(216, 32);
            label1.TabIndex = 0;
            label1.Text = "Testing - Facilitator";
            // 
            // exerciseNumLabel
            // 
            exerciseNumLabel.AutoSize = true;
            exerciseNumLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exerciseNumLabel.ForeColor = SystemColors.ControlDarkDark;
            exerciseNumLabel.Location = new Point(51, 71);
            exerciseNumLabel.Name = "exerciseNumLabel";
            exerciseNumLabel.Size = new Size(110, 21);
            exerciseNumLabel.TabIndex = 1;
            exerciseNumLabel.Text = "Exercise 1 / 48";
            // 
            // controlLabel1
            // 
            controlLabel1.AutoSize = true;
            controlLabel1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            controlLabel1.Location = new Point(51, 128);
            controlLabel1.Name = "controlLabel1";
            controlLabel1.Size = new Size(172, 25);
            controlLabel1.TabIndex = 2;
            controlLabel1.Text = "Participant Speech:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(51, 287);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 3;
            label4.Text = "Controls:";
            // 
            // replayButton
            // 
            replayButton.Location = new Point(89, 330);
            replayButton.Name = "replayButton";
            replayButton.Size = new Size(90, 30);
            replayButton.TabIndex = 6;
            replayButton.Text = "Replay";
            replayButton.UseVisualStyleBackColor = true;
            replayButton.Click += replayButton_Click;
            // 
            // skipButton
            // 
            skipButton.Location = new Point(197, 330);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(90, 30);
            skipButton.TabIndex = 7;
            skipButton.Text = "Skip";
            skipButton.UseVisualStyleBackColor = true;
            skipButton.Click += skipButton_Click;
            // 
            // quitButton
            // 
            quitButton.Location = new Point(306, 330);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(90, 30);
            quitButton.TabIndex = 8;
            quitButton.Text = "Quit";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // phase1Panel
            // 
            phase1Panel.Controls.Add(incorrectButton);
            phase1Panel.Controls.Add(correctButton);
            phase1Panel.Location = new Point(51, 167);
            phase1Panel.Name = "phase1Panel";
            phase1Panel.Size = new Size(330, 97);
            phase1Panel.TabIndex = 9;
            // 
            // incorrectButton
            // 
            incorrectButton.Location = new Point(169, 17);
            incorrectButton.Name = "incorrectButton";
            incorrectButton.Size = new Size(115, 54);
            incorrectButton.TabIndex = 1;
            incorrectButton.Text = "Incorrect";
            incorrectButton.UseVisualStyleBackColor = true;
            incorrectButton.Click += incorrectButton_Click;
            // 
            // correctButton
            // 
            correctButton.Location = new Point(38, 17);
            correctButton.Name = "correctButton";
            correctButton.Size = new Size(115, 54);
            correctButton.TabIndex = 0;
            correctButton.Text = "Correct";
            correctButton.UseVisualStyleBackColor = true;
            correctButton.Click += correctButton_Click;
            // 
            // phase2Panel
            // 
            phase2Panel.Controls.Add(threeButton);
            phase2Panel.Controls.Add(twoButton);
            phase2Panel.Controls.Add(oneButton);
            phase2Panel.Location = new Point(51, 167);
            phase2Panel.Name = "phase2Panel";
            phase2Panel.Size = new Size(603, 97);
            phase2Panel.TabIndex = 10;
            // 
            // threeButton
            // 
            threeButton.Location = new Point(403, 17);
            threeButton.Name = "threeButton";
            threeButton.Size = new Size(175, 54);
            threeButton.TabIndex = 2;
            threeButton.Text = "3";
            threeButton.UseVisualStyleBackColor = true;
            threeButton.Click += threeButton_Click;
            // 
            // twoButton
            // 
            twoButton.Location = new Point(222, 17);
            twoButton.Name = "twoButton";
            twoButton.Size = new Size(175, 54);
            twoButton.TabIndex = 1;
            twoButton.Text = "2";
            twoButton.UseVisualStyleBackColor = true;
            twoButton.Click += twoButton_Click;
            // 
            // oneButton
            // 
            oneButton.Location = new Point(38, 17);
            oneButton.Name = "oneButton";
            oneButton.Size = new Size(175, 54);
            oneButton.TabIndex = 0;
            oneButton.Text = "1";
            oneButton.UseVisualStyleBackColor = true;
            oneButton.Click += oneButton_Click;
            // 
            // phase0Panel
            // 
            phase0Panel.Controls.Add(beginButton);
            phase0Panel.Location = new Point(51, 167);
            phase0Panel.Name = "phase0Panel";
            phase0Panel.Size = new Size(256, 97);
            phase0Panel.TabIndex = 11;
            // 
            // beginButton
            // 
            beginButton.Location = new Point(38, 17);
            beginButton.Name = "beginButton";
            beginButton.Size = new Size(152, 54);
            beginButton.TabIndex = 0;
            beginButton.Text = "Begin Exercise";
            beginButton.UseVisualStyleBackColor = true;
            beginButton.Click += beginButton_Click;
            // 
            // ExerciseFacilitator
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(phase0Panel);
            Controls.Add(phase2Panel);
            Controls.Add(phase1Panel);
            Controls.Add(quitButton);
            Controls.Add(skipButton);
            Controls.Add(replayButton);
            Controls.Add(label4);
            Controls.Add(controlLabel1);
            Controls.Add(exerciseNumLabel);
            Controls.Add(label1);
            Name = "ExerciseFacilitator";
            Text = "ExerciseFacilitator";
            phase1Panel.ResumeLayout(false);
            phase2Panel.ResumeLayout(false);
            phase0Panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label exerciseNumLabel;
        private Label controlLabel1;
        private Label label4;
        private Button replayButton;
        private Button skipButton;
        private Button quitButton;
        private Panel phase1Panel;
        private Button correctButton;
        private Panel phase2Panel;
        private Button threeButton;
        private Button twoButton;
        private Button oneButton;
        private Button incorrectButton;
        private Panel phase0Panel;
        private Button beginButton;
    }
}