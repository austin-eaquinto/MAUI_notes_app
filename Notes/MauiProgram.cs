/* This is a code file that bootstraps your app. The code in this file serves 
 * as the cross-platform entry point of the app, which configures and starts 
 * the app. The template startup code points to the App class defined by the 
 * App.xaml file. */

using Microsoft.Extensions.Logging;

namespace Notes
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
