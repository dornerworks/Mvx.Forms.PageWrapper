using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Demo.Core.ViewModels
{
    public class Page1FragmentViewModel : MvxViewModel
    {
        private string _label = "Xamarin.Forms Page";
        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        private ICommand _nextCommand;
        private IMvxLog _log;
        public ICommand NextCommand => _nextCommand ??= new MvxCommand(() =>
        {
            _navigationService.Navigate<Page2FragmentViewModel>();
        });

        private readonly IMvxNavigationService _navigationService;

        public Page1FragmentViewModel(IMvxNavigationService navigationService, IMvxLogProvider logProvider)
        {
            _navigationService = navigationService;
            _log = logProvider.GetLogFor<Page1FragmentViewModel>();
        }

        public override void ViewCreated()
        {
            _log.Debug("View Created");
            base.ViewCreated();
        }

        public override void ViewAppearing()
        {
            _log.Debug("View Appearing");
            base.ViewAppearing();
        }

        public override void ViewAppeared()
        {
            _log.Debug("View Appeared");
            base.ViewAppeared();
        }

        public override void ViewDisappearing()
        {
            _log.Debug("View Disappearing");
            base.ViewDisappearing();
        }

        public override void ViewDisappeared()
        {
            _log.Debug("View Disappeared");
            base.ViewDisappeared();
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            _log.Debug("View Destroy");
            base.ViewDestroy(viewFinishing);
        }
    }
}