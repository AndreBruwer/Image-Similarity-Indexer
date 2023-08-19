using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Image_Similarity_indexer
{
    public partial class MainForm : Form
    {
        List<FileInfo> imageFiles = new List<FileInfo>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                //make the list of images to analyse in the folder
                imageFiles.Clear();
                imageFiles = GetAllImageInFolder(folderBrowserDialog.SelectedPath, checkBoxAnalyseSubfolder.Checked);

                //group the images by extention and show how many of each there are
                var groupedFiles = imageFiles.GroupBy(file => file.Extension.ToLower());

                stopwatch.Stop();
                labelFolderDetails.Text = $"{stopwatch.ElapsedMilliseconds} ms\n{imageFiles.Count} image(s) in total\n{GroupsByExtention(groupedFiles)}";
            }
        }

        private string GroupsByExtention(IEnumerable<IGrouping<string, FileInfo>> groupedFiles)
        {
            string groupings = "";

            foreach (var group in groupedFiles)
            {
                groupings += $"    {group.Key}: {group.Count()} file(s)\n";
            }

            return groupings;
        }

        private List<FileInfo> GetAllImageInFolder(string folderPath, bool searchSubfolders) 
        {
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            return directory.GetFiles("*.*", searchSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                .Where(file => IsImageFile(file.Extension))
                .ToList();
        }
        static bool IsImageFile(string extension)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", "tiff", "bmp", "svg" }; // Add more if needed
            return imageExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

    }
}