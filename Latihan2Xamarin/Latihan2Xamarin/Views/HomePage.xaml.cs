using Latihan2Xamarin.Models;
using Latihan2Xamarin.Views.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Latihan2Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        private readonly CustomersViewModel _customersViewModel;
        private readonly SalesViewModel _salesViewModel;

        public HomePage()
        {
            InitializeComponent();
            AddSaleTap.Tapped += (sender, args) => { Navigation.PushAsync(new AddSale()); };
            AddNewCustomerTap.Tapped += (sender, args) => { Navigation.PushAsync(new AddCustomer()); };
            _salesViewModel = new SalesViewModel();
            //_salesViewModel.Load();
            _customersViewModel = new CustomersViewModel();
            //_customersViewModel.Load();
            SalesContentPage.BindingContext = _salesViewModel;
            CustomersContentPage.BindingContext = _customersViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _salesViewModel.Load();
            _customersViewModel.Load();
        }

        private void OnSalesItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedSale = e.SelectedItem as Sale;
            if (SelectedSale != null)
            {
                Navigation.PushAsync(new DetailSale(SelectedSale));

                var listview = sender as ListView;
                if (listview != null)
                {
                    listview.SelectedItem = null;
                }
            }
        }

        private void OnCustomersItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCustomer = e.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                Navigation.PushAsync(new DetailCustomers(selectedCustomer));

                var listview = sender as ListView;
                if (listview != null)
                    listview.SelectedItem = null;
            }
        }

        private void OnListCacheTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SalesPage());
            
        }

       
    }
}