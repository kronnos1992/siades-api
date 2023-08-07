using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using storm.domain.Interfaces;
using storm.infrastructure.Data;
using storm.infrastructure.Repositories;

namespace storm.api.Services
{
    public static class ServiceCollectionConfigurations
    {
        // configurar a proteção de dados no trafego
        public static WebApplicationBuilder AddDataProtectionServices(this WebApplicationBuilder _builder)
        {
            _builder.Services.AddDataProtection().UseCryptographicAlgorithms(
            new AuthenticatedEncryptorConfiguration
            {
                EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
            });
            return _builder;
        }

        // configurar limite de trafego de dados
        public static WebApplicationBuilder AddConfigurationServices(this WebApplicationBuilder _builder)
        {
            _builder.Services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            return _builder;
        }

        // configurar controller services
        public static WebApplicationBuilder AddControllerServices(this WebApplicationBuilder _builder)
        {
             _builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling
                = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());
            return _builder; 
        }

        // servico de autenticacao do token
        public static WebApplicationBuilder AddAuthenticationServices(this WebApplicationBuilder _builder)
            {
                _builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // jwt definitions
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            // configure jwt definitions
                            ValidIssuer = _builder.Configuration["Jwt:Issuer"],
                            ValidAudience = _builder.Configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_builder.Configuration["Jwt:Key"]))

                        };
                    });
                _builder.Services.AddAuthorization();
                return _builder;
            }

        // servicos de persistencia no bd
        public static WebApplicationBuilder AddPersistenceServices(this WebApplicationBuilder _builder)
        {

            // DI ofdatabase providers
            var _default = _builder.Configuration.GetConnectionString("Default");

            _builder.Services.AddDbContext<StormDbContext>(options =>
                options.UseSqlServer(_default)
            );

            // Armazenamento em memoria
            _builder.Services.AddMemoryCache();
            _builder.Services.AddHttpContextAccessor();
            
                
            _builder.Services.AddTransient<IBloodRepository, BloodRepository>();
            return _builder;
            }

         // configurar o swagger para receber tokens no header 
        public static IServiceCollection AddSwaggerServices(this IServiceCollection _services)
        {
            _services.AddEndpointsApiExplorer();
            _services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { 
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

            
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                s.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                
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
        // var donor = await dbContext.Tb_Donor
        //     .SingleOrDefaultAsync(x => x.Id == donorId);

        // if (donor.ToString().Trim().Length > 0)
        //{
        //     donor.LastGivenDate = DateTime.Now;
        //     donor.NextGivenDate = DateTime.Now.AddDays(-90);
        //     donor.RemaingDays = DateTime.Now.Day - donor.NextGivenDate.Day;
        //     dbContext.Update(donor);
        //     await dbContext.SaveChangesAsync();
        //     dbContext.Dispose();
        // }
    }
}