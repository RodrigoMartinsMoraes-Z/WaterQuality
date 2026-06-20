using MongoDB.Driver;

using WaterQuality.Common.Response;
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
    var connectionString = "mongodb://admin:password@localhost:27017/WaterQuality?authSource=admin";
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
    options.ListenAnyIP(8090);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

WebApplication app = builder.Build();

app.UseCors("AllowAll");
app.UseSwagger();
app.UseSwaggerUI();


#region WATER QUALITY
app.MapGet("/waterQuality", async (IWaterService service, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetAsync(cts.Token).ConfigureAwait(true);
})
.WithName("GetAllWaterQuality")
.WithDescription("Retorna todos os registros históricos de qualidade da água.")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapGet("/currentWaterQuality", async (IWaterService service, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetRealtimeAsync(cts.Token).ConfigureAwait(true);
})
.WithName("GetRealtimeWaterQuality")
.WithDescription("Retorna os registros da qualidade da água no momento atual.")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapGet("/currentDayWaterQuality", async (IWaterService service, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetCurrentDayAsync(cts.Token).ConfigureAwait(true);
})
.WithName("GetCurrentDayWaterQuality")
.WithDescription("Retorna os dados de qualidade da água para o dia atual.")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapGet("/waterQuality/{date}", async (IWaterService service, DateTime date, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetFromDayAsync(date, cts.Token).ConfigureAwait(true);
})
.WithName("GetWaterQualityByDate")
.WithDescription("Retorna os dados de qualidade da água para a data informada (yyyy-MM-dd).")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapPost("/waterQuality", async (IWaterService service, WaterQualityParameter parameter, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.SaveAsync(parameter, cts.Token).ConfigureAwait(true);
})
.WithName("SaveWaterQuality")
.WithDescription("Salva um novo registro de qualidade da água.")
.Produces<DefaultResponse>(StatusCodes.Status201Created)
.Produces<DefaultResponse>(StatusCodes.Status400BadRequest)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();
#endregion

#region ENVIRONMENT
app.MapGet("/environmentQuality", async (IEnvironmentService service, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetAsync(cts.Token).ConfigureAwait(true);
})
.WithName("GetAllEnvironmentQuality")
.WithDescription("Retorna todos os registros históricos de qualidade ambiental.")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapGet("/currentenvironmentQuality", async (IEnvironmentService service, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetRealtimeAsync(cts.Token).ConfigureAwait(true);
})
.WithName("GetRealtimeEnvironmentQuality")
.WithDescription("Retorna os registros da qualidade ambiental no momento atual.")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapGet("/currentDayEnvironmentQuality", async (IEnvironmentService service, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetCurrentDayAsync(cts.Token).ConfigureAwait(true);
})
.WithName("GetCurrentDayEnvironmentQuality")
.WithDescription("Retorna os dados de qualidade ambiental para o dia atual.")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapGet("/environmentQuality/{date}", async (IEnvironmentService service, DateTime date, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.GetFromDayAsync(date, cts.Token).ConfigureAwait(true);
})
.WithName("GetEnvironmentQualityByDate")
.WithDescription("Retorna os dados de qualidade ambiental para a data informada (yyyy-MM-dd).")
.Produces<DefaultResponse>(StatusCodes.Status200OK)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();

app.MapPost("/environmentQuality", async (IEnvironmentService service, EnvironmentalParameter parameter, CancellationToken ct = default) =>
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
    cts.CancelAfter(TimeSpan.FromSeconds(20));
    return await service.SaveAsync(parameter, cts.Token).ConfigureAwait(true);
})
.WithName("SaveEnvironmentQuality")
.WithDescription("Salva um novo registro de qualidade ambiental.")
.Produces<DefaultResponse>(StatusCodes.Status201Created)
.Produces<DefaultResponse>(StatusCodes.Status400BadRequest)
.Produces<DefaultResponse>(StatusCodes.Status500InternalServerError)
.WithOpenApi();
#endregion

await app.RunAsync().ConfigureAwait(true);