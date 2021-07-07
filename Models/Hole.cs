using System.Collections.Generic;

namespace HeresTheGreenAPI.Models
{
    public class Hole
    {
        public int Number { get; set; }
        public int Par { get; set; }
        public GPSCoordinates Green { get; set; }
        public IEnumerable<GPSCoordinates> Bunkers { get; set; }
        public IEnumerable<GPSCoordinates> WaterHazards { get; set; }
    }

    public class GPSCoordinates
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }
}