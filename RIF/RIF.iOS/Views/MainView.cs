using System;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Messenger;
using RIF.Core.Messages;
using RIF.Core.ViewModels;
using UIKit;

namespace RIF.iOS.Views
{
    public partial class MainView : MvxViewController
    {
        IMvxMessenger _messenger;

        IDisposable _alertSubscriptionToken;
        IDisposable _dialogSubscriptionToken;

        public MainView()
        {
            _messenger = Mvx.IoCProvider.Resolve<IMvxMessenger>();
            _alertSubscriptionToken = _messenger.SubscribeOnMainThread<AlertMessage>(ProcessAlert);
            _dialogSubscriptionToken = _messenger.SubscribeOnMainThread<DialogMessage>(ProcessDialog);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

                var set = this.CreateBindingSet<MainView, MainViewModel>();

            set.Bind(Field).To(vm => vm.Text);
            set.Bind(FieldLabel).To(vm => vm.Text).OneWay();

            set.Bind(AlertButton).To(vm => vm.AlertCommand);
            set.Bind(DialogButton).To(vm => vm.DialogCommand);
            set.Bind(ResultLabel).To(vm => vm.DialogResult);

            set.Bind(NotificationButton).To(vm => vm.ScheduleNotificationCommand);

            set.Apply();
        }

        void ProcessAlert(AlertMessage mes)
        {
            var alertController = UIAlertController.Create("Внимание", mes.Text, UIAlertControllerStyle.Alert);

            var okAlertAction = UIAlertAction.Create(mes.OkButtonText, UIAlertActionStyle.Default, null);

            alertController.AddAction(okAlertAction);

            PresentViewController(alertController, true, null);
        }

        void ProcessDialog(DialogMessage mes)
        {
            var alertController = UIAlertController.Create("Внимание", mes.Text, UIAlertControllerStyle.ActionSheet);

            foreach (var variant in mes.Variants)
            {
                var action = UIAlertAction.Create(variant, UIAlertActionStyle.Default, (a) => ActionHandler(a, mes.CompletionSource));
                alertController.AddAction(action);
            }

            PresentViewController(alertController, true, null);
        }

        void ActionHandler(UIAlertAction action, TaskCompletionSource<string> completionSource)
        {
            completionSource.SetResult(action.Title);
        }
    }
}

