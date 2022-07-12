using TabedPageDemo.Pages;

namespace TabedPageDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(DiscoverPage), typeof(DiscoverPage));
        Routing.RegisterRoute(nameof(ShowDetailPage), typeof(ShowDetailPage));
        Routing.RegisterRoute(nameof(EpisodeDetailPage), typeof(EpisodeDetailPage));
        Routing.RegisterRoute(nameof(CategoriesPage), typeof(CategoriesPage));
        Routing.RegisterRoute(nameof(CategoryPage), typeof(CategoryPage));
        Routing.RegisterRoute(nameof(AdditionalInfoPage), typeof(AdditionalInfoPage));

        MainPage = new CategoryPage();
	}
}

