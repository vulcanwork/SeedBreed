using Microsoft.Extensions.Logging;
using SeedBreed.Core;
using SeedBreed.Views;

namespace SeedBreed;
public static class MauiProgram
{
    public static string ConnectionString => "Data Source=192.168.69.101;Initial Catalog=Cannabis;User ID=johnv;Password=Hyder1951;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        Api api = new Api(ConnectionString);
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .Services
            .AddSingleton<SourceView>()
            .AddSingleton(api)
            ;

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
