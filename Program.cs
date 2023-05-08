using VCCTools.Hubs;
using VCCTools.Middleware;
using VCCTools.Services;

namespace VCCTools;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddSignalR();
        builder.Services.AddSingleton<DataService>();

        var app = builder.Build();
        
        app.MapControllers();
        app.MapHub<EventHub>("/Events");
        app.UseClient();

        app.Run();
    }
}