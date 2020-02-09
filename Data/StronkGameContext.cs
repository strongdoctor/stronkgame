using Microsoft.EntityFrameworkCore;

namespace stronkgame
{
    public class StronkGameContext : DbContext
    {
        public StronkGameContext(
            DbContextOptions<StronkGameContext> options
        ) : base(options) { }
        public DbSet<Placement> Placements { get; set; }
    }

    public class Placement
    {
        public Placement(
            string colorCode,
            int xPosition,
            int yPosition
        )
        {
            ColorCode = colorCode;
            XPosition = xPosition;
            YPosition = yPosition;
        }
        public int PlacementId { get; set; }
        public string ColorCode { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}