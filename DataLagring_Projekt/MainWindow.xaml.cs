using DataLagring_Projekt.Models;
using DataLagring_Projekt.Services;
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

            //Customer customer = new Customer()
            //{
            //    FirstName = "Ty",
            //    LastName = "Strat",
            //    Email = "tyler@hotmail.com",
            //    Telephone = "0761720282",
            //    Address = new Address
            //    {
            //        StreetName = "StreetOne",
            //        City = "Örebro",
            //        PostalCode = "70233",
            //        Country = "Sweden"
            //    }
            //};

            //SqlService sql = new SqlService();
            //var customerId = sql.CreateCustomer(customer);

            Errands errand = new Errands()
            {
                Subject = "Bad Wifi",
                CustomerId = 13,
                StatusId = 1,
                description = "Wifi is not working as intended",
                AdminId = 1,
            };

            SqlService sqlService = new SqlService();
            var errandId = sqlService.CreateErrand(errand);

            Admins admins = new Admins()
            {
                AdminName = "Bob"
            };
            SqlService sql1 = new SqlService();
            var adminId = sql1.CreateAdmin(admins);


        }

    
    }
}
