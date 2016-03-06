﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontForm
{
    public partial class FrontForm : Form
    {
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
