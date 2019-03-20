using System;
using System.Collections.Generic;
using System.IO;
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
        private List<Auto> autot;
        public MainWindow()
        {
            InitializeComponent();
            autot = JAMK.IT.TTOS0300.Autotalli.HaeAutot();
            //comboboksiin eri automerkit
            //VE1 kovakoodaus
            //List<string> merkit = new List<string>() { "Tesla", "Audi", "Lada" };
            //VE2 kysytään LINQlla eri automerkit
            var result = autot.Select(m => m.Merkki).Distinct();
            cbMerkki.ItemsSource = result;
        }

        private void BtnGetAllCars_Click(object sender, RoutedEventArgs e)
        {
            dgCars.ItemsSource = autot;//JAMK.IT.TTOS0300.Autotalli.HaeAutot();
            //foreach(Auto item in autot)
            //{
            //    cbMerkki.Items.Add(item.Merkki);
            //}
            //cbMerkki.Items.Add(autot.Where(m => m.Merkki.ToString().Distinct()));
            
        }

        private void DgCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object selected = dgCars.SelectedItem;
            if(selected != null)
            {
                Auto auto = (Auto)selected; //kastataan selected Auto-olioksi
                ShowPicture(auto.URL);
            }
            //Object selected = dgCars.SelectedItem;
            //if (selected is Auto)
            //{
            //    Auto kuva = (Auto)selected;
            //    string path = $"images/{kuva.URL.ToString()}";
            //    ImageSourceConverter imgs = new ImageSourceConverter();
            //    Uri uri = new Uri(path, UriKind.Relative);
            //    ImageSource imgSource = new BitmapImage(uri);
            //    imgCar.Source = imgSource;
            //}
        }

        private void CbMerkki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //suodatetaan listasta jäljellä vain valitun merkin autot
            string merkki = cbMerkki.SelectedValue.ToString();
            var result = JAMK.IT.TTOS0300.Autotalli.HaeAutot().Where(m => m.Merkki.Contains(merkki));
            dgCars.ItemsSource = result;
        }

        private void btnGetTeslas_Click(object sender, RoutedEventArgs e)
        {
            //näytetään pelkästään teslat
            var result = autot.Where(m => m.Merkki.Contains("Tesla"));
            dgCars.ItemsSource = result;
        }

        private void ShowPicture(string kuvatiedosto)
        {
            try
            {
                if (string.IsNullOrEmpty(kuvatiedosto))
                {
                    kuvatiedosto = "puuttuu.jpg";
                }
                //lisätään tiedostonimeen polku
                kuvatiedosto = $"images/{kuvatiedosto}";
                //tutkitaan löytyykö annettua kuvatiedostoa levyltä (ei toimi netissä)
                if (!File.Exists(kuvatiedosto))
                    kuvatiedosto = "images/puuttuu.jpg";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(kuvatiedosto, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                imgCar.Stretch = Stretch.Fill;
                imgCar.Source = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
