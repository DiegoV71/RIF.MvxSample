using System;
using MvvmCross.Plugin.Messenger;
using System.Threading.Tasks;
namespace RIF.Core.Messages
{
    public class DialogMessage: MvxMessage
    {
        public string Text { get; }

        public string[] Variants { get; }

        public TaskCompletionSource<string> CompletionSource { get; }

        public DialogMessage(object sender, string text, params string[] variants) : base(sender)
        {
            Text = text;
            Variants = variants;
            CompletionSource = new TaskCompletionSource<string>();
        }

    }
}
