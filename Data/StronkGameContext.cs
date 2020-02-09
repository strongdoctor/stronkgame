using Microsoft.EntityFrameworkCore;

namespace stronkgame
{
    public class StronkGameContext : DbContext
    {
        public DbSet<Placement> Placements { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=stronkgame.db");
    }

    public class Placement
    {
        public int PlacementId { get; set; }
        public string ColorCode { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}