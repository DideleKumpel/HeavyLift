using HeavyLift.ViewModels;
using HeavyLift.Views;
using HeavyLift.Services;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using CommunityToolkit.Maui;
using HeavyLift.ViewModels.WorkoutViewModels;
using HeavyLift.Views.WorkoutViews;

namespace HeavyLift
{
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

            //API CONNECTION SETTINGS
            builder.Services.AddSingleton<HttpClient>(serviceProvider =>
            { 
                var apiBaseUrl = "https://77f4d060c55b.ngrok-free.app";

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

            //APPSHELL
            builder.Services.AddSingleton<AppShell>();

            //SERVICES
            builder.Services.AddSingleton<AuthentitacionService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<TrainingPlanService>();
            builder.Services.AddSingleton<FileService>();

            //VIEW MODELS
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<WorkoutViewModel>();
            builder.Services.AddTransient<TrainingPlanCreatorViewModel>();
            builder.Services.AddTransient<ExerciseSelectViewModel>();

            //VIEWS
            builder.Services.AddTransient<LoginView>();     
            builder.Services.AddTransient<RegisterView>();
            builder.Services.AddTransient<WorkoutView>();
            builder.Services.AddTransient<TrainingPlanCreatorView>();
            builder.Services.AddTransient<ExerciseSelectView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
