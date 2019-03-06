using Microsoft.Win32;
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
        //enum MusicPlays
        //{
        //    Stop,
        //    Play,
        //    Pause
        //}
        //MusicPlays musicPlays;
        public MainWindow()
        {
            InitializeComponent();
            //musicPlays = MusicPlays.Stop;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // videot soimaan
                if (!isPlaying)
                {
                    //if (musicPlays == MusicPlays.Stop)
                    //{
                    MyMediaElement.Source = new Uri(txtFilename.Text);
                    //}
                    MyMediaElement.Play();
                }
                else
                {
                    MyMediaElement.Play();
                }
                isPlaying = true;
                //musicPlays = MusicPlays.Play;
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
            //musicPlays = MusicPlays.Stop;
            btnPause.IsEnabled = false;
            btnPlay.IsEnabled = true;
            btnStop.IsEnabled = false;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                MyMediaElement.Pause();
                isPlaying = true;
                //musicPlays = MusicPlays.Pause;
                btnPause.IsEnabled = false;
                btnPlay.IsEnabled = true;
                btnStop.IsEnabled = true;
            }
            
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // käytetään valmista windowsin omaa Open-dialogia
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "d:\\";
            dlg.Filter = "Media files (*.mp4)|*mp4|Audio Files (*.mp3)|*.mp3|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            Nullable<bool> result = dlg.ShowDialog(); // näyttää dialogin
            if (result == true)
            {
                txtFilename.Text = dlg.FileName;
            }
        }
    }
}
