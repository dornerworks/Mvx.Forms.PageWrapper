using Demo.Core.ViewModels;
using MvvmCross.ViewModels;

namespace Demo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<StartViewModel>();
        }
    }
}