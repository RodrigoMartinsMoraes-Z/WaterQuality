using MongoDB.Driver;

using WaterQuality.Context.MongoContext;
using WaterQuality.Domain.Environment;
using WaterQuality.Domain.Water;
using WaterQuality.Interfaces.Context;
using WaterQuality.Interfaces.Repository;
using WaterQuality.Interfaces.Services;
using WaterQuality.Repository.Environment;
using WaterQuality.Repository.Water;
using WaterQuality.Services.Environment;
using WaterQuality.Services.Water;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoDbContext>(sp =>
{
    var connectionString = "mongodb://192.168.0.65:27017";
    var dbName = "WaterQuality";
    return new MongoDbContext(connectionString, dbName);
});

builder.Services.AddScoped<IEnvironmentalRepository, EnvironmentalRepository>();
builder.Services.AddScoped<IWaterQualityRepository, WaterQualityRepository>();
builder.Services.AddScoped<IEnvironmentService, EnvironmentService>();
builder.Services.AddScoped<IWaterService, WaterService>();

// Configure Kestrel to listen on a specific port
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


#region WATER QUALITY
app.MapGet("/waterQuality", (IWaterService service) =>
{
    return service.Get();
})
.WithName("waterQuality")
.WithOpenApi();

app.MapGet("/currentWaterQuality", (IWaterService service) =>
{
    return service.GetRealtime();
})
.WithName("currentWaterQuality")
.WithOpenApi();

app.MapGet("/currentDayWaterQuality", (IWaterService service) =>
{
    return service.GetCurrentDay();
})
.WithName("currentDayWaterQuality")
.WithOpenApi();

app.MapGet("/waterQuality/{date}", (IWaterService service, DateTime date) =>
{
    return service.GetFromDay(date);
})
.WithName("waterQualityDate")
.WithOpenApi();

app.MapPost("/waterQuality/", (IWaterService service, WaterQualityParameter parameter) =>
{
    return service.Save(parameter);
})
.WithName("saveWaterQuality")
.WithOpenApi();
#endregion
#region ENVIRONMENT
app.MapGet("/environmentQuality", (IEnvironmentService service) =>
{
    return service.Get();
})
.WithName("GetenvironmentQuality")
.WithOpenApi();

app.MapGet("/currentenvironmentQuality", (IEnvironmentService service) =>
{
    return service.GetRealtime();
})
.WithName("GetcurrentEnvironmentQuality")
.WithOpenApi();

app.MapGet("/currentDayEnvironmentQuality", (IEnvironmentService service) =>
{
    return service.GetCurrentDay();
})
.WithName("GetcurrentDayEnvironmentQuality")
.WithOpenApi();

app.MapGet("/environmentQuality/{date}", (IEnvironmentService service, DateTime date) =>
{
    return service.GetFromDay(date);
})
.WithName("GetenvironmentQualityDate")
.WithOpenApi();

app.MapPost("/environmentQuality/", (IEnvironmentService service, EnvironmentalParameter parameter) =>
{
    return service.Save(parameter);
})
.WithName("PostenvironmentQuality")
.WithOpenApi();
#endregion

app.Run();