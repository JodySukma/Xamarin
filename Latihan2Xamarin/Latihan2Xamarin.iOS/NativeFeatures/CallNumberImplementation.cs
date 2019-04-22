using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Latihan2Xamarin.iOS.NativeFeatures;
using Latihan2Xamarin.NativeFeatures;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(CallNumberImplementation))]
namespace Latihan2Xamarin.iOS.NativeFeatures
{
    class CallNumberImplementation : ICallNumber
    {
        public void CallNumber(string phoneNumber)
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl("telprompt://" + phoneNumber));
        }
    }
}