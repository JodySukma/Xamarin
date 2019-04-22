using Latihan2Xamarin.Service;
using Plugin.Settings;
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
	public partial class LoginPages : ContentPage
	{
        public LoginPages()
        {
            InitializeComponent();

            SignInButton.Clicked += async (sender, e) =>
            {
                var service = new DataService();

                if (await service.Login(EmailEntry.Text, PasswordEntry.Text))
                { 
                    // await Navigation.PushAsync(new HomePage());
                    CrossSettings.Current.AddOrUpdateValue("is_login", true);
                    Navigation.InsertPageBefore(new HomePage(), this);
                    await Navigation.PopAsync();
                }
                else
                    await DisplayAlert("Error", "Invalid username or password", "cancel");
                
               // Navigation.PushAsync(new SalesPage());
            };
        }
    }
}