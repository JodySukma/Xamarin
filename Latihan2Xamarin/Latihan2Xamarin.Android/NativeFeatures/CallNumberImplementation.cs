using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Latihan2Xamarin.Droid.NativeFeatures;
using Latihan2Xamarin.NativeFeatures;
using Xamarin.Forms;

[assembly:Xamarin.Forms.Dependency(typeof(CallNumberImplementation))]
namespace Latihan2Xamarin.Droid.NativeFeatures
{
    class CallNumberImplementation : ICallNumber
    {
        public void CallNumber(string phoneNumber)
        {
            var intent = new Intent(Intent.ActionDial, Android.Net.Uri.Parse("tel: " + phoneNumber));
            var ctx = Forms.Context;
            ctx.StartActivity(intent);
        }
    }
}