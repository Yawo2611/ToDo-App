﻿using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using CommunityToolkit.Maui;

namespace ToDo_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {   
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMopups()
                .UseMauiCommunityToolkit()
                
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
