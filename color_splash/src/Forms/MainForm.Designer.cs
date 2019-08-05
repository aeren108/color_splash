﻿using ColorSplash.Properties;
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.colorChooser = new System.Windows.Forms.ToolStripComboBox();
            this.showOriginal = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.snackbar = new ColorSplash.UI.Snackbar();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(26)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1045, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highSensitivityToolStripMenuItem,
            this.normalSensitivityToolStripMenuItem,
            this.lowSensitivityToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // highSensitivityToolStripMenuItem
            // 
            this.highSensitivityToolStripMenuItem.Name = "highSensitivityToolStripMenuItem";
            this.highSensitivityToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.highSensitivityToolStripMenuItem.Text = "High Sensitivity";
            this.highSensitivityToolStripMenuItem.Click += new System.EventHandler(this.HighSensitivityToolStripMenuItem_Click);
            // 
            // normalSensitivityToolStripMenuItem
            // 
            this.normalSensitivityToolStripMenuItem.Checked = true;
            this.normalSensitivityToolStripMenuItem.CheckOnClick = true;
            this.normalSensitivityToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalSensitivityToolStripMenuItem.Name = "normalSensitivityToolStripMenuItem";
            this.normalSensitivityToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.normalSensitivityToolStripMenuItem.Text = "Normal Sensitivity";
            this.normalSensitivityToolStripMenuItem.Click += new System.EventHandler(this.NormalSensitivityToolStripMenuItem_Click);
            // 
            // lowSensitivityToolStripMenuItem
            // 
            this.lowSensitivityToolStripMenuItem.Name = "lowSensitivityToolStripMenuItem";
            this.lowSensitivityToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.lowSensitivityToolStripMenuItem.Text = "Low Sensitivity";
            this.lowSensitivityToolStripMenuItem.Click += new System.EventHandler(this.LowSensitivityToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showHelpToolStripMenuItem
            // 
            this.showHelpToolStripMenuItem.Name = "showHelpToolStripMenuItem";
            this.showHelpToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.showHelpToolStripMenuItem.Text = "Show Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(26)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.colorChooser,
            this.showOriginal,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(1045, 28);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(26)))));
            this.toolStripButton1.CheckOnClick = true;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(115, 25);
            this.toolStripButton1.Text = "Highlight Color";
            this.toolStripButton1.Click += new System.EventHandler(this.highlight_Click);
            // 
            // colorChooser
            // 
            this.colorChooser.AutoCompleteCustomSource.AddRange(new string[] {
            "Red",
            "Orange-Yellow",
            "Green",
            "Blue",
            "Purple-Pink"});
            this.colorChooser.BackColor = System.Drawing.Color.White;
            this.colorChooser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorChooser.DropDownWidth = 110;
            this.colorChooser.Items.AddRange(new object[] {
            "Red",
            "Orange-Yellow",
            "Green",
            "Blue",
            "Purple-Pink"});
            this.colorChooser.SelectedIndex = 0;
            this.colorChooser.Margin = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.colorChooser.Name = "colorChooser";
            this.colorChooser.Size = new System.Drawing.Size(159, 28);
            this.colorChooser.SelectedIndexChanged += new System.EventHandler(this.ColorChooser_SelectedIndexChanged);
            // 
            // showOriginal
            // 
            this.showOriginal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(26)))));
            this.showOriginal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showOriginal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showOriginal.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.showOriginal.Name = "showOriginal";
            this.showOriginal.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.showOriginal.Size = new System.Drawing.Size(116, 25);
            this.showOriginal.Text = "Show Original";
            this.showOriginal.Click += new System.EventHandler(this.showOriginal_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(159)))), ((int)(((byte)(26)))));
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(132, 25);
            this.toolStripButton3.Text = "Show Highlighted";
            this.toolStripButton3.Click += new System.EventHandler(this.showHighlighted_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::color_splash.Properties.Resources.instructions;
            this.pictureBox1.Location = new System.Drawing.Point(16, 73);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1013, 652);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // snackbar
            // 
            this.snackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.snackbar.Location = new System.Drawing.Point(0, 683);
            this.snackbar.Name = "snackbar";
            this.snackbar.Size = new System.Drawing.Size(1045, 57);
            this.snackbar.TabIndex = 4;
            this.snackbar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 740);
            this.Controls.Add(this.snackbar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Color Splash v1.0";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox colorChooser;
        private System.Windows.Forms.ToolStripButton showOriginal;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private ToolStripMenuItem highSensitivityToolStripMenuItem;
        private ToolStripMenuItem normalSensitivityToolStripMenuItem;
        private ToolStripMenuItem lowSensitivityToolStripMenuItem;
        private BackgroundWorker backgroundWorker1;
        private Snackbar snackbar;
    }
}

