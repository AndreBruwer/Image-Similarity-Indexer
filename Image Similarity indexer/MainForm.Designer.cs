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
            labelFolderDetails = new Label();
            label2 = new Label();
            buttonSelectFolder = new Button();
            checkBoxAnalyseSubfolder = new CheckBox();
            label1 = new Label();
            tabPageComparison = new TabPage();
            tabControl1.SuspendLayout();
            tabPageDetails.SuspendLayout();
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
            tabControl1.Size = new Size(974, 609);
            tabControl1.TabIndex = 0;
            // 
            // tabPageDetails
            // 
            tabPageDetails.Controls.Add(labelFolderDetails);
            tabPageDetails.Controls.Add(label2);
            tabPageDetails.Controls.Add(buttonSelectFolder);
            tabPageDetails.Controls.Add(checkBoxAnalyseSubfolder);
            tabPageDetails.Controls.Add(label1);
            tabPageDetails.Location = new Point(4, 24);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Padding = new Padding(3);
            tabPageDetails.Size = new Size(966, 581);
            tabPageDetails.TabIndex = 0;
            tabPageDetails.Text = "Details";
            tabPageDetails.UseVisualStyleBackColor = true;
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
            tabPageComparison.Location = new Point(4, 24);
            tabPageComparison.Name = "tabPageComparison";
            tabPageComparison.Padding = new Padding(3);
            tabPageComparison.Size = new Size(966, 581);
            tabPageComparison.TabIndex = 1;
            tabPageComparison.Text = "Comparison";
            tabPageComparison.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 609);
            Controls.Add(tabControl1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Image Similarity Indexer";
            WindowState = FormWindowState.Maximized;
            tabControl1.ResumeLayout(false);
            tabPageDetails.ResumeLayout(false);
            tabPageDetails.PerformLayout();
            ResumeLayout(false);
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
    }
}