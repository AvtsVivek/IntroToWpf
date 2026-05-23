using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BasicMvvmVarOneWithCommunityToolkit.ViewModels
{
	public partial class MainWindowViewModel : ObservableObject
	{
		[ObservableProperty]
		private IPageViewModel? _currentPageViewModel;

		private readonly Dictionary<string, IPageViewModel>? _pageViewModels = [];

		public MainWindowViewModel()
		{
			_pageViewModels["1"] = new UserControl1ViewModel("1");

			_pageViewModels["2"] = new UserControl2ViewModel("2");

			_pageViewModels["3"] = new UserControl3ViewModel("3");

			CurrentPageViewModel = _pageViewModels["1"];
		}

		[RelayCommand()]
		private void OnClick(string arg)
		{
			CurrentPageViewModel = _pageViewModels![arg];
		}
	}
}
