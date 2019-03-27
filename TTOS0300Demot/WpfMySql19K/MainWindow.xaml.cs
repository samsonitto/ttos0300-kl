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

namespace WpfMySql19K
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

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //haetaan oppilastiedot Mysql-palvelimelta
                dgStudents.ItemsSource = DB.LoadStudentsFromMysql();
            }
            catch (Exception ex)
            {
                //käyttäjälle olisi hyvä heittää virheilmoitus!
                MessageBox.Show(ex.Message);
            }
        }
    }
}
