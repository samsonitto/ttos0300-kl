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

namespace K_S_ikkunat
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

        private void btnCount_Click(object sender, RoutedEventArgs e)
        {
            int ikkunaLev = 0;
            int ikkunaKor = 0;
            int karmiLev = 0;
            try
            {
                ikkunaLev = int.Parse(txtWidth.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                ikkunaKor = int.Parse(txtHeight.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                karmiLev = int.Parse(txtKarmiLev.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int A = (ikkunaLev + karmiLev) * (ikkunaKor + karmiLev);
            txbA.Text = A.ToString();

            int P = ((ikkunaLev + ikkunaKor) + karmiLev * 2) * 2;
            txbP.Text = P.ToString();

            int KA = A - ikkunaKor * ikkunaLev;
            txbKA.Text = KA.ToString();

        }
    }
}
