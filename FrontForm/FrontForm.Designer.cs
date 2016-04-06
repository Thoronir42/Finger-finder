using FingerFinder;
using FingerprintAnalyzer;

namespace FingerFinder
{
    partial class FrontForm
    {
        Analyzer Analyzer { get; set; }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuStripItem_soubor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItem_open = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripItem_import = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStripItem_close = new System.Windows.Forms.ToolStripMenuItem();
            this.analýzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detekcemarkantůToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klasifikaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_fingerPrint = new System.Windows.Forms.Panel();
            this.imageOpener = new System.Windows.Forms.OpenFileDialog();
            this.tabs_typeSelect = new System.Windows.Forms.TabControl();
            this.tabPage_original = new System.Windows.Forms.TabPage();
            this.tabPage_skeleton = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip.SuspendLayout();
            this.tabs_typeSelect.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripItem_soubor,
            this.analýzaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(809, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuStripItem_soubor
            // 
            this.MenuStripItem_soubor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItem_open,
            this.menuStripSeparator1,
            this.menuStripItem_import,
            this.menuStripSeparator2,
            this.menuStripItem_close});
            this.MenuStripItem_soubor.Name = "MenuStripItem_soubor";
            this.MenuStripItem_soubor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.MenuStripItem_soubor.Size = new System.Drawing.Size(69, 24);
            this.MenuStripItem_soubor.Text = "&Soubor";
            // 
            // menuStripItem_open
            // 
            this.menuStripItem_open.Name = "menuStripItem_open";
            this.menuStripItem_open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuStripItem_open.Size = new System.Drawing.Size(182, 26);
            this.menuStripItem_open.Text = "Otevřít";
            this.menuStripItem_open.Click += new System.EventHandler(this.otevřítToolStripMenuItem_Click);
            // 
            // menuStripSeparator1
            // 
            this.menuStripSeparator1.Name = "menuStripSeparator1";
            this.menuStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // menuStripItem_import
            // 
            this.menuStripItem_import.Name = "menuStripItem_import";
            this.menuStripItem_import.Size = new System.Drawing.Size(182, 26);
            this.menuStripItem_import.Text = "Import";
            this.menuStripItem_import.Click += new System.EventHandler(this.menuStripItem_import_Click);
            // 
            // menuStripSeparator2
            // 
            this.menuStripSeparator2.Name = "menuStripSeparator2";
            this.menuStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // menuStripItem_close
            // 
            this.menuStripItem_close.Name = "menuStripItem_close";
            this.menuStripItem_close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menuStripItem_close.Size = new System.Drawing.Size(182, 26);
            this.menuStripItem_close.Text = "Zavřít";
            this.menuStripItem_close.Click += new System.EventHandler(this.menuStripItem_close_Click);
            // 
            // analýzaToolStripMenuItem
            // 
            this.analýzaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detekcemarkantůToolStripMenuItem,
            this.klasifikaceToolStripMenuItem});
            this.analýzaToolStripMenuItem.Name = "analýzaToolStripMenuItem";
            this.analýzaToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.analýzaToolStripMenuItem.Text = "&Analýza";
            // 
            // detekcemarkantůToolStripMenuItem
            // 
            this.detekcemarkantůToolStripMenuItem.Name = "detekcemarkantůToolStripMenuItem";
            this.detekcemarkantůToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.detekcemarkantůToolStripMenuItem.Text = "Detekce &markantů";
            // 
            // klasifikaceToolStripMenuItem
            // 
            this.klasifikaceToolStripMenuItem.Name = "klasifikaceToolStripMenuItem";
            this.klasifikaceToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.klasifikaceToolStripMenuItem.Text = "&Klasifikace";
            // 
            // panel_fingerPrint
            // 
            this.panel_fingerPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_fingerPrint.Location = new System.Drawing.Point(12, 56);
            this.panel_fingerPrint.Name = "panel_fingerPrint";
            this.panel_fingerPrint.Size = new System.Drawing.Size(420, 420);
            this.panel_fingerPrint.TabIndex = 1;
            // 
            // imageOpener
            // 
            this.imageOpener.FileName = "Obraz otisku";
            this.imageOpener.Filter = "TIF|*.tif|JPG|*.jpg|PNG|*.png";
            this.imageOpener.FileOk += new System.ComponentModel.CancelEventHandler(this.imageOpener_FileOk);
            // 
            // tabs_typeSelect
            // 
            this.tabs_typeSelect.Controls.Add(this.tabPage_original);
            this.tabs_typeSelect.Controls.Add(this.tabPage_skeleton);
            this.tabs_typeSelect.Location = new System.Drawing.Point(12, 31);
            this.tabs_typeSelect.Name = "tabs_typeSelect";
            this.tabs_typeSelect.SelectedIndex = 0;
            this.tabs_typeSelect.Size = new System.Drawing.Size(420, 24);
            this.tabs_typeSelect.TabIndex = 0;
            this.tabs_typeSelect.SelectedIndexChanged += new System.EventHandler(this.tabs_typeSelect_SelectedIndexChanged);
            // 
            // tabPage_original
            // 
            this.tabPage_original.Location = new System.Drawing.Point(4, 25);
            this.tabPage_original.Name = "tabPage_original";
            this.tabPage_original.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_original.Size = new System.Drawing.Size(412, 0);
            this.tabPage_original.TabIndex = 0;
            this.tabPage_original.Text = "Otisk originál";
            this.tabPage_original.UseVisualStyleBackColor = true;
            // 
            // tabPage_skeleton
            // 
            this.tabPage_skeleton.Location = new System.Drawing.Point(4, 25);
            this.tabPage_skeleton.Name = "tabPage_skeleton";
            this.tabPage_skeleton.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_skeleton.Size = new System.Drawing.Size(412, 0);
            this.tabPage_skeleton.TabIndex = 1;
            this.tabPage_skeleton.Text = "Otisk skeleton";
            this.tabPage_skeleton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(438, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(359, 421);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(351, 392);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(351, 392);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FrontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 491);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabs_typeSelect);
            this.Controls.Add(this.panel_fingerPrint);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FrontForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finger finder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrontForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabs_typeSelect.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuStripItem_soubor;
        private System.Windows.Forms.ToolStripMenuItem menuStripItem_open;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuStripItem_close;
        private System.Windows.Forms.Panel panel_fingerPrint;
        private System.Windows.Forms.ToolStripMenuItem analýzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detekcemarkantůToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klasifikaceToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog imageOpener;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuStripItem_import;
        private System.Windows.Forms.TabControl tabs_typeSelect;
        private System.Windows.Forms.TabPage tabPage_original;
        private System.Windows.Forms.TabPage tabPage_skeleton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

