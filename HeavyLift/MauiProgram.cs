using HeavyLift.ViewModels;
using HeavyLift.Views;
using HeavyLift.Services;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace HeavyLift
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

            //API CONNECTION SETTINGS
            builder.Services.AddSingleton<HttpClient>(serviceProvider =>
            { 
                // Podstawowy adres API (możesz go pobrać z konfiguracji)
                var apiBaseUrl = "https://7c13-84-40-218-81.ngrok-free.app"; // lub z appsettings.json

                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(apiBaseUrl),
                    Timeout = TimeSpan.FromSeconds(30)
                };

                // Konfiguracja nagłówków
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                return httpClient;
            });

            //SERVICES
            builder.Services.AddSingleton<AuthentitacionService>();

            //VIEW MODELS
            builder.Services.AddTransient<LoginViewModel>();

            //VIEWS
            builder.Services.AddTransient<LoginView>();               

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
