using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace stronkgame.Queries
{
    public class GetPlacementsRequestHandler : IRequestHandler<GetPlacementsRequest, GetPlacementsResponse>
    {
        private readonly StronkGameContext _context;
        public GetPlacementsRequestHandler(
            StronkGameContext context
        )
        {
            _context = context;
        }
        public async Task<GetPlacementsResponse> Handle(GetPlacementsRequest request, CancellationToken cancellationToken)
        {
            return new GetPlacementsResponse(_context.Placements.AsEnumerable());
        }
    }
}