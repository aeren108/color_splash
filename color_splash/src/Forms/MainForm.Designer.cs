using ColorSplash.Properties;
using ColorSplash.UI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ColorSplash.Forms {
    partial class MainForm {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highSensitivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalSensitivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowSensitivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.swapButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.filterChooser = new System.Windows.Forms.ComboBox();
            this.colorChooser = new System.Windows.Forms.ComboBox();
            this.snackbar = new ColorSplash.UI.Snackbar();
            this.applyImageList = new System.Windows.Forms.ImageList(this.components);
            this.swapImageList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1176, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fileToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 28);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highSensitivityToolStripMenuItem,
            this.normalSensitivityToolStripMenuItem,
            this.lowSensitivityToolStripMenuItem});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.editToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(53, 27);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // highSensitivityToolStripMenuItem
            // 
            this.highSensitivityToolStripMenuItem.Name = "highSensitivityToolStripMenuItem";
            this.highSensitivityToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.highSensitivityToolStripMenuItem.Text = "High Sensitivity";
            this.highSensitivityToolStripMenuItem.Click += new System.EventHandler(this.HighSensitivityToolStripMenuItem_Click);
            // 
            // normalSensitivityToolStripMenuItem
            // 
            this.normalSensitivityToolStripMenuItem.Checked = true;
            this.normalSensitivityToolStripMenuItem.CheckOnClick = true;
            this.normalSensitivityToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalSensitivityToolStripMenuItem.Name = "normalSensitivityToolStripMenuItem";
            this.normalSensitivityToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.normalSensitivityToolStripMenuItem.Text = "Normal Sensitivity";
            this.normalSensitivityToolStripMenuItem.Click += new System.EventHandler(this.NormalSensitivityToolStripMenuItem_Click);
            // 
            // lowSensitivityToolStripMenuItem
            // 
            this.lowSensitivityToolStripMenuItem.Name = "lowSensitivityToolStripMenuItem";
            this.lowSensitivityToolStripMenuItem.Size = new System.Drawing.Size(231, 28);
            this.lowSensitivityToolStripMenuItem.Text = "Low Sensitivity";
            this.lowSensitivityToolStripMenuItem.Click += new System.EventHandler(this.LowSensitivityToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.helpToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(59, 27);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showHelpToolStripMenuItem
            // 
            this.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem";
            this.showHelpToolStripMenuItem.Size = new System.Drawing.Size(175, 28);
            this.showHelpToolStripMenuItem.Text = "Show Help";
            this.showHelpToolStripMenuItem.Click += new System.EventHandler(this.ShowHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(175, 28);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 111);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1140, 563);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filterChooser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.swapButton);
            this.panel1.Controls.Add(this.applyButton);
            this.panel1.Controls.Add(this.colorChooser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Oswald", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 63);
            this.panel1.TabIndex = 5;
            // 
            // swapButton
            // 
            this.swapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.swapButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.swapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.swapButton.FlatAppearance.BorderSize = 2;
            this.swapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.swapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.swapButton.ForeColor = System.Drawing.Color.White;
            this.swapButton.Location = new System.Drawing.Point(909, 9);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(150, 39);
            this.swapButton.TabIndex = 5;
            this.swapButton.Text = "Show Highlighted";
            this.swapButton.UseVisualStyleBackColor = false;
            this.swapButton.Click += new System.EventHandler(this.SwapButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.applyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.applyButton.FlatAppearance.BorderSize = 2;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Location = new System.Drawing.Point(1065, 9);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(99, 39);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // filterChooser
            // 
            this.filterChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterChooser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.filterChooser.FormattingEnabled = true;
            this.filterChooser.Items.AddRange(new object[] {
            "Red Filter",
            "Blue Filter",
            "Green Filter",
            "Grayscale",
            "Invert"});
            this.filterChooser.Location = new System.Drawing.Point(205, 9);
            this.filterChooser.Name = "filterChooser";
            this.filterChooser.Size = new System.Drawing.Size(150, 31);
            this.filterChooser.TabIndex = 3;
            this.filterChooser.SelectedIndexChanged += new System.EventHandler(this.FilterChooser_SelectedIndexChanged);
            // 
            // colorChooser
            // 
            this.colorChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorChooser.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colorChooser.FormattingEnabled = true;
            this.colorChooser.Items.AddRange(new object[] {
            "Red",
            "Orange-Yellow",
            "Green",
            "Blue",
            "Purple-Pink"});
            this.colorChooser.Location = new System.Drawing.Point(18, 9);
            this.colorChooser.Name = "colorChooser";
            this.colorChooser.Size = new System.Drawing.Size(150, 31);
            this.colorChooser.TabIndex = 1;
            this.colorChooser.SelectedIndexChanged += new System.EventHandler(this.colorChooser_SelectedIndexChanged);
            // 
            // snackbar
            // 
            this.snackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.snackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.snackbar.Location = new System.Drawing.Point(0, 649);
            this.snackbar.Name = "snackbar";
            this.snackbar.Size = new System.Drawing.Size(1176, 45);
            this.snackbar.TabIndex = 4;
            this.snackbar.Visible = false;
            // 
            // applyImageList
            // 
            this.applyImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("applyImageList.ImageStream")));
            this.applyImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.applyImageList.Images.SetKeyName(0, "apply.png");
            this.applyImageList.Images.SetKeyName(1, "icons8-picture-32.png");
            this.applyImageList.Images.SetKeyName(2, "icons8-picture-16.png");
            // 
            // swapImageList
            // 
            this.swapImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("swapImageList.ImageStream")));
            this.swapImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.swapImageList.Images.SetKeyName(0, "icons8-transfer-64.png");
            this.swapImageList.Images.SetKeyName(1, "swap1.png");
            this.swapImageList.Images.SetKeyName(2, "icons8-transfer-32.png");
            this.swapImageList.Images.SetKeyName(3, "icons8-transfer-16.png");
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(201, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Color to Highlight";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 691);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.snackbar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Color Splash v1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ToolStripMenuItem highSensitivityToolStripMenuItem;
        private ToolStripMenuItem normalSensitivityToolStripMenuItem;
        private ToolStripMenuItem lowSensitivityToolStripMenuItem;
        private BackgroundWorker backgroundWorker1;
        private Snackbar snackbar;
        private Panel panel1;
        private ComboBox filterChooser;
        private ComboBox colorChooser;
        private ImageList swapImageList;
        private ImageList applyImageList;
        private Button swapButton;
        private Button applyButton;
        private Label label2;
        private Label label1;
    }
}

