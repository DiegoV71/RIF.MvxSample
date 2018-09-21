
using RIF.Core.ViewModels;
using MvvmCross.ViewModels;

namespace RIF.Core
{
    public class App : MvxApplication
    {
        //public override void Initialize()
        //{
        //    RegisterNavigationServiceAppStart<MainViewModel>();
        //}

        public override void Initialize()
        {
            base.Initialize();
            RegisterAppStart<MainViewModel>();
        }
    }
}
