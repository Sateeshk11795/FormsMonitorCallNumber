using XFormsMonitorCallNumber.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(IncomingCallReceiver))]
namespace XFormsMonitorCallNumber.Droid
{
    public class IncomingCallReceiver : ICallReceiver
    {
        public void OnReceive()
        {
            var dependentService = new DependentService();
            dependentService.Start();

        }
    }
}