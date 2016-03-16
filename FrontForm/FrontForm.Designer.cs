using FingerFinder;

namespace FrontForm
{
    partial class FrontForm
    {
        FprintAnalyzer Analyzer { get; set; }

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
            this.menuStripItem_close = new System.Windows.Forms.ToolStripSeparator();
            this.zavřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analýzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detekcemarkantůToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klasifikaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_fingerPrint = new System.Windows.Forms.Panel();
            this.groupBox_toolkit = new System.Windows.Forms.GroupBox();
            this.menuStrip.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(770, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // MenuStripItem_soubor
            // 
            this.MenuStripItem_soubor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItem_open,
            this.menuStripItem_close,
            this.zavřítToolStripMenuItem});
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
            // menuStripItem_close
            // 
            this.menuStripItem_close.Name = "menuStripItem_close";
            this.menuStripItem_close.Size = new System.Drawing.Size(179, 6);
            // 
            // zavřítToolStripMenuItem
            // 
            this.zavřítToolStripMenuItem.Name = "zavřítToolStripMenuItem";
            this.zavřítToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.zavřítToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.zavřítToolStripMenuItem.Text = "Zavřít";
            this.zavřítToolStripMenuItem.Click += new System.EventHandler(this.zavřítToolStripMenuItem_Click);
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
            this.panel_fingerPrint.Location = new System.Drawing.Point(12, 31);
            this.panel_fingerPrint.Name = "panel_fingerPrint";
            this.panel_fingerPrint.Size = new System.Drawing.Size(419, 370);
            this.panel_fingerPrint.TabIndex = 1;
            // 
            // groupBox_toolkit
            // 
            this.groupBox_toolkit.Location = new System.Drawing.Point(437, 31);
            this.groupBox_toolkit.Name = "groupBox_toolkit";
            this.groupBox_toolkit.Size = new System.Drawing.Size(321, 370);
            this.groupBox_toolkit.TabIndex = 2;
            this.groupBox_toolkit.TabStop = false;
            this.groupBox_toolkit.Text = "Nástroje";
            // 
            // FrontForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 413);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuStripItem_soubor;
        private System.Windows.Forms.ToolStripMenuItem menuStripItem_open;
        private System.Windows.Forms.ToolStripSeparator menuStripItem_close;
        private System.Windows.Forms.ToolStripMenuItem zavřítToolStripMenuItem;
        private System.Windows.Forms.Panel panel_fingerPrint;
        private System.Windows.Forms.GroupBox groupBox_toolkit;
        private System.Windows.Forms.ToolStripMenuItem analýzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detekcemarkantůToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klasifikaceToolStripMenuItem;
    }
}

