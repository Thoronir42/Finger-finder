using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FingerFinder
{
    public partial class FrontForm : Form
    {

        FingerprintAnalyzer FprintAnalyzer { get; set; } = new FingerprintAnalyzer();

        public FrontForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Otevřít");
            if(this.imageOpener.ShowDialog() != DialogResult.OK)
            {
                Console.WriteLine("Otevírání souboru zrušeno.");
                return;
            }

            Console.WriteLine(this.imageOpener.FileName);
        }

        private void zavřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrontForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                    Console.WriteLine("Zavřeno požadavkem v aplikaci");
                    break;
            }
            
        }

        private void imageOpener_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                Image fingerprint = Image.FromFile(imageOpener.FileName);
                this.FprintAnalyzer.FingerprintOriginal = fingerprint;
                this.drawFingerprint();
            } catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        private void drawFingerprint()
        {
            var g = this.panel_fingerPrint.CreateGraphics();
            Image fingerprint = this.FprintAnalyzer.getImage(tabs_typeSelect.SelectedIndex);

            Rectangle bounds = new Rectangle() { X = 0, Y = 0, Height = panel_fingerPrint.Height, Width = panel_fingerPrint.Width };
            if(fingerprint == null)
            {
                Brush fill = new SolidBrush(Color.HotPink);
                g.FillRectangle(fill, bounds);
                return;
            }
            g.DrawImage(fingerprint, 0, 0);

        }

        private void tabs_typeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawFingerprint();
        }
    }
}
