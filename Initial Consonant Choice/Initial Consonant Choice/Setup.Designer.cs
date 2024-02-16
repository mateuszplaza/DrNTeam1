
namespace Initial_Consonant_Choice
{
    partial class Setup
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
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(669, 400);
            button1.Name = "button1";
            button1.Size = new Size(119, 38);
            button1.TabIndex = 0;
            button1.Text = "Begin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(22, 409);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 1;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(63, 112);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(196, 24);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Start With Practice Mode";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(186, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(178, 27);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(51, 66);
            label1.Name = "label1";
            label1.Size = new Size(129, 28);
            label1.TabIndex = 4;
            label1.Text = "Participant ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(65, 9);
            label2.Name = "label2";
            label2.Size = new Size(95, 41);
            label2.TabIndex = 5;
            label2.Text = "Setup";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 153);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 6;
            label3.Text = "Feedback Mode";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(78, 176);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(148, 24);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Identify Response";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(78, 206);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(133, 24);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Identify Correct";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(265, 275);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(70, 27);
            numericUpDown1.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(65, 277);
            label4.Name = "label4";
            label4.Size = new Size(194, 20);
            label4.TabIndex = 10;
            label4.Text = "Interstimulus Interval (msec)";
            // 
            // Setup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Setup";
            Text = "Setup";
            Load += Settings_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private NumericUpDown numericUpDown1;
        private Label label4;
    }
}