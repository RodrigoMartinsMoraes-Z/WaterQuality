using MongoDB.Driver;

using WaterQuality.Domain.Environment;
using WaterQuality.Domain.Water;

namespace WaterQuality.Interfaces.Context;
public interface IMongoDbContext
{
    IMongoCollection<EnvironmentalParameter> EnvironmentalParameters { get; }
    IMongoCollection<WaterQualityParameter> WaterQualityParameters { get; }
}