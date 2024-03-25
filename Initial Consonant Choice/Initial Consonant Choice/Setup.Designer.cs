
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
            label5 = new Label();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(585, 300);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(104, 28);
            button1.TabIndex = 0;
            button1.Text = "Begin";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(19, 307);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 1;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(55, 84);
            checkBox1.Margin = new Padding(3, 2, 3, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(157, 19);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Start With Practice Mode";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(163, 50);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(45, 50);
            label1.Name = "label1";
            label1.Size = new Size(102, 21);
            label1.TabIndex = 4;
            label1.Text = "Participant ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(57, 7);
            label2.Name = "label2";
            label2.Size = new Size(76, 32);
            label2.TabIndex = 5;
            label2.Text = "Setup";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 115);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 6;
            label3.Text = "Feedback Mode";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(68, 132);
            checkBox2.Margin = new Padding(3, 2, 3, 2);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(119, 19);
            checkBox2.TabIndex = 7;
            checkBox2.Text = "Identify Response";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(68, 155);
            checkBox3.Margin = new Padding(3, 2, 3, 2);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(108, 19);
            checkBox3.TabIndex = 8;
            checkBox3.Text = "Identify Correct";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.Location = new Point(230, 192);
            numericUpDown1.Margin = new Padding(3, 2, 3, 2);
            numericUpDown1.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(61, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 194);
            label4.Name = "label4";
            label4.Size = new Size(157, 15);
            label4.TabIndex = 10;
            label4.Text = "Interstimulus Interval (msec)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 226);
            label5.Name = "label5";
            label5.Size = new Size(143, 15);
            label5.TabIndex = 12;
            label5.Text = "Reinforcement Frequency";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(230, 224);
            numericUpDown2.Margin = new Padding(3, 2, 3, 2);
            numericUpDown2.Maximum = new decimal(new int[] { 48, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(61, 23);
            numericUpDown2.TabIndex = 11;
            numericUpDown2.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // Setup
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(700, 338);
            Controls.Add(label5);
            Controls.Add(numericUpDown2);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "Setup";
            Text = "Setup";
            Load += Settings_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label5;
        private NumericUpDown numericUpDown2;
    }
}