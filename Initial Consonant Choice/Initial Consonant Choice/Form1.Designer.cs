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
            SuspendLayout();
            // 
            // pes_button
            // 
            pes_button.Location = new Point(83, 265);
            pes_button.Name = "pes_button";
            pes_button.Size = new Size(109, 68);
            pes_button.TabIndex = 0;
            pes_button.Text = "Open Participant Exercise screen";
            pes_button.UseVisualStyleBackColor = true;
            pes_button.Click += pes_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pes_button);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button pes_button;
    }
}
