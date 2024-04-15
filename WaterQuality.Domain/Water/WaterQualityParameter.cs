namespace WaterQuality.Domain.Water;
public record WaterQualityParameter(int Tds, decimal Temperature, decimal Ph)
{
    public DateTime Date { get; } = DateTime.Now;
}
