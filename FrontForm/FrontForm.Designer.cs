using FingerFinder;

namespace FingerFinder
{
    partial class FrontForm
    {
        FingerprintAnalyzer Analyzer { get; set; }

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
            this.groupBox_toolkit = new System.Windows.Forms.GroupBox();
            this.imageOpener = new System.Windows.Forms.OpenFileDialog();
            this.tab_fpOriginal = new System.Windows.Forms.TabControl();
            this.tabPage_original = new System.Windows.Forms.TabPage();
            this.tabPage_skeleton = new System.Windows.Forms.TabPage();
            this.menuStrip.SuspendLayout();
            this.tab_fpOriginal.SuspendLayout();
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
            this.menuStripItem_close.Click += new System.EventHandler(this.zavřítToolStripMenuItem_Click);
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
            // groupBox_toolkit
            // 
            this.groupBox_toolkit.Location = new System.Drawing.Point(438, 31);
            this.groupBox_toolkit.Name = "groupBox_toolkit";
            this.groupBox_toolkit.Size = new System.Drawing.Size(359, 445);
            this.groupBox_toolkit.TabIndex = 2;
            this.groupBox_toolkit.TabStop = false;
            this.groupBox_toolkit.Text = "Nástroje";
            // 
            // imageOpener
            // 
            this.imageOpener.FileName = "Obraz otisku";
            this.imageOpener.Filter = "JPG|*.jpg|PNG|*.png";
            // 
            // tab_fpOriginal
            // 
            this.tab_fpOriginal.Controls.Add(this.tabPage_original);
            this.tab_fpOriginal.Controls.Add(this.tabPage_skeleton);
            this.tab_fpOriginal.Location = new System.Drawing.Point(12, 31);
            this.tab_fpOriginal.Name = "tab_fpOriginal";
            this.tab_fpOriginal.SelectedIndex = 0;
            this.tab_fpOriginal.Size = new System.Drawing.Size(420, 26);
            this.tab_fpOriginal.TabIndex = 0;
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
            this.tabPage_skeleton.Size = new System.Drawing.Size(490, 0);
            this.tabPage_skeleton.TabIndex = 1;
            this.tabPage_skeleton.Text = "Otisk skeleton";
            this.tabPage_skeleton.UseVisualStyleBackColor = true;
            // 
            // FrontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 491);
            this.Controls.Add(this.tab_fpOriginal);
            this.Controls.Add(this.groupBox_toolkit);
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
            this.tab_fpOriginal.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox_toolkit;
        private System.Windows.Forms.ToolStripMenuItem analýzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detekcemarkantůToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klasifikaceToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog imageOpener;
        private System.Windows.Forms.ToolStripSeparator menuStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuStripItem_import;
        private System.Windows.Forms.TabControl tab_fpOriginal;
        private System.Windows.Forms.TabPage tabPage_original;
        private System.Windows.Forms.TabPage tabPage_skeleton;
    }
}

