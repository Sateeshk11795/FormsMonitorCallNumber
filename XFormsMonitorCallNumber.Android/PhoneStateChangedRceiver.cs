using Android.App;
using Android.Content;
using Android.Telephony;
using System.Collections.Generic;
using Xamarin.Forms;
using static Android.App.ActivityManager;

namespace XFormsMonitorCallNumber.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged })]
    internal class PhoneStateChangedRceiver: BroadcastReceiver
    {
        public object Int { get; private set; }
        public override void OnReceive(Context context, Intent intent)
        {

            TelephonyManager mTelephonyManager =
             (TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelephonyService);
            string action = intent.Action;

            // MoveApllicationToFront();

            if (TelephonyManager.ActionPhoneStateChanged.Equals(action))
            {
                CallState state = mTelephonyManager.CallState;
                switch (state)
                {
                    case CallState.Ringing:



                        var incomingPhoneNumber = intent.Extras.GetString(TelephonyManager.ExtraIncomingNumber);
                        //var incomingPhoneNumber = intent.GetStringExtra(TelephonyManager.ExtraIncomingNumber);
                        if (incomingPhoneNumber != null)
                        {
                            MoveApllicationToFront();
                            MessagingCenter.Send<string>("You get the InCommingCallNumber is : " + incomingPhoneNumber, "MyMessage");
                        }


                        break;
                    case CallState.Idle:
                        break;
                    case CallState.Offhook:
                        break;
                }
            }
        }
        private void MoveApllicationToFront()
        {
            ActivityManager am = (ActivityManager)Android.App.Application.Context.GetSystemService(Activity.ActivityService);
            //   IList<RunningTaskInfo> rt = am.GetRunningTasks(Integer.MaxValue);
            IList<ActivityManager.AppTask> tasks = am.AppTasks;

            foreach (var item in tasks)
            {
                RecentTaskInfo recentTaskInfo = new RecentTaskInfo();
                recentTaskInfo.BaseActivity = new ComponentName("com.companyname.monitorcallnumber", "");
                item.TaskInfo.Equals(recentTaskInfo);
                item.MoveToFront();
            }

        }
    }
}