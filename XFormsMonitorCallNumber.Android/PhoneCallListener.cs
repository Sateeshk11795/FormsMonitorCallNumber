using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsMonitorCallNumber.Droid
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { TelephonyManager.ActionPhoneStateChanged }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class PhoneCallListener : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var state = intent.GetStringExtra(TelephonyManager.ExtraState);
            AudioManager audioManager = (AudioManager)Android.App.Application.Context.GetSystemService(Context.AudioService);
            if (intent.Action == TelephonyManager.ActionPhoneStateChanged)
            {
                if (state == TelephonyManager.ExtraStateOffhook)
                {
                    DependencyService.Get<IMessage>().LongTime("PhoneCallListener");
                    Task.Run(() =>
                    {
                        Task.Delay(5000).Wait();
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        {
                            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.S)
                            {
                               Utils.setCommunicationDevice(context, AudioDeviceType.BuiltinSpeaker);
                            }
                            else
                            {
                                audioManager.SpeakerphoneOn = true;
                            }
                        });
                    });
                }
            }
        }
    }
}