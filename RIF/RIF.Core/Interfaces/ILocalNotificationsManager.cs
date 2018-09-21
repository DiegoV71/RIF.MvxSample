using System;

namespace RIF.Core.Interfaces
{
    public interface ILocalNotificationsManager
    {
        void Schedule(TimeSpan interval, string title, string message);
    }
}
