namespace Image_Similarity_indexer
{
    partial class MainForm
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
            tabControl1 = new TabControl();
            tabPageDetails = new TabPage();
            progressBar2 = new ProgressBar();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            labelFolderDetails = new Label();
            label2 = new Label();
            buttonSelectFolder = new Button();
            checkBoxAnalyseSubfolder = new CheckBox();
            label1 = new Label();
            tabPageComparison = new TabPage();
            labelIndexDetails = new Label();
            buttonNext = new Button();
            buttonPrevious = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelElapsedMiliseconds = new ToolStripStatusLabel();
            tabControl1.SuspendLayout();
            tabPageDetails.SuspendLayout();
            tabPageComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDetails);
            tabControl1.Controls.Add(tabPageComparison);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1329, 637);
            tabControl1.TabIndex = 0;
            // 
            // tabPageDetails
            // 
            tabPageDetails.Controls.Add(progressBar2);
            tabPageDetails.Controls.Add(progressBar1);
            tabPageDetails.Controls.Add(button1);
            tabPageDetails.Controls.Add(labelFolderDetails);
            tabPageDetails.Controls.Add(label2);
            tabPageDetails.Controls.Add(buttonSelectFolder);
            tabPageDetails.Controls.Add(checkBoxAnalyseSubfolder);
            tabPageDetails.Controls.Add(label1);
            tabPageDetails.Location = new Point(4, 24);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Padding = new Padding(3);
            tabPageDetails.Size = new Size(1321, 609);
            tabPageDetails.TabIndex = 0;
            tabPageDetails.Text = "Details";
            tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(10, 464);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(393, 34);
            progressBar2.TabIndex = 7;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(10, 424);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(393, 34);
            progressBar1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(10, 379);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelFolderDetails
            // 
            labelFolderDetails.AutoSize = true;
            labelFolderDetails.Location = new Point(29, 146);
            labelFolderDetails.Name = "labelFolderDetails";
            labelFolderDetails.Size = new Size(167, 15);
            labelFolderDetails.TabIndex = 4;
            labelFolderDetails.Text = "A folder was not yet selected...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 121);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 3;
            label2.Text = "Details of folder";
            // 
            // buttonSelectFolder
            // 
            buttonSelectFolder.Location = new Point(29, 70);
            buttonSelectFolder.Name = "buttonSelectFolder";
            buttonSelectFolder.Size = new Size(99, 31);
            buttonSelectFolder.TabIndex = 2;
            buttonSelectFolder.Text = "Select Folder";
            buttonSelectFolder.UseVisualStyleBackColor = true;
            buttonSelectFolder.Click += buttonSelectFolder_Click;
            // 
            // checkBoxAnalyseSubfolder
            // 
            checkBoxAnalyseSubfolder.AutoSize = true;
            checkBoxAnalyseSubfolder.Location = new Point(29, 30);
            checkBoxAnalyseSubfolder.Name = "checkBoxAnalyseSubfolder";
            checkBoxAnalyseSubfolder.Size = new Size(197, 34);
            checkBoxAnalyseSubfolder.TabIndex = 1;
            checkBoxAnalyseSubfolder.Text = "Analyse all subfolders too \r\n(this will slow down the process)";
            checkBoxAnalyseSubfolder.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 12);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 0;
            label1.Text = "Select a folder to analyse";
            // 
            // tabPageComparison
            // 
            tabPageComparison.Controls.Add(labelIndexDetails);
            tabPageComparison.Controls.Add(buttonNext);
            tabPageComparison.Controls.Add(buttonPrevious);
            tabPageComparison.Controls.Add(pictureBox2);
            tabPageComparison.Controls.Add(pictureBox1);
            tabPageComparison.Location = new Point(4, 24);
            tabPageComparison.Name = "tabPageComparison";
            tabPageComparison.Padding = new Padding(3);
            tabPageComparison.Size = new Size(1321, 609);
            tabPageComparison.TabIndex = 1;
            tabPageComparison.Text = "Comparison";
            tabPageComparison.UseVisualStyleBackColor = true;
            // 
            // labelIndexDetails
            // 
            labelIndexDetails.AutoSize = true;
            labelIndexDetails.Location = new Point(419, 18);
            labelIndexDetails.Name = "labelIndexDetails";
            labelIndexDetails.Size = new Size(38, 15);
            labelIndexDetails.TabIndex = 4;
            labelIndexDetails.Text = "000 %";
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(844, 392);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(75, 23);
            buttonNext.TabIndex = 3;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonPrevious
            // 
            buttonPrevious.Location = new Point(3, 392);
            buttonPrevious.Name = "buttonPrevious";
            buttonPrevious.Size = new Size(75, 23);
            buttonPrevious.TabIndex = 2;
            buttonPrevious.Text = "Previous";
            buttonPrevious.UseVisualStyleBackColor = true;
            buttonPrevious.Click += buttonPrevious_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(547, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(372, 383);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(372, 383);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelElapsedMiliseconds });
            statusStrip1.Location = new Point(0, 615);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1329, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelElapsedMiliseconds
            // 
            toolStripStatusLabelElapsedMiliseconds.Name = "toolStripStatusLabelElapsedMiliseconds";
            toolStripStatusLabelElapsedMiliseconds.Size = new Size(32, 17);
            toolStripStatusLabelElapsedMiliseconds.Text = "0 ms";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 637);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Similarity Indexer";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabPageDetails.ResumeLayout(false);
            tabPageDetails.PerformLayout();
            tabPageComparison.ResumeLayout(false);
            tabPageComparison.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageDetails;
        private TabPage tabPageComparison;
        private Label labelFolderDetails;
        private Label label2;
        private Button buttonSelectFolder;
        private CheckBox checkBoxAnalyseSubfolder;
        private Label label1;
        private Button button1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelElapsedMiliseconds;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Button buttonNext;
        private Button buttonPrevious;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label labelIndexDetails;
    }
}