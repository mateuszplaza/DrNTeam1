namespace Initial_Consonant_Choice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pes_button = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // pes_button
            // 
            pes_button.Location = new Point(309, 68);
            pes_button.Name = "pes_button";
            pes_button.Size = new Size(109, 68);
            pes_button.TabIndex = 0;
            pes_button.Text = "Open Exercise Page";
            pes_button.UseVisualStyleBackColor = true;
            pes_button.Click += pes_button_Click;
            // 
            // button1
            // 
            button1.Location = new Point(543, 68);
            button1.Name = "button1";
            button1.Size = new Size(113, 68);
            button1.TabIndex = 1;
            button1.Text = "Open Trial End Page";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(190, 68);
            button2.Name = "button2";
            button2.Size = new Size(113, 68);
            button2.TabIndex = 2;
            button2.Text = "Open Setup Page";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(424, 68);
            button3.Name = "button3";
            button3.Size = new Size(113, 68);
            button3.TabIndex = 3;
            button3.Text = "Open Practice End Page";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(71, 68);
            button4.Name = "button4";
            button4.Size = new Size(113, 68);
            button4.TabIndex = 4;
            button4.Text = "Open Start Page";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pes_button);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button pes_button;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
