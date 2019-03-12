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

namespace CashMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float summa = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //käsitellään kaikki ostosten tapahtuman samalla tavalla
            //kastataan sender Button-tyyppiseksi olioksi
            Button pressed = (Button)sender;
            //lisätään ostos listaan
            lstItems.Items.Add(pressed.Content);
            //lasketaan ostosten kokonaissumma
            
            switch (pressed.Content)
            {
                case "Kahvi 1,50€":
                    summa += 1.50F;
                    break;
                case "Tee 1,10€":
                    summa += 1.10F;
                    break;
                case "Pulla 1,60€":
                    summa += 1.60F;
                    break;
                case "Sämpylä 2,50€":
                    summa += 2.50F;
                    break;
                case "Suklaa 1,30€":
                    summa += 1.30F;
                    break;
            }

            txbTotal.Text = "Yhteensä: " + summa.ToString("C"); // "C" on valuutta (currency)
            
        }

        private void btnPaidWithCash_Click(object sender, RoutedEventArgs e)
        {
            // avataan käteismaksu-ikkuna
            CashWindow cashWindow = new CashWindow();
            cashWindow.Mount = summa;
            cashWindow.ShowDialog();
            //tyhjennetään lista ja nollataan summa
            lstItems.Items.Clear();
            summa = 0;
            txbTotal.Text = "Yhteensä: " + summa.ToString("C");
        }
    }
}
