using Labtest1.Viewmodel;
using LabTest1.Service;
using Microsoft.Extensions.Logging;

namespace Labtest1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .RegisterService()
                .RegisterViewModel()
                .RegisterViews()
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

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<q3>();
            
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModel(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<PostsViewModel>();
            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterService(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddScoped<ApiClient>();

            return mauiAppBuilder;
        }
    
}
}