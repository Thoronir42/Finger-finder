using System;
using System.Windows;
using FingerprintAnalyzer;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using System.Drawing.Imaging;
using FingerprintAnalyzer.Model;
using FingerprintAnalyzer.Analyze;
using System.Windows.Input;
using FingerFinderPresenter.ViewModel;

namespace FingerFinderPresenter
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Canvas mouse up detected");
            Canvas canvas = (sender as Canvas);

            var count = ic_minutiae.Items.Count;
            var position = e.GetPosition(canvas);

            Console.WriteLine($"{count} [{position.X}, {position.Y}]");
        }
    }
}
