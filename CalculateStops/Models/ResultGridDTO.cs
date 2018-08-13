using System.Collections.Generic;

namespace CalculateStops.Models
{
    public class GridResultDTO
    {
        public string MGLTView { get; set; }
        public string Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public virtual List<ResultDTO> ResultDTO { get; set; }
    }
}