using DataLagring_Projekt.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLagring_Projekt.Models.ViewModels
{
    internal class MainWindowViewModel : ObservableObject
    {

        //Relay commands
        public RelayCommand CustomerViewCommand { get; set; } //CustomerListViewModel - CustomerList
        public RelayCommand CreateCustomerViewCommand { get; set; } //CreeateCustomerViewModel - CreateCustomer

        public RelayCommand ListOfErrandsViewCommand { get; set; }
        public RelayCommand DetailedErrandsViewCommand { get; set; }

        public RelayCommand RegisterErrandViewCommand { get; set; }
        public RelayCommand StartViewCommand { get; set; }

        //View Models
        public CustomerListViewModel CustomerListViewModel { get; set; }
        public CreateCustomerViewModel CreateCustomerViewModel { get; set; }
        public ListOfErrandsViewModel ListOfErrandsViewModel { get; set;}
        public RegisterErrandViewModel RegisterErrandViewModel { get; set; }
        public DetailedErrandsViewModel DetailedErrandsViewModel { get; set; }

        public StartViewModel StartViewModel { get; set; }



        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainWindowViewModel()
        {
            CustomerListViewModel = new CustomerListViewModel();
            CreateCustomerViewModel = new CreateCustomerViewModel();
            ListOfErrandsViewModel = new ListOfErrandsViewModel();
            RegisterErrandViewModel = new RegisterErrandViewModel();
            DetailedErrandsViewModel = new DetailedErrandsViewModel();
            StartViewModel = new StartViewModel();

            CurrentView = StartViewModel;

            CustomerViewCommand = new RelayCommand(x => CurrentView = CustomerListViewModel);
            CreateCustomerViewCommand = new RelayCommand(x => CurrentView = CreateCustomerViewModel);
            ListOfErrandsViewCommand = new RelayCommand(x => CurrentView = ListOfErrandsViewModel);
            RegisterErrandViewCommand = new RelayCommand(x => CurrentView = RegisterErrandViewModel);
            DetailedErrandsViewCommand = new RelayCommand(x => CurrentView = DetailedErrandsViewModel);
            StartViewCommand = new RelayCommand(x => CurrentView = StartViewModel);

        }
    }
}
