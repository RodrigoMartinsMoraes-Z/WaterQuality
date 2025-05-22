namespace WaterQuality.Domain.Water;
public record WaterQualityParameter(float Tds = 0, decimal Temperature = 0, decimal Ph = 0, DateTime Date = default);
