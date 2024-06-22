
using BomNegocio.API.DTOs.Mappings;
using BomNegocio.API.Extensions;
using BomNegocio.API.Filters;
using BomNegocio.API.Logging;
using BomNegocio.BLL.Services;
using BomNegocio.BLL.Services.Implements;
using BomNegocio.DAL.Context;
using BomNegocio.DAL.Models;
using BomNegocio.DAL.Repositories.Implements;
using BomNegocio.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // adicionando o filtro de exceções
        builder.Services.AddControllers(options =>
        {
            options.Filters.Add(typeof(ApiExceptionFilter));
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "apibomnegocio", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Bearer JWT ",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    new string[] {}
                }
            });
        });

        //builder.Services.AddAuthorization();
        //builder.Services.AddAuthentication("Bearer").AddJwtBearer();
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<BNContext>()
            .AddDefaultTokenProviders();

        //me
        string mySqlConnection = builder.Configuration.GetConnectionString("Defaultconnection") ?? throw new Exception("Erro ao obter a string de conecção");

        builder.Services.AddDbContext<BNContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

        //Configuração do Identity aula 125
        var secretKey = builder.Configuration["JWT:SecretKey"] ?? throw new ArgumentException("Invalid secret key!!");

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidAudience = builder.Configuration["JWT:ValidAudience"],
                ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));

            options.AddPolicy("SuperAdminOnly", policy =>
                               policy.RequireRole("admin").RequireClaim("id", "maycon"));

            options.AddPolicy("UserOnly", policy => policy.RequireRole("user"));

            options.AddPolicy("AnuncianteOnly", policy => policy.RequireRole("anunciante"));

            options.AddPolicy("ExclusiveOnly", policy =>
                              policy.RequireAssertion(context =>
                                context.User.HasClaim(claim =>
                                                   claim.Type == "id" && claim.Value == "maycon")
                                                    || context.User.IsInRole("SuperAdmin")));
        });

        builder.Services.AddScoped<ApiLoggingFilter>();
        builder.Services.AddScoped<IAnuncianteRepository, AnuncianteRepository>();
        //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IAnuncianteRepository, AnuncianteRepository>();
        builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();
        builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAnuncioService, AnnouncementService>();
        builder.Services.AddScoped<IAnuncioService, AnnouncementService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var app = builder.Build(); // construindo a instancia do aplicativo --> Configure() 


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.ConfigureExceptionHandler();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}