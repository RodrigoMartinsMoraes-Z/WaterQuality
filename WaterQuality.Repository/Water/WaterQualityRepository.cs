using MongoDB.Bson;
using MongoDB.Driver;

using WaterQuality.Domain.Water;
using WaterQuality.Interfaces.Context;

namespace WaterQuality.Repository.Water;
public class WaterQualityRepository(IMongoDbContext db)
{
    private readonly IMongoDbContext _db = db;

    public async Task<WaterQualityParameter> Get (long id)
    {
        FilterDefinition<WaterQualityParameter> filter = Builders<WaterQualityParameter>.Filter.Where(w => w.Id == id);

        return await _db.WaterQualityParameters.FindAsync(filter).Result.FirstOrDefaultAsync();
    }

    public async Task<WaterQualityParameter> Get (DateTime date)
    {
        FilterDefinition<WaterQualityParameter> filter = Builders<WaterQualityParameter>.Filter.Where(w => w.Date >= date);

        return await _db.WaterQualityParameters.FindAsync(filter).Result.FirstOrDefaultAsync();
    }

    public async Task<ICollection<WaterQualityParameter>> Get() => await _db.WaterQualityParameters.FindAsync(new BsonDocument()).Result.ToListAsync();
}
