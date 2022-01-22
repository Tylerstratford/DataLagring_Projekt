using DataLagring_Projekt.Models;
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
    /// Interaction logic for DetailedErrands.xaml
    /// </summary>
    public partial class DetailedErrands : UserControl
    {

        private readonly SqlService _sqlService = new SqlService();

        //Read List of Errands
        public DetailedErrands()
        {
            InitializeComponent();
            lvDetailedErrands.Items.Clear();

            foreach (var errand in _sqlService.GetErrandList())
            {
                lvDetailedErrands.Items.Add(errand);
            }

            cbStatus.SelectedValuePath = "Key";
            cbStatus.DisplayMemberPath = "Value";

            cbErrand.SelectedValuePath = "Key";
            cbErrand.DisplayMemberPath = "Value";

            PopulateStatus();
            PopulateErrands();
        }

        //Populate Statues to combobox
        private void PopulateStatus()
        {
            foreach (var status in Enum.GetValues(typeof(Statuses)))
            {
                cbStatus.Items.Add(new KeyValuePair<int, string>((int)status, status.ToString()));
            }
        }

        //Populate Errands to Combobox
        private void PopulateErrands()
        {
            foreach (var errand in _sqlService.GetErrandList())
            {
                cbErrand.Items.Add(new KeyValuePair<int, string>(errand.Id, $"Id: {errand.Id} {errand.Subject}"));
            }
        }

        //Save Changed status - Button
        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cbStatus.SelectedValuePath) && !string.IsNullOrEmpty(cbErrand.SelectedValuePath))
            {
                SqlService update = new SqlService();

                var newStatus = (Statuses)Enum.Parse(typeof(Statuses), cbStatus.SelectedValue.ToString());
                int errandId = (int)cbErrand.SelectedValue;

                ErrandsEntity updateStatus = new ErrandsEntity()
                {
                    Status = newStatus.ToString(),
                    DateEdited = DateTime.Now,
                };

                update.UpdateStatus(errandId, updateStatus);

                ClearSavedChangesFields();

            }
           
        }


        //Clear Fields - Errand & Status
        private void ClearSavedChangesFields()
        {
            cbErrand.SelectedValue = null;
            cbStatus.SelectedValue = null;
        }

     

        
    }
}
