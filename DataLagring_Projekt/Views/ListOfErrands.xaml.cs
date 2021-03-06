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
    /// Interaction logic for ListOfErrands.xaml
    /// </summary>
    public partial class ListOfErrands : UserControl
    {
        private readonly SqlService _sqlService = new SqlService();
        public ListOfErrands()
        {

            InitializeComponent();
            lvErrands.Items.Clear();
            foreach (var errand in _sqlService.GetErrandList())
            {
                lvErrands.Items.Add(errand);
                
            }
        }
    }
}
