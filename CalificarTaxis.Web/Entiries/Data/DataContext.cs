using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalificarTaxis.Web.Entiries.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)

        {

        }
        public DbSet<TaxiEntity> taxiEntities { get; set; }
        public DbSet<TripEntity> trips { get; set; }
         public DbSet<TripDetailEntity> tripDetails { get; set; }
        public DbSet<UserGroupEntity> UserGroups { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TaxiEntity>()
            .HasIndex(t => t.Plaque)
            .IsUnique();
    }
 }
}
