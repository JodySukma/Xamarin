using Latihan2Xamarin.Models;
using Latihan2Xamarin.NativeFeatures;
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
	public partial class DetailCustomers : ContentPage
	{
		public DetailCustomers (Customer customer)
		{
			InitializeComponent ();
            PhoneTapImage.Tapped += (sender, args) =>
            {
                DependencyService.Get<ICallNumber>().CallNumber(customer.PhoneNumber);
            };
            ProfileImage.Source = customer.ProfileImageUrl;
            NameLabel.Text = customer.Name;
            CompanyLabel.Text = customer.Company;
            PhoneLabel.Text = customer.PhoneNumber;
            AddressLabel.Text = customer.Address;

            var position = new Position(customer.Latitude, customer.Longtitude);
            var pin = new Pin
            {
                Type = PinType.Place,
                Address = customer.Address,
                Position = position,
                Label = customer.Name
            };
            CustomerMap.Pins.Add(pin);
            CustomerMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(3)));
		}
	}
}