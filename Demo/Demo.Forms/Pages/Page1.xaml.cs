using Demo.Core.ViewModels;
using Mvx.Forms.PageWrapper;
using Xamarin.Forms.Xaml;

namespace Demo.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : MvxEmbeddedContentPage<Page1FragmentViewModel>
    {
        public string Test { get; set; }
        
        public Page1()
        {
            InitializeComponent();
            
            var set = CreateBindingSet();
            set.Bind(this).For(v => v.Test).To(vm => vm.Label).OneWay();
            set.Apply();
        }
    }
}