﻿using Gewichtsdatenapp_LiveChart.Service;
using Gewichtsdatenapp_LiveChart.Services;
using Gewichtsdatenapp_LiveChart.View;
using Gewichtsdatenapp_LiveChart.ViewModel;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
namespace Gewichtsdatenapp_LiveChart
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ISpeicherplatz, Speicherplatz>();
            builder.Services.AddSingleton<BaseViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<WerteSeite>();
            builder.Services.AddTransient<GrafenSeite>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
