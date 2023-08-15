using Microsoft.Extensions.FileProviders;

namespace siades.CompositRoot;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app,
    IWebHostEnvironment environment)
    {
        app.UseDeveloperExceptionPage();
        return app;
    }
    // servicos para usar o cors
    public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
    {
        app.UseCors(p =>
         p
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod()
        );
        return app;
    }
    // servico para usar o swagger
    public static IApplicationBuilder UseAppSwaggerRoutes(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(s =>
        {
            s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            s.RoutePrefix = string.Empty;
        });
        return app;
    }

    public static IApplicationBuilder UseAppStaticFiles(this IApplicationBuilder app)
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
            RequestPath = "/wwwroot"
        });
        return app;
    }
}