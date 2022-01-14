using DataLagring_Projekt.Models;
using DataLagring_Projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DataLagring_Projekt.Views
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : UserControl
    {
        public CreateCustomer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbTelephone.Text) && !string.IsNullOrEmpty(tbStreetName.Text) && !string.IsNullOrEmpty(tbPostalCode.Text) && !string.IsNullOrEmpty(tbCity.Text) && !string.IsNullOrEmpty(tbCountry.Text))
            {
                SqlService createCustomer = new SqlService();

                Customer customer = new Customer()
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Email = tbEmail.Text,
                    Telephone = tbTelephone.Text,
                    Address = new Address()
                    {
                        City = tbCity.Text,
                        Country = tbCountry.Text,
                        StreetName = tbStreetName.Text,
                        PostalCode = tbPostalCode.Text,
                    }


                };


                 if (createCustomer.CreateCustomer(customer) > 0)
                {
                    ClearFields();

                } else
                {
                    tbError.Text = "A user with this email already exists.";

                }
            }
        }

        private void ClearFields()
        {
            tbFirstName.Text = string.Empty;
            tbLastName.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbTelephone.Text = string.Empty;
            tbStreetName.Text = string.Empty;
            tbPostalCode.Text = string.Empty;
            tbCity.Text = string.Empty;
            tbCountry.Text = string.Empty;
            tbError.Text = string.Empty;
        }
    }


}
