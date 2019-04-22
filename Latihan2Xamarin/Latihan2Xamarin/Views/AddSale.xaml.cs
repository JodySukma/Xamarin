using Latihan2Xamarin.Helper;
using Latihan2Xamarin.Models;
using Latihan2Xamarin.Service;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Latihan2Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddSale : ContentPage
	{
		public AddSale ()
		{
			InitializeComponent ();
		}

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var random = new Random();
            var sale = new Sale
            {
                Title = ProductEntry.Text,
                Amount = long.Parse(PriceEntry.Text),
                OrderDate = OrderedDatePicker.Date,
                CustomerID = 1,
                Deal = StatusPicker.SelectedItem.ToString(),
                Percentage = random.Next(1, 100)
            };

            if (CrossConnectivity.Current.IsConnected)
            {
                if (await new DataService().PostNewSale(sale))
                    await DisplayAlert("Sucess", "Sucess Add Sale", "Ok");
                else
                    await DisplayAlert("Error", "Failed Add Sale", "Cancel");
            }

            // sebelum dirubah
            //if (await DatabaseHelper.Instance.SaveItemAsync(sale) != 0)
            //    await DisplayAlert("Sucess", "Sucess Add Sale", "Ok");
            //else
            //    await DisplayAlert("Sucess", "Failed Add Sale", "Cancel");
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(true);
        }

        private async void OnScanButtonClicked(object sender, EventArgs e)
        {
            var newPage = new ZXingScannerPage();
            newPage.OnScanResult += (result) =>
            {
                newPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    ProductEntry.Text = result.Text;
                });
            };

            await Navigation.PushAsync(newPage);
        }
    }
}