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
using JAMK.IT.TTOS0300;

namespace Pelaajat
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

        private void btnGetPlayers_Click(object sender, RoutedEventArgs e)
        {
            //haetaan pelaajatiedot BL-kerrokselta
            dgPlayers.ItemsSource = JAMK.IT.TTOS0300.Joukkue.HaePelaajat();
        }

        private void dgPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //tsekataan mikä Pelaaja-olio valittu
            Object selected = dgPlayers.SelectedItem;
            if (selected is Pelaaja)
            {
                Pelaaja tähtiPelaaja = (Pelaaja)selected;
                txbSelected.Text = tähtiPelaaja.ToString();
            }
        }
    }
}
