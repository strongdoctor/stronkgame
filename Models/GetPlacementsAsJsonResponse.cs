using System.Collections.Generic;
using System.Linq;

namespace stronkgame.Models
{
    public class GetPlacementsAsJsonResponse
    {
        public GetPlacementsAsJsonResponse(
            IEnumerable<PlacementResponse> placements
        )
        {
            Placements = placements;
            Length = placements.Count();
        }

        public IEnumerable<PlacementResponse> Placements { get; }
        public int Length { get; set; }
    }

    public class PlacementResponse
    {
        public string ColorCode { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}