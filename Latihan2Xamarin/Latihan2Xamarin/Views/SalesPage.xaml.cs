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
    public partial class SalesPage : ContentPage
    {
        public SalesPage()
        {
            InitializeComponent();

            var salesViewModel = new SalesViewModel();
            salesViewModel.LoadFromDb();
            BindingContext = salesViewModel;   
        }
    }
}