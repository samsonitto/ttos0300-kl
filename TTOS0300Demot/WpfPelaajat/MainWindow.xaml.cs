using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfPelaajat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int counter = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnGetPlayers_Click(object sender, RoutedEventArgs e)
        {
            //haetaan pelaajat SQLite-tietokannasta
            try
            {
                dgPlayers.DataContext = JAMK.IT.DB.ReadFromSQLite(txtFilename.Text, "pelaajat");
                lblMessages.Text = "Pelaajat haettu tiedostosta " + txtFilename.Text;
            }
            catch(Exception ex)
            {
                lblMessages.Text = "Virhe haettaessa tietoja.";
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //lisätään uusi pelaaja tietokantaan
            try
            {
                JAMK.IT.DB.AddToSQLite(txtFilename.Text, "pelaajat", txtName.Text, txtTeam.Text, counter);
                counter++;
                lblMessages.Text = $"Pelaaja {txtName.Text} lisätty tietokantaan";
                //päivitetään datagrid tietokannasta
                dgPlayers.DataContext = JAMK.IT.DB.ReadFromSQLite(txtFilename.Text, "pelaajat");
            }
            catch (Exception ex)
            {
                lblMessages.Text = "Virhe tietokantaan kirjoitettaessa.";
                MessageBox.Show(ex.Message);
            }
        }

        private void dgPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //poistetaan tuplaklikattu pelaaja, huom nyt ei ole olio vaan rivi datagridissä
            //joten otetaan kiinni pelaajan nimi datagridin datacontekstin datatablesta
            var dt = (DataTable)dgPlayers.DataContext;
            string name = dt.Rows[dgPlayers.SelectedIndex][0].ToString();
            //ksysymys
            var result = MessageBox.Show($"Haluatko varmasti poistaa pelaajan {name}?", "Pelaajan poisto", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                if (JAMK.IT.DB.DeleteFromSQLite(txtFilename.Text, "pelaajat", name))
                {
                    lblMessages.Text = $"Pelaaja {name} poistettu";
                }
                else
                {
                    lblMessages.Text = $"Pelaaja ei {name} poistettu";
                }
                //päivitetään datagrid tietokannasta
                dgPlayers.DataContext = JAMK.IT.DB.ReadFromSQLite(txtFilename.Text, "pelaajat");
            }
            else
            {
                lblMessages.Text = "Pelaajaa ei poisteta.";
            }
        }
    }
}
