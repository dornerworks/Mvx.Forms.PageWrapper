using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Base;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace Mvx.Forms.PageWrapper
{
    public abstract class MvxEmbeddedContentPage : MvxEventSourceContentPage, IMvxPage
    {
        public MvxEmbeddedContentPage()
        {
            this.AdaptForBinding();
        }

        public object DataContext
        {
            get => BindingContext.DataContext;
            set
            {
                if (value != null && !(_bindingContext != null && ReferenceEquals(DataContext, value)))
                    BindingContext = new MvxBindingContext(value);
            }
        }

        private IMvxBindingContext _bindingContext;
        public new IMvxBindingContext BindingContext
        {
            get
            {
                if (_bindingContext == null)
                    BindingContext = new MvxBindingContext(base.BindingContext);
                return _bindingContext;
            }
            set
            {
                _bindingContext = value;
                base.BindingContext = _bindingContext.DataContext;
            }
        }

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(IMvxViewModel), typeof(IMvxElement), default(MvxViewModel), BindingMode.Default, null, ViewModelChanged, null, null);

        internal static void ViewModelChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (newvalue != null)
            {
                if (bindable is IMvxElement element)
                    element.DataContext = newvalue;
                else
                    bindable.BindingContext = newvalue;
            }
        }

        public IMvxViewModel ViewModel
        {
            get => DataContext as IMvxViewModel;
            set
            {
                DataContext = value;
                SetValue(ViewModelProperty, value);
                OnViewModelSet();
            }
        }

        protected virtual void OnViewModelSet()
		{
            
        }
    }

    public abstract class MvxEmbeddedContentPage<TViewModel> : MvxEmbeddedContentPage, IMvxPage<TViewModel> 
        where TViewModel : class, IMvxViewModel
    {
        public new static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(TViewModel), typeof(IMvxElement<TViewModel>), default(TViewModel), BindingMode.Default, null, ViewModelChanged, null, null);

        public new TViewModel ViewModel
        {
            get => (TViewModel)base.ViewModel;
            set => base.ViewModel = value;
        }

        public MvxFluentBindingDescriptionSet<IMvxElement<TViewModel>, TViewModel> CreateBindingSet()
        {
            return this.CreateBindingSet<IMvxElement<TViewModel>, TViewModel>();
        }
    }
}