using System.Diagnostics;
using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;
using UserNotifications;
using RIF.Core;

namespace RIF.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<Setup, App>
    {

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                                                                  (a1, a2) => Debug.WriteLine($"Local Notifications Granted: {a1} {a2?.DebugDescription}"));

            return result;
        }
    }
}
