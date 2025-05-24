namespace WaterQuality.DashBoard.Shared.Models;
public class WaterQualityReading
{
    public DateTime Timestamp { get; set; }
    public float Temperature { get; set; }
    public float Ph { get; set; }
    public float Tds { get; set; }
}
