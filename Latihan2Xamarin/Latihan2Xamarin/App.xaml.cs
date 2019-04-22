using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Latihan2Xamarin.Views;
using Plugin.Settings;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Latihan2Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var isLogin = CrossSettings.Current.GetValueOrDefault("is_login", false);
            if (!isLogin)
                MainPage = new NavigationPage(new LoginPages());
            else
                MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
