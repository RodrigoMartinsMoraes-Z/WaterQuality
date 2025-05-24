using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterQuality.DashBoard.Shared.Models
{
    class EnvironmentReading
    {
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
}
