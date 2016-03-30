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
    }
}
