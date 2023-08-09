using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using siades.Database.DataContext;
using siades.Services.Interfaces;
using siades.Services.Repositories;

namespace siades.CompositRoot;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddSwaggerConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwagger();
        return builder;
    }

    public static WebApplicationBuilder AddControllersConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver())
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.DefaultBufferSize = 1024;
                options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
                options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.ReadCommentHandling = new JsonCommentHandling();
                options.JsonSerializerOptions.UnknownTypeHandling = new JsonUnknownTypeHandling();
            });
        return builder;
    }

    public static WebApplicationBuilder AddDataProtectionConfig(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddDataProtection()
            .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration
            {
                EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
            });

        return builder;
    }

    public static WebApplicationBuilder AddAuthenticationConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(p =>
        {
            p.TokenValidationParameters = new TokenValidationParameters
            {
                // jwt definitions
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateTokenReplay = true,
                

                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(builder.Configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero,
                SaveSigninToken = true

            };
            p.AutomaticRefreshInterval = TimeSpan.FromSeconds(10);
        });
        //builder.Services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
        builder.Services.AddAuthorization();
        return builder;
    }

    public static WebApplicationBuilder AddConfigurationConfig(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<FormOptions>(o =>
        {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = int.MaxValue;
            o.MemoryBufferThreshold = int.MaxValue;
        });
        return builder;
    }

    // configurar o swagger para receber tokens no header 
    public static IServiceCollection AddSwagger(this IServiceCollection _services)
    {
        _services.AddEndpointsApiExplorer();
        _services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "claver-api",
                Version = "v1.0",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Nossos Contactos",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Licença",
                    Url = new Uri("https://example.com/license")
                }
            });

            //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = @"JWT Authorization using the Bearer Scheme. 
                    Enter 'Bearer' [space].Example:\ 'Bearer 12345abcdef\'",
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        return _services;
    }

    // servicos de persistencia no bd
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
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

        return builder;
    }

}