using Asp.Versioning;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

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
    }
}
