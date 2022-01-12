using DataLagring_Projekt.Models;
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

namespace DataLagring_Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Customer cust = new Customer();
            cust.FirstName = "Tyler";
            cust.LastName = "Stratford";
            cust.Mobile = 0761720282;
            cust.Email = "Tylerstratford@hotmail.com";
            cust.Telephone = 0761720282;

        }
    }
}
