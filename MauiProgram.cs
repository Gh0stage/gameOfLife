using Microsoft.AspNetCore.Components.WebView.Maui;
using gameOfLife.Data;

namespace gameOfLife;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
		Game game = new Game();
		Timer timer = new Timer(game.Update,null,0,game.speedModifierDefault*1000);
		return builder.Build();
	}
}
