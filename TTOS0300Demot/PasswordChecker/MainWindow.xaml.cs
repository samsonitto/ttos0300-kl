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

namespace PasswordChecker
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

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            //näytetään UI:ssa syötettyjen merkkien määrä
            int lkmTotal = txtPassword.Text.Length;
            int lkmCaps = 0;
            int lkmSmall = 0;
            int lkmNum = 0;
            int lkmSpecial = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
            {
                if (char.IsUpper(txtPassword.Text[i]))
                {
                    lkmCaps++;
                }
                else if (char.IsLower(txtPassword.Text[i]))
                {
                    lkmSmall++;
                }
                else if (char.IsNumber(txtPassword.Text[i]))
                {
                    lkmNum++;
                }
                else
                {
                    lkmSpecial++;
                }
            }

            //for (int i = 0; i < txtPassword.Text.Length; i++)
            //{
            //    if (char.IsLower(txtPassword.Text[i]))
            //    {
            //        lkmSmall++;
            //    }
            //}

            //for (int i = 0; i < txtPassword.Text.Length; i++)
            //{
            //    if (char.IsNumber(txtPassword.Text[i]))
            //    {
            //        lkmNum++;
            //    }
            //}

            //for (int i = 0; i < txtPassword.Text.Length; i++)
            //{
            //    if (char.IsSymbol(txtPassword.Text[i]))
            //    {
            //        lkmSpecial++;
            //    }
            //}
            txbTotal.Text = "Merkkejä: " + lkmTotal;
            txbCaps.Text = "Isoja kirjaimia: " + lkmCaps;
            txbSmall.Text = "Pieniä kirjaimia: " + lkmSmall;
            txbNumbers.Text = "Numeroita: " + lkmNum;
            txbSpecialChars.Text = "Erikoismerkkejä: " + lkmSpecial;
            // TODO logiikka joka päättelee onko oikeasti vahva salasana
            Color color;
            string message;
            if (lkmTotal > 10 && lkmCaps > 0 && lkmNum > 0 && lkmSpecial > 0)
            {
                color = Colors.Green;
                message = "GOOD";
            }

            else if (lkmTotal > 10 && lkmNum > 0 || lkmTotal > 10 && lkmNum > 0 && lkmSpecial > 0 || lkmTotal > 10 && lkmNum > 0 && lkmCaps > 0 || lkmTotal > 10 && lkmSpecial > 0)
            {
                color = Colors.Yellow;
                message = "FAIR";
            }
            else
            {
                color = Colors.Red;
                message = "LOUSY - TRY AGAIN!";
            }
            //näytetään värillä ja tekstillä onko vahva salasana
            txbMessage.Text = message;
            SolidColorBrush brush = new SolidColorBrush(color);
            txbMessage.Background = brush;
        }
    }
}
