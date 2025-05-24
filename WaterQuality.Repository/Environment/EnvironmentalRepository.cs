using MongoDB.Bson;
using MongoDB.Driver;

using WaterQuality.Domain.Environment;

using WaterQuality.Interfaces.Context;
using WaterQuality.Interfaces.Repository;

namespace WaterQuality.Repository.Environment;
public class EnvironmentalRepository(IMongoDbContext db)
: IEnvironmentalRepository
{
    private readonly IMongoDbContext _db = db;

    public async Task<ICollection<EnvironmentalParameter>> GetAsync(CancellationToken cancellationToken = default) => await _db.EnvironmentalParameters.FindAsync(new BsonDocument()).Result.ToListAsync(cancellationToken);

    public async Task<ICollection<EnvironmentalParameter>> GetAsync(DateTime date, CancellationToken cancellationToken = default)
    {
        var startOfDay = date.Date;
        var endOfDay = startOfDay.AddDays(1).AddMilliseconds(-1);

        FilterDefinition<EnvironmentalParameter> filter = Builders<EnvironmentalParameter>.Filter.And(Builders<EnvironmentalParameter>.Filter.Gte(w => w.Date, startOfDay),
                                                                                                    Builders<EnvironmentalParameter>.Filter.Lt(w => w.Date, endOfDay));

        return await _db.EnvironmentalParameters.FindAsync(filter).Result.ToListAsync(cancellationToken);
    }

    public async Task SaveAsync(EnvironmentalParameter environmental, CancellationToken cancellationToken = default) => await _db.EnvironmentalParameters.InsertOneAsync(environmental with { Date = DateTime.Now }, cancellationToken: cancellationToken);
}
