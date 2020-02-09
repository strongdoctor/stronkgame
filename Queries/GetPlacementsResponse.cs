using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace stronkgame.Queries
{
    public class GetPlacementsResponse
    {
        public GetPlacementsResponse(IEnumerable<Placement> placements)
        {
            Placements = placements;
        }
        public IEnumerable<Placement> Placements { get; }
    }
}