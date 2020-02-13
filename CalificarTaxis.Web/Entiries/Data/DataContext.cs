using Microsoft.EntityFrameworkCore;

namespace CalificarTaxis.Web.Entiries.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }
        public DbSet<TaxiEntity> taxiEntities { get; set; }
        public DbSet<TripEntity> trips { get; set; }
        public DbSet<TripDetailEntity> tripDetails { get; set; }
    }
}
