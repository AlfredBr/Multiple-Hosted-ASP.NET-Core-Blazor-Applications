using Microsoft.AspNetCore.ResponseCompression;

// https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/multiple-hosted-webassembly?view=aspnetcore-7.0
// https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio

namespace group;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        
        app.MapWhen(ctx => ctx.Request.Host.Port == 7000, first =>
        {
            first.UseStaticFiles();
            first.UseRouting();
            first.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        });
        
        app.MapWhen(ctx => ctx.Request.Host.Port == 7001, first =>
        {
            first.Use((ctx, nxt) =>
            {
                ctx.Request.Path = "/app1" + ctx.Request.Path;
                return nxt();
            });

            first.UseBlazorFrameworkFiles("/app1");
            first.UseStaticFiles();
            first.UseStaticFiles("/app1");
            first.UseRouting();

            first.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("/app1/{*path:nonfile}", "app1/index.html");
            });
        });

        app.MapWhen(ctx => ctx.Request.Host.Port == 7002, first =>
        {
            first.Use((ctx, nxt) =>
            {
                ctx.Request.Path = "/app2" + ctx.Request.Path;
                return nxt();
            });

            first.UseBlazorFrameworkFiles("/app2");
            first.UseStaticFiles();
            first.UseStaticFiles("/app2");
            first.UseRouting();

            first.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("/app2/{*path:nonfile}", "app2/index.html");
            });
        });

        app.MapWhen(ctx => ctx.Request.Host.Port == 7003, first =>
        {
            first.Use((ctx, nxt) =>
            {
                ctx.Request.Path = "/app3" + ctx.Request.Path;
                return nxt();
            });

            first.UseBlazorFrameworkFiles("/app3");
            first.UseStaticFiles();
            first.UseStaticFiles("/app3");
            first.UseRouting();

            first.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("/app3/{*path:nonfile}", "app3/index.html");
            });
        });

        app.Run();
    }
}