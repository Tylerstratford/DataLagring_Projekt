using DataLagring_Projekt.Models.Entities;
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
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : UserControl
    {

        private readonly SqlService _sqlService = new SqlService();

        public Start()
        {
            InitializeComponent();
            lvErrands.Items.Clear();
            foreach (var errand in _sqlService.GetErrandList())
            {
                lvErrands.Items.Add(errand);
            }

            foreach (var errands in _sqlService.GetErrandList())
            {
                lvErrandss.Items.Add(errands);
            }

            List<ErrandsEntity> list = new List<ErrandsEntity>();

            
            foreach (var item in _sqlService.GetErrands())
            {
                list.Add(item);
            }

            list.Count();

            int counterRegErrand = list.Where(x => x.Status == "Registered").Count();
            int counterInvErrand = list.Where(x => x.Status == "Investigating").Count();
            int counterCloErrand = list.Where(x => x.Status == "Closed").Count();
            int totalErrands = list.Count();


            TEST.Text = counterRegErrand.ToString();
            TEST1.Text =  counterInvErrand.ToString();
            TEST2.Text = counterCloErrand.ToString();
            TEST3.Text = totalErrands.ToString();
        }


       

    }
}
