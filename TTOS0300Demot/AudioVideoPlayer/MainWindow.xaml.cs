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

namespace AudioVideoPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean isPlaying = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // videot soimaan
                if (!isPlaying)
                {
                    MyMediaElement.Source = new Uri(txtFilename.Text);
                    MyMediaElement.Play();
                }
                isPlaying = true;
                // asetetaan nappien käytettävyyttä
                btnPause.IsEnabled = true;
                btnPlay.IsEnabled = false;
                btnStop.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MyMediaElement.Stop();
            isPlaying = false;
            btnPause.IsEnabled = false;
            btnPlay.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                MyMediaElement.Pause();
                isPlaying = false;
                btnPause.IsEnabled = false;
                btnPlay.IsEnabled = true;
                btnStop.IsEnabled = true;
            }
            
        }
    }
}
