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

namespace Wpf3Birds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            lstData.DataContext = BirdViewModel.Get3TestBirds();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            //asetetaan oikean puoleisen stackpanelin datacontestiksi hiiren alla oleva Lintu-olio
            var kuva = sender as Image;
            Bird lintu = kuva.DataContext as Bird;
            spRight.DataContext = lintu;
        }
    }
}
