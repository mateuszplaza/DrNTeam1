namespace Initial_Consonant_Choice
{
    partial class TrialEndScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button quitButton;
        private Button practiceAgainButton;
        private Button continueButton;

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
            ButtonsPanel = new TableLayoutPanel();
            SaveAndQuitButton = new Button();
            SaveAndReturnButton = new Button();
            Page = new FlowLayoutPanel();
            FormTablePanel = new TableLayoutPanel();
            FilePanel = new TableLayoutPanel();
            SaveResultsTo = new Label();
            FilePathTextbox = new TextBox();
            BrowseButton = new Button();
            Title = new Label();
            folderBrowserDialog = new FolderBrowserDialog();
            ButtonsPanel.SuspendLayout();
            FormTablePanel.SuspendLayout();
            FilePanel.SuspendLayout();
            SuspendLayout();
            // 
            // ButtonsPanel
            // 
            ButtonsPanel.AutoSize = true;
            ButtonsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonsPanel.ColumnCount = 3;
            ButtonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ButtonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ButtonsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            ButtonsPanel.Controls.Add(SaveAndQuitButton, 1, 0);
            ButtonsPanel.Controls.Add(SaveAndReturnButton, 0, 0);
            ButtonsPanel.Location = new Point(10, 387);
            ButtonsPanel.Margin = new Padding(10);
            ButtonsPanel.Name = "ButtonsPanel";
            ButtonsPanel.Padding = new Padding(10);
            ButtonsPanel.RowCount = 1;
            ButtonsPanel.RowStyles.Add(new RowStyle());
            ButtonsPanel.Size = new Size(629, 70);
            ButtonsPanel.TabIndex = 4;
            // 
            // SaveAndQuitButton
            // 
            SaveAndQuitButton.AutoSize = true;
            SaveAndQuitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveAndQuitButton.Dock = DockStyle.Top;
            SaveAndQuitButton.Location = new Point(243, 10);
            SaveAndQuitButton.Margin = new Padding(30, 0, 30, 0);
            SaveAndQuitButton.MinimumSize = new Size(100, 50);
            SaveAndQuitButton.Name = "SaveAndQuitButton";
            SaveAndQuitButton.Size = new Size(143, 50);
            SaveAndQuitButton.TabIndex = 2;
            SaveAndQuitButton.Text = "Save and Quit";
            SaveAndQuitButton.UseVisualStyleBackColor = true;
            SaveAndQuitButton.Click += SaveAndQuitButton_Click;
            // 
            // MainMenuButton
            // 
            SaveAndReturnButton.AutoSize = true;
            SaveAndReturnButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SaveAndReturnButton.Dock = DockStyle.Top;
            SaveAndReturnButton.Location = new Point(40, 10);
            SaveAndReturnButton.Margin = new Padding(30, 0, 30, 0);
            SaveAndReturnButton.MinimumSize = new Size(100, 50);
            SaveAndReturnButton.Name = "MainMenuButton";
            SaveAndReturnButton.Size = new Size(143, 50);
            SaveAndReturnButton.TabIndex = 0;
            SaveAndReturnButton.Text = "Save and Return to Start";
            SaveAndReturnButton.UseVisualStyleBackColor = true;
            SaveAndReturnButton.Click += SaveAndReturnButton_Click;
            // 
            // Page
            // 
            Page.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Page.AutoSize = true;
            Page.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Page.Location = new Point(10, 10);
            Page.Name = "Page";
            Page.Size = new Size(0, 0);
            Page.TabIndex = 5;
            // 
            // FormTablePanel
            // 
            FormTablePanel.AutoSize = true;
            FormTablePanel.ColumnCount = 1;
            FormTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            FormTablePanel.Controls.Add(ButtonsPanel, 0, 3);
            FormTablePanel.Controls.Add(FilePanel, 0, 1);
            FormTablePanel.Controls.Add(Title, 0, 0);
            FormTablePanel.Dock = DockStyle.Fill;
            FormTablePanel.Location = new Point(10, 10);
            FormTablePanel.Name = "FormTablePanel";
            FormTablePanel.RowCount = 4;
            FormTablePanel.RowStyles.Add(new RowStyle());
            FormTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            FormTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            FormTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            FormTablePanel.Size = new Size(715, 477);
            FormTablePanel.TabIndex = 6;
            // 
            // FilePanel
            // 
            FilePanel.ColumnCount = 3;
            FilePanel.ColumnStyles.Add(new ColumnStyle());
            FilePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            FilePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            FilePanel.Controls.Add(SaveResultsTo, 0, 0);
            FilePanel.Controls.Add(FilePathTextbox, 1, 0);
            FilePanel.Controls.Add(BrowseButton, 2, 0);
            FilePanel.Location = new Point(3, 48);
            FilePanel.Name = "FilePanel";
            FilePanel.RowCount = 1;
            FilePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            FilePanel.Size = new Size(400, 94);
            FilePanel.TabIndex = 7;
            // 
            // SaveResultsTo
            // 
            SaveResultsTo.Location = new Point(3, 3);
            SaveResultsTo.Margin = new Padding(3);
            SaveResultsTo.Name = "SaveResultsTo";
            SaveResultsTo.Padding = new Padding(3);
            SaveResultsTo.Size = new Size(97, 35);
            SaveResultsTo.TabIndex = 6;
            SaveResultsTo.Text = "Save Results to:";
            // 
            // FilePathTextbox
            // 
            FilePathTextbox.Location = new Point(106, 3);
            FilePathTextbox.Name = "FilePathTextbox";
            FilePathTextbox.Size = new Size(216, 23);
            FilePathTextbox.TabIndex = 8;
            FilePathTextbox.TextChanged += FilePathTextbox_TextChanged;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(328, 3);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(69, 23);
            BrowseButton.TabIndex = 7;
            BrowseButton.Text = "Browse";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 24F);
            Title.Location = new Point(3, 0);
            Title.Name = "Title";
            Title.Size = new Size(295, 45);
            Title.TabIndex = 8;
            Title.Text = "Exercises Complete";
            // 
            // TrialEndScreen
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(735, 497);
            Controls.Add(FormTablePanel);
            Controls.Add(Page);
            MinimumSize = new Size(600, 500);
            Name = "TrialEndScreen";
            Padding = new Padding(10);
            Text = "Practice Session Complete";
            ButtonsPanel.ResumeLayout(false);
            ButtonsPanel.PerformLayout();
            FormTablePanel.ResumeLayout(false);
            FormTablePanel.PerformLayout();
            FilePanel.ResumeLayout(false);
            FilePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel ButtonsPanel;
        private Button SaveAndQuitButton;
        private Button SaveAndReturnButton;
        private FlowLayoutPanel Page;
        private TableLayoutPanel FormTablePanel;
        private Label SaveResultsTo;
        private TableLayoutPanel FilePanel;
        private Button BrowseButton;
        private TextBox FilePathTextbox;
        private FolderBrowserDialog folderBrowserDialog;
        private Label Title;
    }
}
