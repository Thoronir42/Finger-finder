using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FingerprintAnalyzer;

namespace FingerFinderPresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected Analyzer Analyzer { get; set; } = new Analyzer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tabControl_fingerprintDrawer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }
    }
}
