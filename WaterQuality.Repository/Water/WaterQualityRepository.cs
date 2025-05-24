using MongoDB.Bson;
using MongoDB.Driver;

using WaterQuality.Domain.Water;
using WaterQuality.Interfaces.Context;
using WaterQuality.Interfaces.Repository;

namespace WaterQuality.Repository.Water;
public class WaterQualityRepository(IMongoDbContext db)
: IWaterQualityRepository
{
    private readonly IMongoDbContext _db = db;

    public async Task<ICollection<WaterQualityParameter>> GetAsync(CancellationToken cancellationToken = default) => await _db.WaterQualityParameters.FindAsync(new BsonDocument()).Result.ToListAsync(cancellationToken);

    public async Task<ICollection<WaterQualityParameter>> GetAsync(DateTime date, CancellationToken cancellationToken = default)
    {
        var startOfDay = date.Date;
        var endOfDay = startOfDay.AddDays(1).AddMilliseconds(-1);

        FilterDefinition<WaterQualityParameter> filter = Builders<WaterQualityParameter>.Filter.And(Builders<WaterQualityParameter>.Filter.Gte(w => w.Date, startOfDay),
                                                                                                    Builders<WaterQualityParameter>.Filter.Lt(w => w.Date, endOfDay));

        return await _db.WaterQualityParameters.FindAsync(filter).Result.ToListAsync(cancellationToken);
    }

    public async Task SaveAsync(WaterQualityParameter waterQuality, CancellationToken cancellationToken = default) => await _db.WaterQualityParameters.InsertOneAsync(waterQuality with { Date = DateTime.Now }, cancellationToken: cancellationToken);
}
