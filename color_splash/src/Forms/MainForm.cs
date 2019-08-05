using ColorSplash.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ColorSplash.Forms {
    public partial class MainForm : Form {

        private OpenFileDialog fileChooser;
        private ImageProcessor processor;

        private Dictionary<string, int[]> hash;
        private string path;

        public MainForm() {

            InitializeComponent();

            processor = new ImageProcessor();

            hash = new Dictionary<string, int[]>();
            hash.Add("Red", ImageProcessor.RED);
            hash.Add("Orange-Yellow", ImageProcessor.ORANGE_YELLOW);
            hash.Add("Green", ImageProcessor.GREEN);
            hash.Add("Blue", ImageProcessor.BLUE);
            hash.Add("Purple-Pink", ImageProcessor.PURPLE_PINK);

            fileChooser = new OpenFileDialog();
            //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileChooser.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
            if (fileChooser.ShowDialog() == DialogResult.OK) {
                path = fileChooser.FileName;
                pictureBox1.Image = Image.FromFile(path);

                processor.Image = null;
            }
        }

        private void ColorChooser_SelectedIndexChanged(object sender, EventArgs e) {
            if (processor.Image != null)
                pictureBox1.Image = processor.Image;

            SendKeys.Send("{ESC}");
        }


        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (processor.buffer != null) {
                string format = path.Substring(path.Length - 3);

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = format + " files (*." + format + ")|*." + format;

                bool noException = true;

                if (dialog.ShowDialog() == DialogResult.OK) {
                    try {
                        processor.buffer.Save(dialog.FileName);
                    } catch (ArgumentNullException) {
                        snackbar.show("Please specıfy a fıle name", 2f);
                        noException = false;
                    } catch (ExternalException) {
                        snackbar.show("Fıle format ıs not suıtable", 2f);
                        noException = false;
                    }
                }

                if (noException)
                    snackbar.show("Fıle saved successfully", 1.5f);

            }
        }

        private void showOriginal_Click(object sender, EventArgs e) {
            if (processor.Image != null) {
                pictureBox1.Image = processor.Image;
                pictureBox1.Update();
            }
        }

        private void showHighlighted_Click(object sender, EventArgs e) {
            if (processor.buffer != null) {
                pictureBox1.Image = processor.buffer;
                pictureBox1.Update();
            } else {
                Console.WriteLine("Null");
            }
        }

        private void highlight_Click(object sender, EventArgs e) {
            if (pictureBox1.Image != null && pictureBox1.Image != processor.buffer) {
                processor.Image = (Bitmap)pictureBox1.Image;

                Bitmap newBmp = processor.HighlightColor(hash[colorChooser.Text]);
                pictureBox1.Image = newBmp;

                pictureBox1.Update();
            } else {
                Console.WriteLine("Resim yok ?");
            }
        }

        private void HighSensitivityToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;

            lowSensitivityToolStripMenuItem.Checked = false;
            normalSensitivityToolStripMenuItem.Checked = false;

            processor.sensivity = ImageProcessor.HIGH;
            snackbar.show("Sensıvıty level set to hıgh", 1.3f);

            if (processor.Image != null)
                pictureBox1.Image = processor.Image; //For higlighting with another sensivity
        }

        private void NormalSensitivityToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;

            highSensitivityToolStripMenuItem.Checked = false;
            lowSensitivityToolStripMenuItem.Checked = false;

            processor.sensivity = ImageProcessor.NORMAL;
            snackbar.show("Sensıvıty level set to normal", 1.3f);

            if (processor.Image != null)
                pictureBox1.Image = processor.Image; //For higlighting with another sensivity
        }

        private void LowSensitivityToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;

            highSensitivityToolStripMenuItem.Checked = false;
            normalSensitivityToolStripMenuItem.Checked = false;

            processor.sensivity = ImageProcessor.LOW;
            snackbar.show("Sensıvıty level set to low", 1.3f);

            if (processor.Image != null)
                pictureBox1.Image = processor.Image; //For higlighting with another sensivity
        }
    }
}
