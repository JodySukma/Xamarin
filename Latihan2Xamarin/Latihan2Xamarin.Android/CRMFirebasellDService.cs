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
using Firebase.Iid;
using Firebase.Messaging;

namespace Latihan2Xamarin.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class CRMFirebasellDService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            // mengambil token dari instanceID yang terbaru
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Android.Util.Log.Debug("FCMToken: ", "Refreshed token: " + refreshedToken);

            // berlangganan untuk semua topik
            FirebaseMessaging.Instance.SubscribeToTopic("all");

            //TODO: implementasi method ini pada semua registrasi yang ada di server apps
        }
    }
}