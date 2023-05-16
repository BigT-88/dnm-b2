namespace BugCollectionViewDemo;

public partial class App : Application
{
	public static MainPageViewModel MainPageViewModel;

	public App()
	{
		InitializeComponent();

		MainPageViewModel = new MainPageViewModel();
		MainPage = new MainPage();

	}
}

