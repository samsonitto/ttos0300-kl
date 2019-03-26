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

namespace MVVMDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MEMBER FIELDS
        MVVMDemo.ViewModel.StudentViewModel svm = new ViewModel.StudentViewModel();
        public MainWindow()
        {
            InitializeComponent();
            svm.LoadTestStudents();
        }

        private void dgStudents_Loaded(object sender, RoutedEventArgs e)
        {
            dgStudents.DataContext = svm.Students;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            //lisätään uusi Student-oli Students-kokoelmaan
            Model.Student uusiOppilas = new Model.Student();
            uusiOppilas.FirstName = txtFirstName.Text;
            uusiOppilas.LastName = txtLastName.Text;
            svm.Students.Add(uusiOppilas);
            txtFirstName.Text = "";
            txtLastName.Text = "";
        }
    }
}
