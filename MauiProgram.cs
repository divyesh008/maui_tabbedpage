using CommunityToolkit.Maui;
using TabedPageDemo.Pages;
using TabedPageDemo.ViewModels;

namespace TabedPageDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<ShowViewModel>();

		builder.Services.AddSingleton<AdditionalInfoPage>();
		builder.Services.AddSingleton<AdditionalInfoPageViewModel>();

		return builder.Build();
	}
}

