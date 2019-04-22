using Latihan2Xamarin.Models;
using Latihan2Xamarin.Service;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Latihan2Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCustomer : ContentPage
	{
        Pin _pin;
        DataService dataService = new DataService();

        public AddCustomer ()
		{
			InitializeComponent ();
            SaveButton.Clicked += async (sender, args) =>
            {
                var customer = new Customer
                {
                    Name = NameEntry.Text,
                    Address = AddressEntry.Text,
                    Company = "Kawan Seperjuangan",
                    Longtitude = _pin.Position.Longitude,
                    Latitude = _pin.Position.Latitude
                };

                if (await dataService.PostNewCustomer(customer))
                    await DisplayAlert("Sucess", "Sucess add customer", "Ok");
                else
                    await DisplayAlert("Sucess", "Failed add customer", "Cancel");
            };
            CancelButton.Clicked += (sender, args) => { Navigation.PopAsync(true); };
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                    status = results[Permission.Location];
                }
                if (status == PermissionStatus.Granted)
                {
                    var location = await CrossGeolocator.Current.GetPositionAsync();
                    _pin = new Pin
                    {
                        Position = new Position(location.Latitude, location.Longitude),
                        IsDraggable = true,
                        IsVisible = true
                    };
                    CustomerMap.Pins.Add(_pin);
                    CustomerMap.MoveToRegion(MapSpan.FromCenterAndRadius(_pin.Position, Distance.FromKilometers(3)));
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}