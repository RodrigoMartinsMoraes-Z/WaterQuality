namespace WaterQuality.Domain.Water;
public record WaterQualityParameter(int Tds = 0, decimal Temperature = 0, decimal Ph = 0)
{
    public DateTime Date { get; } = DateTime.Now;
}
