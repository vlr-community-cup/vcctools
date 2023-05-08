using Microsoft.Extensions.FileProviders;

namespace VCCTools.Middleware;

public static class ClientMiddlewareExtensions
{
    public static IApplicationBuilder UseClient(this IApplicationBuilder app)
    {
        var contentRootPath = app.ApplicationServices.GetService<IWebHostEnvironment>().ContentRootPath;
        return app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(contentRootPath, "Client")),
            RequestPath = "/Client"
        });
    }
}