using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace color_splash
{
    public partial class Form1 : Form {

        private OpenFileDialog fileChooser;
        private ImageHandler handler;

        private Dictionary<string, int[]> hash;
        private string path;

        public Form1() {
            InitializeComponent();

            handler = new ImageHandler();

            hash = new Dictionary<string, int[]>();
            hash.Add("Red", ImageHandler.RED);
            hash.Add("Orange-Yellow", ImageHandler.ORANGE_YELLOW);
            hash.Add("Green", ImageHandler.GREEN);
            hash.Add("Blue", ImageHandler.BLUE);
            hash.Add("Purple-Pink", ImageHandler.PURPLE_PINK);

            fileChooser = new OpenFileDialog();
            //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileChooser.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                path = fileChooser.FileName;
                pictureBox1.Image = Image.FromFile(path);

                handler.BMP = null;
            }
        }

        private void ToolStripContainer1_ContentPanel_Load(object sender, EventArgs e) {

        }

        private void StatusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e) {
            if (pictureBox1.Image != null && pictureBox1.Image != handler.highlightedBMP) {
                handler.BMP = (Bitmap)pictureBox1.Image;

                Bitmap newBmp = handler.HighlightColor(hash[colorChooser.Text]);
                pictureBox1.Image = newBmp;

                pictureBox1.Refresh();
                pictureBox1.Update();
            } else {
                Console.WriteLine("Resim yok ?");
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e) {
            pictureBox1.Image = handler.BMP;
            pictureBox1.Update();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e) {
            if (handler.highlightedBMP != null) {
                pictureBox1.Image = handler.highlightedBMP;
                pictureBox1.Update();
            } else {
                Console.WriteLine("Null");
            }
        }

        private void ColorChooser_SelectedIndexChanged(object sender, EventArgs e) {
            if (handler.BMP != null)
                pictureBox1.Image = handler.BMP;
        }

        private void HighSensitivityToolStripMenuItem_CheckStateChanged(object sender, EventArgs e) {
            ToolStripMenuItem item = (ToolStripMenuItem) sender;
            handler.isSensitive = item.Checked;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (handler.highlightedBMP != null) {
                Console.WriteLine(path);
                
                handler.BMP.Dispose();
                pictureBox1.Image.Dispose();
                handler.highlightedBMP.Save(path);
                handler.highlightedBMP.Dispose();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (handler.highlightedBMP != null) {
                string format = path.Substring(path.Length - 3);

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = format + " files (*."+format+")|*."+format;

                if (dialog.ShowDialog() == DialogResult.OK) {
                    handler.highlightedBMP.Save(dialog.FileName);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

    }
}
