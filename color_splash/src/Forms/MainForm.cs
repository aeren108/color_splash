using ColorSplash.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace ColorSplash.Forms {
    public partial class MainForm : Form {

        private OpenFileDialog fileChooser;
        private ImageProcessor processor;

        private Dictionary<string, int[]> colorChooserHash;
        private Dictionary<string, int> filterChooserHash;
        private string path;

        public MainForm() {

            InitializeComponent();

            processor = new ImageProcessor();

            colorChooserHash = new Dictionary<string, int[]>();
            colorChooserHash.Add("Red", ImageProcessor.RED);
            colorChooserHash.Add("Orange-Yellow", ImageProcessor.ORANGE_YELLOW);
            colorChooserHash.Add("Green", ImageProcessor.GREEN);
            colorChooserHash.Add("Blue", ImageProcessor.BLUE);
            colorChooserHash.Add("Purple-Pink", ImageProcessor.PURPLE_PINK);

            filterChooserHash = new Dictionary<string, int>();
            filterChooserHash.Add("Red Filter", ImageProcessor.RED_FILTER);
            filterChooserHash.Add("Green Filter", ImageProcessor.GREEN_FILTER);
            filterChooserHash.Add("Blue Filter", ImageProcessor.BLUE_FILTER);
            filterChooserHash.Add("Grayscale", ImageProcessor.GRAYSCALE);
            filterChooserHash.Add("Invert", ImageProcessor.INVERT);


            fileChooser = new OpenFileDialog();
            //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileChooser.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";

            this.MinimumSize = new System.Drawing.Size(650, 500);

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

        private void HighSensitivityToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;

            lowSensitivityToolStripMenuItem.Checked = false;
            normalSensitivityToolStripMenuItem.Checked = false;

            processor.sensivity = ImageProcessor.HIGH;
            snackbar.show("Sensıvıty level set to hıgh", 1.5f);

            if (processor.Image != null)
                pictureBox1.Image = processor.Image; //For higlighting with another sensivity
        }

        private void NormalSensitivityToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;

            highSensitivityToolStripMenuItem.Checked = false;
            lowSensitivityToolStripMenuItem.Checked = false;

            processor.sensivity = ImageProcessor.NORMAL;
            snackbar.show("Sensıvıty level set to normal", 1.5f);

            if (processor.Image != null)
                pictureBox1.Image = processor.Image; //For higlighting with another sensivity
        }

        private void LowSensitivityToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = true;

            highSensitivityToolStripMenuItem.Checked = false;
            normalSensitivityToolStripMenuItem.Checked = false;

            processor.sensivity = ImageProcessor.LOW;
            snackbar.show("Sensıvıty level set to low", 1.5f);

            if (processor.Image != null)
                pictureBox1.Image = processor.Image; //For higlighting with another sensivity
        }

        private void ShowHelpToolStripMenuItem_Click(object sender, EventArgs e) {
            HelpForm help = new HelpForm();
            help.Show();
        }

        private void SwapButton_Click(object sender, EventArgs e) {
            if (pictureBox1.Image == processor.buffer) {
                if (processor.Image != null) {
                    pictureBox1.Image = processor.Image;
                    pictureBox1.Update();

                    swapButton.Text = "Show Highlighted";
                    swapButton.Update();

                }
            } else if (pictureBox1.Image == processor.Image) {
                if (processor.buffer != null) {
                    pictureBox1.Image = processor.buffer;
                    pictureBox1.Update();

                    swapButton.Text = "Show Original";
                    swapButton.Update();
                }
            }
        }

        private async void ApplyButton_Click(object sender, EventArgs e) {
            if (pictureBox1.Image != null && pictureBox1.Image != processor.buffer) {
                processor.Image = (Bitmap)pictureBox1.Image;

                this.UseWaitCursor = true;
                applyButton.Enabled = false;

                Bitmap newBmp =  await processor.HighlightColor(colorChooserHash[colorChooser.Text], filterChooserHash[filterChooser.Text]);
                pictureBox1.Image = newBmp;

                this.UseWaitCursor = false;
                applyButton.Enabled = true;

                swapButton.Text = "Show Original";

                swapButton.Update();
                pictureBox1.Update();
                
            } else {
                snackbar.show("No ımage ıs uploaded", 1.3f);
            }
        }

        private void colorChooser_SelectedIndexChanged(object sender, EventArgs e) {
            if (processor.Image != null)
                pictureBox1.Image = processor.Image;

            SendKeys.SendWait("{ESC}");
        }

        private void FilterChooser_SelectedIndexChanged(object sender, EventArgs e) {
            if (processor.Image != null)
                pictureBox1.Image = processor.Image;

            SendKeys.SendWait("{ESC}");
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }
    }
}
