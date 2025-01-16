using ExpenseManager.Components.Utilities;
using Microsoft.Extensions.Logging;
using ExpenseManager.Components.Model;
using System.Text.Json;


namespace ExpenseManager
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
                });

            builder.Services.AddMauiBlazorWebView();
            if (!Directory.Exists(Utils.ROOTFOLDER))
            {
                Directory.CreateDirectory(Utils.ROOTFOLDER);
            }
          


            if (!File.Exists(Utils.TRANSACTIONS))
            {
                File.Create(Utils.TRANSACTIONS).Close();
            }
            if (!File.Exists(Utils.TAGS))
            {
                File.Create(Utils.TAGS).Close();
            }
           


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
