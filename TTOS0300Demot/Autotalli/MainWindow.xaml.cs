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

namespace Autotall1
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

        private void BtnGetAllCars_Click(object sender, RoutedEventArgs e)
        {
            dgCars.ItemsSource = JAMK.IT.TTOS0300.Autotalli.HaeAutot();
            foreach(Auto item in JAMK.IT.TTOS0300.Autotalli.HaeAutot())
            {
                
                cbMerkki.Items.Add(item.Merkki);
            }
            
        }

        private void DgCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgCars.SelectedItem;
            if (selected is Auto)
            {
                Auto kuva = (Auto)selected;
                string path = $"images/{kuva.URL.ToString()}";
                ImageSourceConverter imgs = new ImageSourceConverter();
                Uri uri = new Uri(path, UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                imgCar.Source = imgSource;
            }
        }

        private void CbMerkki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //suodatetaan listasta jäljellä vain valitun merkin autot
            string merkki = cbMerkki.SelectedValue.ToString();
            var result = JAMK.IT.TTOS0300.Autotalli.HaeAutot().Where(m => m.Merkki.Contains(merkki));
            dgCars.ItemsSource = result;
        }

    }
}
