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
        //private readonly object CustomerId;


        //Add Errand
        public RegisterErrand()
        {
            InitializeComponent();

            cbCustomerList.SelectedValuePath = "Key";
            cbCustomerList.DisplayMemberPath = "Value";

            cbAdmin.SelectedValuePath = "Key";
            cbAdmin.DisplayMemberPath = "Value";

            cbStatus.SelectedValuePath = "Key";
            cbStatus.DisplayMemberPath= "Value";

            PopulateCustomerId();
            PopulateAdminId();
            PopulateStatus();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(cbCustomerList.SelectedValuePath)
                && !string.IsNullOrEmpty(cbAdmin.SelectedValuePath)
                && !string.IsNullOrEmpty(tbSubject.Text)
                //&& !string.IsNullOrEmpty(tbStatus.Text)
                && !string.IsNullOrEmpty(tbDescription.Text))
            {
                SqlService createErrand = new SqlService();

                Errands errands = new Errands()
                {
                    Subject = tbSubject.Text,
                    Description = tbDescription.Text,
                    CustomerId = (int)cbCustomerList.SelectedValue,
                    AdminId = (int)cbAdmin.SelectedValue,
                    Status = (Statuses)(int)cbStatus.SelectedValue,
                };
                createErrand.CreateErrand(errands);
                ClearFields();
            }
                
        }

        public void ClearFields()
        {
            tbSubject.Text = string.Empty;
            cbCustomerList.SelectedItem = null;
            cbAdmin.SelectedItem = null;
            //tbStatus.Text = string.Empty;
            cbStatus.SelectedItem = null;
            tbDescription.Text = string.Empty;
            //tbError.Text = string.Empty;    
        }

        //Popluate Customer ID
        private void PopulateCustomerId()
        {
            foreach(var customer in sqlService.GetAll())
            {
                cbCustomerList.Items.Add(new KeyValuePair<int,string>(customer.Id, customer.FirstName));
            }
        }


        //Admins
        private void PopulateAdminId()
        {
            cbAdmin.Items.Clear();
            foreach (var admin in sqlService.GetAdminList())
            {
                cbAdmin.Items.Add(new KeyValuePair<int, string>(admin.Id, admin.AdminName));
            }
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbRegAdmin.Text))
            {
                SqlService createAdmin = new SqlService();
                Admins admin = new Admins()
                {
                    AdminName = tbRegAdmin.Text,
                };

                
                createAdmin.CreateAdmin(admin);
                ClearAdminField();
                PopulateAdminId();

            }
        }

        public void ClearAdminField()
        {
            tbRegAdmin.Text = "";
            cbAdmin.SelectedValue = null;
        }

        //Status
     
        private void PopulateStatus()
        {
            foreach(var status in Enum.GetValues(typeof(Statuses))) 
            {
                cbStatus.Items.Add(new KeyValuePair<int, string>((int)status, status.ToString()));
            }
        }
    }
}
