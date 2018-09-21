using System;
using RIF.Core.Interfaces;
using UserNotifications;

namespace RIF.iOS.Utilities
{
    public class LocalNotificationsManager : ILocalNotificationsManager
    {
        public void Schedule(TimeSpan interval, string title, string message)
        {
            var content = new UNMutableNotificationContent()
            {
                Title = title,
                Body = message,
                Sound = UNNotificationSound.Default
            };
            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(interval.TotalSeconds, false);
            var request = UNNotificationRequest.FromIdentifier(Guid.NewGuid().ToString(), content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, null);
        }
    }
}
