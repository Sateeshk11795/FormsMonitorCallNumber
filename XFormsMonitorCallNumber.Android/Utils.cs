using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFormsMonitorCallNumber.Droid
{
    public static class Utils
    {
        public static void setCommunicationDevice(Context context, AudioDeviceType targetDeviceType)
        {
            AudioManager audioManager = (AudioManager)context.GetSystemService(Context.AudioService);
            var devices = audioManager.AvailableCommunicationDevices;
            foreach (AudioDeviceInfo device in devices)
            {
                if (device.Type == targetDeviceType)
                {
                    bool result = audioManager.SetCommunicationDevice(device); // the result will be true
                    Log.Debug("result: ", result.ToString());
                }
            }
        }
    }
}