using FBTracker.Server.Data;
using FBTracker.Server.Data.Repos;
using FBTracker.Server.Data.Schema.Tables;
using FBTracker.Server.Data.Services;
// using Microsoft.EntityFrameworkCore;

namespace FBTracker.Server;

internal static class Startup
{
    internal static void AddLogging(
        WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddEventSourceLogger();
        
        if (builder.Environment.IsDevelopment())
        {
            builder.Logging.AddDebug();
        }
    }

    internal static void AddControllersAndViews(
        IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();
    }

    internal static void AddDomainServices(
        IServiceCollection services)
    {
        services.AddSingleton<DataContext>();
        
        services.AddTransient<UserStateRepo>();
        services.AddTransient<StateService>();
        services.AddTransient<UserStateTable>();
        
        services.AddTransient<TeamsRepo>();
        services.AddTransient<TeamsService>();
        services.AddTransient<TeamsTable>();

        services.AddTransient<SeasonPrepRepo>();
        services.AddTransient<SeasonPrepService>();
        services.AddTransient<SeasonPrepTable>();
    }
}
