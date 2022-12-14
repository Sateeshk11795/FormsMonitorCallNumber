using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android;
using Android.Content;
using Android.Telephony;

[assembly: UsesPermission(Manifest.Permission.ReadCallLog)]
[assembly: UsesPermission(Manifest.Permission.ReadPhoneNumbers)]
[assembly: UsesPermission(Manifest.Permission.ReadPhoneState)]
[assembly: UsesPermission(Manifest.Permission.ReadExternalStorage)]
[assembly: UsesPermission(Manifest.Permission.WriteExternalStorage)]
namespace XFormsMonitorCallNumber.Droid
{
    [Activity(Label = "XFormsMonitorCallNumber", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        PhoneStateChangedRceiver phoneStateChangedRceiver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            phoneStateChangedRceiver = new PhoneStateChangedRceiver();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
         //   StartService(new Intent(this, typeof(PhoneStateChangedRceiver)));
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode == 123 && grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                RegisterReceiver(new PhoneStateChangedRceiver(), new IntentFilter(TelephonyManager.ActionPhoneStateChanged));
            }
        }

    }
}