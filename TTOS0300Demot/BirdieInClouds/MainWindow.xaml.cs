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
using System.Windows.Threading;

namespace BirdieInClouds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //jäsenmuuttujat (member fields)
        private DispatcherTimer timer;
        private double dx = 0;
        private double dy = 0;
        private double maxX = 0;
        private double maxY = 0;
        private Thickness curTh;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //asetetaan oletusarvot ja alustetaan&käynnistetään timeri
            maxX = this.Width - 10;
            maxY = this.Height - 10;
            //näppäimistö mukaan
            this.KeyDown += new KeyEventHandler(OnKeyDown);
            this.KeyUp += new KeyEventHandler(OnKeyUp);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //luetaan mitä näppäintä painettu ja liikutetaan kuvaa
            switch (e.Key)
            {
                case Key.Left:
                    break;
                case Key.Up:
                    break;
                case Key.Right:
                    break;
                case Key.Down:
                    break;
                default:
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
