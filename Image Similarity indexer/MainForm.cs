using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using Codeuctivity.ImageSharpCompare;
using System.Windows.Forms;
using MathNet.Numerics;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Image_Similarity_indexer
{
    public partial class MainForm : Form
    {
        List<ImageHash> imageHashes = new List<ImageHash>();
        List<ImageSimilarityIndex> imageSimilarityIndices = new List<ImageSimilarityIndex>();
        StopwatchElement stopwatch;
        int displayedIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            stopwatch = new StopwatchElement(toolStripStatusLabelElapsedMiliseconds);
        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                stopwatch.Start();

                //make the list of images to analyse in the folder
                List<FileInfo> imageFiles = new List<FileInfo>();
                imageFiles = GetAllImageInFolder(folderBrowserDialog.SelectedPath, checkBoxAnalyseSubfolder.Checked);

                //group the images by extention and show how many of each there are
                var groupedFiles = imageFiles.GroupBy(file => file.Extension.ToLower());

                foreach (FileInfo file in imageFiles)
                {
                    imageHashes.Add(new ImageHash { imagePath = file.FullName });
                }

                stopwatch.Stop();
                labelFolderDetails.Text = $"{imageFiles.Count} image(s) in total\n{GroupsByExtention(groupedFiles)}";
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

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                stopwatch.Start();

                //calculate hash for all images in imageHashes
                if (imageHashes.Count == 0)
                    throw new Exception("No images were selected");

                int pixelsWide = 50;

                progressBar1.Value = 0;
                progressBar1.Maximum = imageHashes.Count;

                await Task.Run(() =>
                {
                    Parallel.ForEach(
                        imageHashes,
                        new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                        imageHash =>
                    {
                        ImageToHash(ref imageHash, pixelsWide);
                        progressBar1.Invoke(() =>
                        {
                            progressBar1.Value += 1;
                        });
                    });
                });

                imageSimilarityIndices = new List<ImageSimilarityIndex>();

                for (int i = 0; i < imageHashes.Count; i++)
                {
                    for (int j = i + 1; j < imageHashes.Count; j++)
                    {
                        imageSimilarityIndices.Add(new ImageSimilarityIndex()
                        {
                            imageHash1 = imageHashes[i],
                            imageHash2 = imageHashes[j]
                        });
                    }
                }

                progressBar2.Value = 0;
                progressBar2.Maximum = imageSimilarityIndices.Count;

                await Task.Run(() =>
                {
                    Parallel.ForEach(
                        imageSimilarityIndices,
                        new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                        imageSimilarityIndex =>
                        {
                            CalculateHashSimilarity(ref imageSimilarityIndex);
                            progressBar2.Invoke(() =>
                            {
                                progressBar2.Value += 1;
                            });
                        });
                });

                imageSimilarityIndices = imageSimilarityIndices.OrderByDescending(x => x.similarity).ToList();

                stopwatch.Stop();

                DisplayImagesOfIndex();

                //MessageBox.Show($"{stopwatch.ElapsedMiliseconds} ms");





                //ImageSimilarityIndex imageSimilarityIndex = new ImageSimilarityIndex()
                //{
                //    imageHash1 = new ImageHash()
                //    {
                //        imagePath = @"D:\My Pictures\Wallpapers\__original_drawn_by_kazami_kuroro__sample-bfa02104b3b48ba3c485e0b85309c35e.jpg"
                //    },
                //    imageHash2 = new ImageHash()
                //    {
                //        imagePath = @"D:\My Pictures\Wallpapers\6f66681b78ce2287fc60effcc04805bf.jpg"
                //    }
                //};

                //


                //ImageToHash(ref imageSimilarityIndex.imageHash1, pixelsWide);
                //ImageToHash(ref imageSimilarityIndex.imageHash2, pixelsWide);

                ////compare image hashes
                //imageSimilarityIndex.similarity = CalculateHashSimilarity(imageSimilarityIndex.imageHash1.hash, imageSimilarityIndex.imageHash2.hash);

                //
                //imageSimilarityIndex.elapsedMS = stopwatch.ElapsedMiliseconds;

                //MessageBox.Show($"{imageSimilarityIndex.similarity.ToString("0.000")}%\n{imageSimilarityIndex.elapsedMS} ms");
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void ImageToHash(ref ImageHash imageHash, int resolution)
        {
            imageHash.resolution = resolution;
            //load in the image

            Bitmap image1 = new Bitmap(imageHash.imagePath);

            //resize the images
            Bitmap imageSmaller = new Bitmap(image1, resolution, resolution);

            //greyscale the images
            Bitmap imageGrey = MakeGrayscale(imageSmaller);

            //hash the image
            imageHash.hash = MakeHashedString(imageGrey);


            //clean momory because it could overwhelm the RAM
            image1.Dispose();
            imageSmaller.Dispose();
            imageGrey.Dispose();
            //GC.Collect();
        }

        private void CalculateHashSimilarity(ref ImageSimilarityIndex imageSimilarityIndex)
        {
            double length = imageSimilarityIndex.imageHash1.hash.Length;
            double matches = 0;

            for (int i = 0; i < length; i++)
            {
                char c1 = imageSimilarityIndex.imageHash1.hash[i];
                char c2 = imageSimilarityIndex.imageHash2.hash[i];

                if (c1 == c2)
                {
                    matches++;
                }
            }

            imageSimilarityIndex.similarity = matches / length * 100;
        }
        private void DisplayImagesOfIndex()
        {
            if (imageSimilarityIndices.Count == 0)
            {
                pictureBox1.BackgroundImage = pictureBox2.BackgroundImage = null;
                labelIndexDetails.ResetText();
                return;
            }

            if (displayedIndex < 0)
            {
                displayedIndex = imageSimilarityIndices.Count - 1;
            }
            else if (displayedIndex >= imageSimilarityIndices.Count)
            {
                displayedIndex = 0;
            }

            pictureBox1.BackgroundImage = new Bitmap(imageSimilarityIndices[displayedIndex].imageHash1.imagePath);
            pictureBox2.BackgroundImage = new Bitmap(imageSimilarityIndices[displayedIndex].imageHash2.imagePath);
            labelIndexDetails.Text = $"{imageSimilarityIndices[displayedIndex].similarity.ToString("0.000")} %";
        }

        private string MakeHashedString(Bitmap original)
        {
            string hashValue = "";

            for (int i = 0; i < original.Height - 1; i++)
            {
                for (int j = 0; j < original.Width - 1; j++)
                {
                    int pixel1 = original.GetPixel(i, j).R;
                    int pixel2 = original.GetPixel(i, j + 1).R;

                    if (pixel1 >= pixel2)
                    {
                        hashValue += "1";
                    }
                    else
                    {
                        hashValue += "0";
                    }
                }
            }
            return hashValue;
        }

        private Bitmap MakeHashedImage(Bitmap original)
        {
            Bitmap newBitmap = new Bitmap(original.Width - 1, original.Height - 1);

            for (int i = 0; i < newBitmap.Height; i++)
            {
                for (int j = 0; j < newBitmap.Width; j++)
                {
                    int pixel1 = original.GetPixel(i, j).R;
                    int pixel2 = original.GetPixel(i, j + 1).R;

                    if (pixel1 >= pixel2)
                    {
                        newBitmap.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        newBitmap.SetPixel(i, j, Color.Black);
                    }
                }
            }
            return newBitmap;
        }

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

                //create the grayscale ColorMatrix
                ColorMatrix colorMatrix = new ColorMatrix(
                   new float[][]
                   {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
                   });

                //create some image attributes
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }


        partial class ImageSimilarityIndex
        {
            public ImageHash imageHash1,
                imageHash2;
            public double similarity;
        }
        partial class ImageHash
        {
            public string imagePath,
                hash;
            public int resolution;
        }
        partial class StopwatchElement
        {
            private Stopwatch? timer;
            ToolStripLabel toolStripLabel;

            public StopwatchElement(ToolStripLabel toolStripLabel)
            {
                timer = new Stopwatch();
                this.toolStripLabel = toolStripLabel;
            }

            public void Start()
            {
                timer = new Stopwatch();
                timer.Start();
            }

            public void Stop()
            {
                if (timer == null || !timer.IsRunning)
                    return;

                timer.Stop();
                toolStripLabel.Text = $"{timer.ElapsedMilliseconds} ms";
            }

            public long ElapsedMiliseconds
            {
                get
                {
                    if (timer == null)
                        return 0;

                    return timer.ElapsedMilliseconds;
                }
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            displayedIndex--;
            DisplayImagesOfIndex();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            displayedIndex++;
            DisplayImagesOfIndex();
        }
    }
}