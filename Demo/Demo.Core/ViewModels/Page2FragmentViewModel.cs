using MvvmCross.Logging;
using MvvmCross.ViewModels;

namespace Demo.Core.ViewModels
{
    public class Page2FragmentViewModel : MvxViewModel
    {
        private IMvxLog _log;
        public Page2FragmentViewModel(IMvxLogProvider logProvider)
        {
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