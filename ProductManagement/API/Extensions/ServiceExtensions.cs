using Asp.Versioning;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Services;
using System.Reflection;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServices(this IServiceCollection services) =>
            services.AddScoped<IProductService, ProductService>();

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(config => config.UseSqlServer(configuration.GetConnectionString("ProductDbConnection")));

        public static void ConfigureVersioning(this IServiceCollection services) =>
            services.AddApiVersioning(option =>
            {
                option.ReportApiVersions = true;

                option.AssumeDefaultVersionWhenUnspecified = true;

                option.DefaultApiVersion = new ApiVersion(1, 0);

                //option.ApiVersionReader = new QueryStringApiVersionReader("api-version");
                //option.ApiVersionReader = new HeaderApiVersionReader("api-version");
                
                option.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("api-version"));

            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";

                options.SubstituteApiVersionInUrl = true;
            });

        public static void ConfigureSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(sg => 
            {
                sg.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Product Management API", 
                    Version = "v1", 
                    Description = "This is a Product Management API." 
                });

                sg.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "Product Management API",
                    Version = "v2",
                    Description = "This is a Product Management API."
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                sg.IncludeXmlComments(xmlPath);
            });
    }
}
