using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
