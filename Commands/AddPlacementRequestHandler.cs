using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace stronkgame.Commands
{
    public class GetPlacementsRequestHandler : IRequestHandler<AddPlacementRequest, AddPlacementResponse>
    {
        private readonly StronkGameContext _context;
        public GetPlacementsRequestHandler(
            StronkGameContext context
        )
        {
            _context = context;
        }
        public async Task<AddPlacementResponse> Handle(AddPlacementRequest request, CancellationToken cancellationToken)
        {
            if (
                string.IsNullOrWhiteSpace(request.ColorCode)
                || request.ColorCode.Length != 7
                || request.ColorCode[0] != '#'
            )
            {
                throw new ArgumentException("ColorCode is invalid. Expected format: #FF4400");
            }

            var allowedColorChars = "0123456789ABCDEF".ToCharArray();

            var colorCharsValid = request.ColorCode
                .Substring(1, request.ColorCode.Length - 1)
                .All(p => allowedColorChars.Contains(p));

            if (!colorCharsValid)
                throw new ArgumentException("ColorCode contains invalid characters.");

            var existingPlacement = _context.Placements
                .Where(p => p.XPosition == request.XPosition)
                .Where(p => p.YPosition == request.YPosition)
                .SingleOrDefault();

            if (existingPlacement == null)
            {
                var newPlacement = new Placement(
                    request.ColorCode,
                    request.XPosition,
                    request.YPosition
                );

                _context.Placements.Add(newPlacement);
                await _context.SaveChangesAsync();

                return new AddPlacementResponse()
                {
                    PlacementId = newPlacement.PlacementId,
                    ColorCode = newPlacement.ColorCode,
                    XPosition = newPlacement.XPosition,
                    YPosition = newPlacement.YPosition
                };
            }
            else
            {
                existingPlacement.ColorCode = request.ColorCode;
                await _context.SaveChangesAsync();
                return new AddPlacementResponse()
                {
                    PlacementId = existingPlacement.PlacementId,
                    ColorCode = existingPlacement.ColorCode,
                    XPosition = existingPlacement.XPosition,
                    YPosition = existingPlacement.YPosition
                };
            }
        }
    }
}