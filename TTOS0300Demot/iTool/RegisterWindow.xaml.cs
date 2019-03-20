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

namespace iTool
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private List<string> payment = new List<string>() { "Paypal", "MasterCard", "VISA", "Lasku"};

        public RegisterWindow()
        {
            InitializeComponent();
            var result = payment.Select(p => p.Distinct());
            cbPayment.ItemsSource = result;
        }
    }
}
