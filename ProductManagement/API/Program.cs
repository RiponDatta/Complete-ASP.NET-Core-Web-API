using API.Extensions;
using LoggerService;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup(option =>
    option.LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config")));

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServices();
builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
