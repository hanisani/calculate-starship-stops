using System.Collections.Generic;

namespace CalculateStops.Models
{
    public class GridDTO
    {
        public string Count { get;set;}
        public string Next { get; set; }
        public string Previous { get; set; }
        public virtual List<StartshipDTO> Results { get; set; }
    }
}