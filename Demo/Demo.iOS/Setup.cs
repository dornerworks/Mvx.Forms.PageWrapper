using MvvmCross.Binding;
using MvvmCross.Forms.Platforms.Ios.Bindings;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Core;

namespace Demo.iOS
{
    public class Setup : MvxIosSetup<Core.App>
    {
        protected override MvxBindingBuilder CreateBindingBuilder() => new MvxFormsIosBindingBuilder();
    }
}