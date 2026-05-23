namespace BasicMvvmVarOneWithCommunityToolkit.ViewModels
{
	public class UserControl3ViewModel : IPageViewModel
	{
		public string PageId { get; set; }
		public string Title { get; set; }

		public UserControl3ViewModel(string pageIndex = "3")
		{
			PageId = pageIndex;
			Title = "View 3";
		}
	}
}
