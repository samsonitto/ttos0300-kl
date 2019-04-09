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
using JAMK.IT;

namespace WpfJunat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetStations();
        }
        #region METHODS
        private void SetStations()
        {
            //asetetaan asemapaikat UI:hin
            //VE1 manuaalisesti
            List<Station> stations = new List<Station>();
            stations.Add(new Station("HKI", "Helsinki"));
            stations.Add(new Station("JY", "Jyväskylä"));
            stations.Add(new Station("TPE", "Tampere"));
            stations.Add(new Station("YV", "Ylivieska"));
            //VE2 ratahallinnon REST-palvelusta
            //asetetaan comboboxiin
            cbStations.DisplayMemberPath = "Name";
            cbStations.SelectedValuePath = "Code";
            cbStations.DataContext = stations;
        }
        //synkroninen metodi junien hakuun
        private void GetTrainsAt(string station)
        {
            dgData.DataContext = TrainsViewModel.GetTrainsAT(station);
        }
        //asynkroninen metodi junien hakuun
        private void GetTrainsAtAsync()
        {

        }
        #endregion

        #region EVENTHANDLERS
        private void btnGetTrains_Click(object sender, RoutedEventArgs e)
        {
            if(cbStations.SelectedValue != null)
            {
                string station = cbStations.SelectedValue.ToString();
                tbMessage.Text = $"Hetaan aseman {station} junia...";
                GetTrainsAt(station);
                tbMessage.Text = "Junat haettu";
            }
            
        }
        #endregion
    }
}
