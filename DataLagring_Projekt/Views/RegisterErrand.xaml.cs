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

namespace DataLagring_Projekt.Views
{
    /// <summary>
    /// Interaction logic for RegisterErrand.xaml
    /// </summary>
    public partial class RegisterErrand : UserControl
    {
        private readonly SqlService sqlService = new SqlService();
        private readonly object CustomerId;

        public RegisterErrand()
        {
            InitializeComponent();

            cbCustomerList.SelectedValuePath = "Key";
            cbCustomerList.DisplayMemberPath = "Value";

            PopulateCustomerId();

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(cbCustomerList.SelectedValuePath)
                && !string.IsNullOrEmpty(tbAdministrator.Text)
                && !string.IsNullOrEmpty(tbSubject.Text)
                && !string.IsNullOrEmpty(tbStatus.Text)
                && !string.IsNullOrEmpty(tbDescription.Text))
            {
                SqlService createErrand = new SqlService();

                Errands errands = new Errands()
                {
                    Subject = tbSubject.Text,
                    //StatusId = tbStatus.Text
                    Description = tbDescription.Text,
                    //CustomerId  =  cbCustomerList.SelectedMemberPath
                    //CustomerId = (int)cbCustomerList.SelectedValue
                    //CustomerId = (int)cbCustomerList.SelectedValue
                    //DateCreated = DateTime.Now,
                    //CustomerId = (int)cbCustomerList.SelectedItem.ToString(),
                    //CustomerId = 5,
                    CustomerId = (int)cbCustomerList.SelectedValue,
                    
                };
                createErrand.CreateErrand(errands);
                ClearFields();
            }
                
        }

        public void ClearFields()
        {
            tbSubject.Text = string.Empty;
            cbCustomerList.SelectedItem = null;
            tbAdministrator.Text = string.Empty;
            tbStatus.Text = string.Empty;
            tbDescription.Text = string.Empty;
            //tbError.Text = string.Empty;    
        }

        private void PopulateCustomerId()
        {
            foreach(var customer in sqlService.GetAll())
            {
                cbCustomerList.Items.Add(new KeyValuePair<int,string>(customer.Id, customer.FirstName));
            }
        }

    }
}
