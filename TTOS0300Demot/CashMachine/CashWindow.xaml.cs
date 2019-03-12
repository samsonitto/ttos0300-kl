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
using System.Windows.Shapes;

namespace CashMachine
{

    /// <summary>
    /// Interaction logic for CashWindow.xaml
    /// </summary>
    public partial class CashWindow : Window
    {
        //PROPERTIES
        public float Mount { get; set; }
        //CONSTRUCTORS
        public CashWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            //näytetään UIssa maksettava summa
            txbTotal.Text = "Yhteensä: " + Mount.ToString("C");
        }

        private void txtMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            //muutetaan teksti luvuksi ja lasketaan takaisin annettava rahamäärä
            float money = 0;
            if (float.TryParse(txtMoney.Text, out money))
                txbBack.Text = "Takaisin: " + (money - Mount).ToString("C");
        }

        private void btnPaid_Click(object sender, RoutedEventArgs e)
        {
            //1. tallennetaan myynti päivämyyntiin
            //2. kerrotaan pääikkunalle että lista tyhjennetään
            //3. suljetaan ikkuna
            this.Close();
        }
        //NETHODS
        //EVENT HANDLERS
    }
}
