using MongoDB.Bson;
using MongoDB.Driver;

using WaterQuality.Domain.Water;
using WaterQuality.Interfaces.Context;
using WaterQuality.Interfaces.Repository;

namespace WaterQuality.Repository.Water;
public class WaterQualityRepository(IMongoDbContext db) : IWaterQualityRepository
{
    private readonly IMongoDbContext _db = db;

    public async Task<ICollection<WaterQualityParameter>> Get() => await _db.WaterQualityParameters.FindAsync(new BsonDocument()).Result.ToListAsync();

    public async Task<WaterQualityParameter> Get(DateTime date)
    {
        var startOfDay = date.Date;
        var endOfDay = startOfDay.AddDays(1).AddMilliseconds(-1);

        FilterDefinition<WaterQualityParameter> filter = Builders<WaterQualityParameter>.Filter.And(Builders<WaterQualityParameter>.Filter.Gte(w => w.Date, startOfDay),
                                                                                                    Builders<WaterQualityParameter>.Filter.Lt(w => w.Date, endOfDay));

        return await _db.WaterQualityParameters.FindAsync(filter).Result.FirstOrDefaultAsync();
    }

    public async Task Save(WaterQualityParameter waterQuality) => await _db.WaterQualityParameters.InsertOneAsync(waterQuality);
}
