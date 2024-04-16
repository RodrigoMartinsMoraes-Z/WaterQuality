using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

using WaterQuality.Domain.Environment;
using WaterQuality.Domain.Water;
using WaterQuality.Interfaces.Context;

namespace WaterQuality.Context.MongoContext;
public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _db;

    public MongoDbContext(string connectionString, string dbName)
    {
        var client = new MongoClient(connectionString);
        _db = client.GetDatabase(dbName);

        var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
        ConventionRegistry.Register("IgnoreId", conventionPack, type => true);
    }

    public IMongoCollection<EnvironmentalParameter> EnvironmentalParameters => _db.GetCollection<EnvironmentalParameter>("EnvironmentalParameters");
    public IMongoCollection<WaterQualityParameter> WaterQualityParameters => _db.GetCollection<WaterQualityParameter>("WaterQualityParameters");
}
