using System.Collections.Generic;

namespace CalculateStops.Models
{
    public class GridResultDTO
    {
        public string MGLTView { get; set; }
        public string count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public virtual List<ResultDTO> resultDTO { get; set; }
    }
}