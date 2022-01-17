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

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    int customerId; //Maybe this works...
        //    if(!string.IsNullOrEmpty(tbSubject.Text) && !string.IsNullOrEmpty(tbCustomerId.Text) && int.TryParse(tbCustomerId.Text, out customerId) && !string.IsNullOrEmpty(tbAdministrator.Text) && !string.IsNullOrEmpty(tbStatus.Text) && !string.IsNullOrEmpty(tbDescription.Text))
        //    {
        //        SqlService createErrand = new SqlService();

        //        Errands errands = new Errands()
        //        {
        //            //CustomerId = Int32.Parse(tbCustomerId.Text),
        //            Subject = tbSubject.Text,
        //            //AdminId = Int32.Parse(tbAdministrator.Text),
        //            //StatusId = Int32.Parse(tbStatus.Text),
        //            Description = tbDescription.Text,


        //        };


        //        if(createErrand.CreateErrand(errands) > 0 )
        //        {
        //            ClearFields();
        //        } else
        //        {
        //            tbError.Text = "Either you entered the wrong customer ID or one of the fields is empty, please enter the correct information.";

        //        }


        //    //    createErrand.CreateErrand(errands);
        //    //    ClearFields();
        //    //} else
        //    //{
        //    //    ClearFields();
        //    }
        //}

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(tbSubject.Text) 
        //        //&& !string.IsNullOrEmpty(tbCustomerId.Text) 
        //        && !string.IsNullOrEmpty(tbAdministrator.Text) 
        //        && !string.IsNullOrEmpty(tbStatus.Text) 
        //        && !string.IsNullOrEmpty(tbDescription.Text))
        //    {
        //        if (sqlService.CreateErrand(tbSubject.Text, tbAdministrator.Text, tbStatus.Text, tbDescription.Text, (int)cbCustomerList.SelectedValue))
        //    }
        //}
    }
}
