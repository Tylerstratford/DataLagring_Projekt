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
        public RegisterErrand()
        {
            InitializeComponent();


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbSubject.Text) && !string.IsNullOrEmpty(tbCustomerId.Text) && !string.IsNullOrEmpty(tbAdministrator.Text) && !string.IsNullOrEmpty(tbStatus.Text) && !string.IsNullOrEmpty(tbDescription.Text))
            {
                SqlService createErrand = new SqlService();

                Errands errands = new Errands()
                {
                    CustomerId = Int32.Parse(tbCustomerId.Text),
                    Subject = tbSubject.Text,
                    //AdminId = Int32.Parse(tbAdministrator.Text),
                    //StatusId = Int32.Parse(tbStatus.Text),
                    description = tbDescription.Text
                };

                createErrand.CreateErrand(errands);
                ClearFields();
            }
        }

        public void ClearFields()
        {
            tbSubject.Text = string.Empty;
            tbCustomerId.Text = string.Empty;
            tbAdministrator.Text = string.Empty;
            tbStatus.Text = string.Empty;
            tbDescription.Text = string.Empty;  
        }
    }
}
