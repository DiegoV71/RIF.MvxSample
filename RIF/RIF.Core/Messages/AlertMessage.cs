using System;
using MvvmCross.Plugin.Messenger;
namespace RIF.Core.Messages
{
    public class AlertMessage : MvxMessage
    {
        public AlertMessage(object sender, string text, string okButtonText) : base(sender)
        {
            Text = text;
            OkButtonText = okButtonText;
        }

        public string Text { get; }

        public string OkButtonText { get; }
    }
}
