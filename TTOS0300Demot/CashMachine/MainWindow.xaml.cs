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
            IniMyStuff();
        }

        private void IniMyStuff()
        {
            //lisätään muutama tuote listaan
            Product p1 = new Product("Kahvi", 1.5F);
            lstProducts.Items.Add(p1);
            Product p2 = new Product("Tee", 1.1F);
            lstProducts.Items.Add(p2);
            lstProducts.Items.Add(new Product("Pulla", 1.6F));
            lstProducts.Items.Add(new Product("Sämpylä", 2.5F));
            lstProducts.Items.Add(new Product("Suklaa", 1.3F));
            lstProducts.Items.Add(new Product("Blowjob", 10F));
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

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = lstProducts.SelectedItem;
            //kastaus eli tyyppimuunnos Product-tyypiksi
            if(selected is Product)
            {
                Product product = (Product)selected;
                lstItems.Items.Add(product);
                CountSum();
            }
             
        }

        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //poistetaan valittu ostos listasta
            //Object selected = lstItems.SelectedItem;
            //lstItems.Items.Remove(selected);
            //tai lyhyesti
            lstItems.Items.Remove(lstItems.SelectedItem);
            CountSum();
        }

        private void CountSum()
        {
            //lasketaan ostosten summa listassa olevista Product-olioista
            summa = 0;
            foreach(var item in lstItems.Items)
            {
                Product product = (Product)item;
                summa += product.Price;
            }
            //näytetään ostosten yhteishinta
            txbTotal.Text = "Yhteensä: " + summa.ToString("C");
        }
    }
}
