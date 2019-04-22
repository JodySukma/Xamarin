using System;
using System.Collections.Generic;
using System.Text;

namespace Latihan2Xamarin.Helper
{
    class EncryptHelper
    {
        public static string ToBasicAuth(string username, string password)
        {
            var combinedString = $"{username}:{password}";
            var rawBytes = Encoding.ASCII.GetBytes(combinedString);

            return Convert.ToBase64String(rawBytes);
        }
    }
}
