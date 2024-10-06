using API.Extensions;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup(option =>
    option.LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config")));

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServices();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddResponseCaching();
builder.Services.ConfigureSwagger();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(config => { 
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;

    //config.CacheProfiles.Add("10SecondsDuration", new CacheProfile { Duration = 10, Location = ResponseCacheLocation.Client });
    //config.CacheProfiles.Add("15SecondsDuration", new CacheProfile { Duration = 15, Location = ResponseCacheLocation.Any });

    var cacheProfiles = builder.Configuration.GetSection("CacheProfiles").GetChildren();

    foreach(var profile in cacheProfiles)
    {
        config.CacheProfiles.Add(profile.Key, profile.Get<CacheProfile>());
    }
});

builder.Services.ConfigureVersioning();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(s => {
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API V1");
    s.SwaggerEndpoint("/swagger/v2/swagger.json", "Product Management API V2");
});

app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
