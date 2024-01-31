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
            button = new Button();
            input = new TextBox();
            textview = new Label();
            voicesBox = new ComboBox();
            speedBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button
            // 
            button.Location = new Point(69, 276);
            button.Name = "button";
            button.Size = new Size(95, 39);
            button.TabIndex = 0;
            button.Text = "Speak";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // input
            // 
            input.Location = new Point(116, 79);
            input.Name = "input";
            input.Size = new Size(302, 23);
            input.TabIndex = 1;
            // 
            // textview
            // 
            textview.AutoSize = true;
            textview.Location = new Point(69, 201);
            textview.Name = "textview";
            textview.Size = new Size(41, 15);
            textview.TabIndex = 2;
            textview.Text = "Voice: ";
            // 
            // voicesBox
            // 
            voicesBox.FormattingEnabled = true;
            voicesBox.Location = new Point(116, 198);
            voicesBox.Name = "voicesBox";
            voicesBox.Size = new Size(164, 23);
            voicesBox.TabIndex = 3;
            // 
            // speedBox
            // 
            speedBox.Location = new Point(116, 135);
            speedBox.Name = "speedBox";
            speedBox.Size = new Size(100, 23);
            speedBox.TabIndex = 4;
            speedBox.Text = "1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 138);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 5;
            label1.Text = "Speed:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 82);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 6;
            label2.Text = "Text:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(speedBox);
            Controls.Add(voicesBox);
            Controls.Add(textview);
            Controls.Add(input);
            Controls.Add(button);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button;
        private TextBox input;
        private Label textview;
        private ComboBox voicesBox;
        private TextBox speedBox;
        private Label label1;
        private Label label2;
    }
}
