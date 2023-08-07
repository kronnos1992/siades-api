using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using siades.Database.DataContext;
using siades.Services.Interfaces;
using siades.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        //options.JsonSerializerOptions.Converters.DefaultIfEmpty();
        options.JsonSerializerOptions.AllowTrailingCommas = true;
        options.JsonSerializerOptions.DefaultBufferSize = 1024;
        options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
        options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.ReadCommentHandling = new JsonCommentHandling();
        options.JsonSerializerOptions.UnknownTypeHandling = new JsonUnknownTypeHandling();
    });

builder.Services.AddCors();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDataProtection().UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
{
    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
});

builder.Services.Configure<FormOptions>(o =>
    {
        o.ValueLengthLimit = int.MaxValue;
        o.MultipartBodyLengthLimit = int.MaxValue;
        o.MemoryBufferThreshold = int.MaxValue;
    });

builder.Services.AddAuthorization();

//varieable for introduce connection strings
builder.Services.AddDbContext<SiadesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);
builder.Services.AddTransient<IBloodRepository, BloodRepository>().AddLogging();
builder.Services.AddTransient<ICountryRepository, CountryRepository>().AddLogging();
builder.Services.AddTransient<IProvinceRepository, ProvinceRepository>().AddLogging();
builder.Services.AddTransient<ITownshiepRepository, TownShiepRepository>().AddLogging();
builder.Services.AddTransient<ISpecialityRepository, SpecialityRepository>().AddLogging();
builder.Services.AddTransient<IHospitalRepository, HospitalRepository>().AddLogging();

builder.Services.AddTransient<IDoctoRepository, DoctoRepository>();
builder.Services.AddTransient<IDonoRepository, DonoRepository>();
builder.Services.AddTransient<IDonationRepository, DonationRepository>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();

});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
