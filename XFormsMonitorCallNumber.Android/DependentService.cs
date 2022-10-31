using Android.App;
using Android.Content;
using Android.OS;
using Android.Telephony;

namespace XFormsMonitorCallNumber.Droid
{
    [Service]
    public class DependentService : Service
    {
        public void Start()
        {
            var intent = new Intent(Android.App.Application.Context,
     typeof(DependentService));


            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                Android.App.Application.Context.StartForegroundService(intent);
            }
            else
            {
                Android.App.Application.Context.StartService(intent);
            }
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            // From shared code or in your PCL

            CreateNotificationChannel();
            string messageBody = "Monitor starting";

            var notification = new Notification.Builder(this, "10111")
            .SetContentTitle("monitor Incoming Call")
            .SetContentText(messageBody)
            .SetSmallIcon(Resource.Drawable.icon_about)
            .SetOngoing(true)
            .Build();
            StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);
            //do you work monitor the call broadcast
            IntentFilter filter = new IntentFilter();
            filter.AddAction(TelephonyManager.ActionPhoneStateChanged);


            PhoneStateChangedRceiver receiver = new PhoneStateChangedRceiver();
            Application.Context.RegisterReceiver(receiver, filter);


            return StartCommandResult.Sticky;
        }


        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            //var channelName = Resources.GetString(Resource.String.channel_name);
            //var channelDescription = GetString(Resource.String.channel_description);
            var channelName = Resources.GetString(Resource.String.character_counter_content_description);
            var channelDescription = GetString(Resource.String.character_counter_content_description);
            var channel = new NotificationChannel("10111", channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}