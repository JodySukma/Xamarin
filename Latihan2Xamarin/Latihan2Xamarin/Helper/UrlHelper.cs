using System;
using System.Collections.Generic;
using System.Text;

namespace Latihan2Xamarin.Helper
{
    public static class UrlHelper
    {
        private const string BASE_URL = "https://crmxamarin.azurewebsites.net/api/";
        public const string LOGIN_URL = BASE_URL + "login";
        public const string SALES_URL = BASE_URL + "sales";
        public const string CUSTOMERS_URL = BASE_URL + "customers";
    }
}
