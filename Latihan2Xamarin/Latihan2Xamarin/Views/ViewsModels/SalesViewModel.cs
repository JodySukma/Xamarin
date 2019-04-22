using Latihan2Xamarin.Helper;
using Latihan2Xamarin.Models;
using Latihan2Xamarin.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Latihan2Xamarin.Views.ViewsModels
{
    public class SalesViewModel : INotifyPropertyChanged
    {
        private List<Sale> _sales;
        public List<Sale> Sales
        {
            get { return _sales; }
            set
            {
                _sales = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly DataService dataService = new DataService();

        public async Task Load()
        {
            Sales = await dataService.GetListSales();
        }

        public void CreateDummyItems()
        {
            _sales = new List<Sale>
            {
                new Sale
                {
                    Title = "Evergreen Mechanical",
                    Amount = 5000,
                    Percentage = 50,
                    OrderDate = DateTime.Now.AddDays(-1),
                    Deal = "Tes 1"
                },
                new Sale
                {
                    Title = "Bay United School District",
                    Amount = 4000,
                    Percentage = 20,
                    OrderDate = DateTime.Now,
                    Deal = "Tes 2"
                },
                new Sale
                {
                    Title = "Peninsula University",
                    Amount = 600,
                    Percentage = 20,
                    OrderDate = DateTime.Now.AddDays(1),
                    Deal = "Tes 3"
                }
            };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public async Task LoadFromDb()
        {
            Sales = await DatabaseHelper.Instance.GetSalesAsync();
        }

        // kalo pake code ObservableCollection<Sale> as collection
        //public async Task LoadFromDb()
        //{
        //    Sales = new ObservableCollection<Sale>(await DatabaseHelper.Instance.GetSalesAsync());
        //}
    }
}