using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using RIF.Core;
using MvvmCross;
using RIF.Core.Interfaces;
using RIF.iOS.Utilities;

namespace RIF.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<ILocalNotificationsManager>(() => new LocalNotificationsManager());
        }

        protected override IMvxIocOptions CreateIocOptions()
        {
            return new MvxIocOptions
            {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
            };
        }
    }
}
