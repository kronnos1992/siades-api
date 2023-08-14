using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using siades.CompositRoot;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // webapplication services drom compositroot
        builder.AddControllersConfig();
        
        builder.AddSwaggerConfig();
        builder.AddDataProtectionConfig();
        builder.AddConfigurationConfig();
        
        builder.AddPersistence();
        builder.AddUSerConfigurations();
        builder.AddAuthenticationConfig();
        
        builder.Services.AddCors();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseAppSwaggerRoutes();
        }

        // iapplication services from compositroot
        app.UseAppCors();
        app.UseAppStaticFiles();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        //app.UseAuthorization();

        app.MapControllers();
        //.RequireAuthorization(args);

        app.Run();
    }
}