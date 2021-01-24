using MvvmCross.Binding;
using MvvmCross.Forms.Platforms.Android.Bindings;
using MvvmCross.Platforms.Android.Core;

namespace Demo.Droid
{
    public class Setup : MvxAndroidSetup<Core.App>
    {
        protected override MvxBindingBuilder CreateBindingBuilder() => new MvxFormsAndroidBindingBuilder();
    }
    
    
}