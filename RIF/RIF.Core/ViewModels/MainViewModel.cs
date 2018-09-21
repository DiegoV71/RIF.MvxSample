using System;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using RIF.Core.Interfaces;
using RIF.Core.Messages;
namespace RIF.Core.ViewModels
{
    public class MainViewModel: MvxViewModel
    {
        IMvxMessenger _messenger;

        string _text = "Hello, World!";
        string _dialogResult = "No Result";

        public MainViewModel(IMvxMessenger messenger)
        {
            _messenger = messenger;
        }

        public string Text 
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public string DialogResult
        {
            get => _dialogResult;
            set => SetProperty(ref _dialogResult, value);
        }

        public IMvxCommand AlertCommand => new MvxCommand(ExcecuteAlert);

        public IMvxCommand DialogCommand => new MvxAsyncCommand(ExcecuteDialogAsync);

        public IMvxCommand ScheduleNotificationCommand => new MvxCommand(ScheduleNotification);

        void ExcecuteAlert()
        {
            var message = new AlertMessage(this, _text, "Ok");
            _messenger.Publish(message);
        }

        async Task ExcecuteDialogAsync()
        {
            var message = new DialogMessage(this, _text, "Вариант 1", "Вариант 2", "Вариант 3");
            _messenger.Publish(message);

            var result = await message.CompletionSource.Task;

            DialogResult = result;
        }

        void ScheduleNotification()
        {

            var notificationManager = Mvx.IoCProvider.Resolve<ILocalNotificationsManager>();
            notificationManager.Schedule(TimeSpan.FromSeconds(5), "Notification title", "Notification body");
        }
    }
}
