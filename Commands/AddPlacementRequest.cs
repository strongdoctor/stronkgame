using MediatR;

namespace stronkgame.Commands
{
    public class AddPlacementRequest : IRequest<AddPlacementResponse>
    {
        public AddPlacementRequest(
            string colorCode,
            int xPosition,
            int yPosition
        )
        {
            ColorCode = colorCode;
            XPosition = xPosition;
            YPosition = yPosition;
        }
        public string ColorCode { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}