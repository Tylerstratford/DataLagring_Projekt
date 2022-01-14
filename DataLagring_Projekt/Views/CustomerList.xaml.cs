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
    /// Interaction logic for CustomerList.xaml
    /// </summary>
    public partial class CustomerList : UserControl
    {

        private readonly SqlService _sqlService = new SqlService();
        public CustomerList()
        {
            InitializeComponent();

            lvCustomers.Items.Clear();
            foreach(var customer in _sqlService.GetAll())
            {
                lvCustomers.Items.Add(customer);
            }
            foreach(var address in _sqlService.GetAllAddress())
            {
                lvCustomers.Items.Add(address);
            }
        }
    }
}
