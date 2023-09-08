using NavigationService.Infra;
using NavigationService.Services;

namespace NavigationService.ViewModels
{
    public class UserControl2ViewModel : BaseViewModel //, IPageViewModel
    {
        public string PageId { get; set; }
        public string Title { get; set; } = "View 2";

        private INavigationService _navigationService;

        public INavigationService Navigation
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToOne { get; set; }
        // public RelayCommand NavigateToTwo { get; set; }
        public RelayCommand NavigateToThree { get; set; }

        public UserControl2ViewModel(INavigationService navigationService, string pageIndex = "2")
        {
            PageId = pageIndex;
            // Do we need both here.
            _navigationService = navigationService;
            Navigation = navigationService;

            NavigateToOne = new RelayCommand(execute: o => { Navigation.NavigateTo<UserControl1ViewModel>(); }, canExecute: o => true);
            NavigateToThree = new RelayCommand(execute: o => { Navigation.NavigateTo<UserControl3ViewModel>(); }, canExecute: o => true);

        }
    }
}
