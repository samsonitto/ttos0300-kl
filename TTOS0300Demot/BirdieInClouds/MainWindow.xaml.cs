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
        private double move = 1;
        private int speed = 20;
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
            //määritellään ns gameloop
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += new EventHandler(GameTick);
            timer.Start();
        }

        private void GameTick(object sender, EventArgs e)
        {
            //lasketaan linnun paikka uudestaan
            double x, y;
            curTh = imgBird.Margin;
            x = curTh.Left + dx;
            y = curTh.Top + dy;
            //TODO tarkastelu ettei mene minimin tai maksimin yli/ohi
            if (x >= maxX || x <= 0 || y >= maxY || y <= 0)
            {
                timer.Stop();
                txbMsg.FontSize = 100;
                txbMsg.Text = "Game Over";
            }
            else
            {
                Thickness newTh = new Thickness(x, y, curTh.Right, curTh.Bottom);
                imgBird.Margin = newTh;
                txbMsg.Text = $"Bird {x},{y}";
            }
            
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //luetaan mitä näppäintä painettu ja liikutetaan kuvaa
            switch (e.Key)
            {
                case Key.Left:
                    dx = -move;
                    break;
                case Key.Up:
                    dy = -move;
                    break;
                case Key.Right:
                    dx = move;
                    break;
                case Key.Down:
                    dy = move;
                    break;
                case Key.Space:
                    timer.Interval = TimeSpan.FromMilliseconds(speed/2);
                    break;
                default:
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    timer.Interval = TimeSpan.FromMilliseconds(speed);
                    break;
                default:
                    dx = 0;
                    dy = 0;
                    break;
            }
            
        }
    }
}
