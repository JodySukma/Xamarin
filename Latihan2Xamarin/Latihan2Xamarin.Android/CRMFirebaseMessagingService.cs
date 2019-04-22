using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;

namespace Latihan2Xamarin.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class CRMFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            SendNotification(message.GetNotification().Body, message.GetNotification().Title, message.Data);
        }

        void SendNotification(string messageBody, string title, IDictionary<string, string> detailData)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            if (detailData.Count > 0)
            {
                intent.PutExtra("sale", detailData["sale"]);
            }

            intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.UpdateCurrent);

            var notificationBuilder = new NotificationCompat.Builder(this)
                .SetSmallIcon(Resource.Drawable.ic_audiotrack_light)
                .SetContentTitle(title)
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var notifacationManager = NotificationManager.FromContext(this);
            notifacationManager.Notify(0, notificationBuilder.Build());
        }
    }
}