namespace Initial_Consonant_Choice
{
    partial class ExerciseParticipantScreen
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
            basePanel = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            reinforcementPanel = new Panel();
            trackImage = new PictureBox();
            pictureBox5 = new PictureBox();
            horseImage = new PictureBox();
            basePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            reinforcementPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)horseImage).BeginInit();
            SuspendLayout();
            // 
            // basePanel
            // 
            basePanel.BackColor = Color.Transparent;
            basePanel.Controls.Add(pictureBox3);
            basePanel.Controls.Add(pictureBox2);
            basePanel.Controls.Add(pictureBox1);
            basePanel.Location = new Point(0, 0);
            basePanel.Margin = new Padding(0);
            basePanel.Name = "basePanel";
            basePanel.Size = new Size(800, 450);
            basePanel.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = Properties.Resources.face_3;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(506, 131);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(200, 200);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.face_2;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(300, 131);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(200, 200);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.face_1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(94, 131);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // reinforcementPanel
            // 
            reinforcementPanel.BackColor = Color.Transparent;
            reinforcementPanel.Controls.Add(trackImage);
            reinforcementPanel.Controls.Add(pictureBox5);
            reinforcementPanel.Controls.Add(horseImage);
            reinforcementPanel.Location = new Point(0, 0);
            reinforcementPanel.Margin = new Padding(0);
            reinforcementPanel.Name = "reinforcementPanel";
            reinforcementPanel.Size = new Size(800, 450);
            reinforcementPanel.TabIndex = 1;
            // 
            // trackImage
            // 
            trackImage.BackColor = Color.Black;
            trackImage.Location = new Point(166, 303);
            trackImage.Name = "trackImage";
            trackImage.Size = new Size(502, 11);
            trackImage.TabIndex = 2;
            trackImage.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.finish;
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(667, 139);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(105, 158);
            pictureBox5.TabIndex = 1;
            pictureBox5.TabStop = false;
            // 
            // horseImage
            // 
            horseImage.BackgroundImage = Properties.Resources.horse;
            horseImage.BackgroundImageLayout = ImageLayout.Stretch;
            horseImage.Location = new Point(22, 192);
            horseImage.Name = "horseImage";
            horseImage.Size = new Size(144, 105);
            horseImage.TabIndex = 0;
            horseImage.TabStop = false;
            // 
            // ExerciseParticipantScreen
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(basePanel);
            Controls.Add(reinforcementPanel);
            Name = "ExerciseParticipantScreen";
            Text = "ExerciseParticipantScreen";
            Load += ExerciseParticipantScreen_Load;
            ResizeEnd += UIResize;
            Resize += UIResize;
            basePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            reinforcementPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)horseImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel basePanel;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel reinforcementPanel;
        private PictureBox horseImage;
        private PictureBox pictureBox5;
        private PictureBox trackImage;
    }
}