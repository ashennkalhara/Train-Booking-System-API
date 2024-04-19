using Microsoft.EntityFrameworkCore;
using TrainAPI.Model;
namespace TrainAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Train> trains { get; set; }

        public DbSet<User> users { get; set; }

        public DbSet<Booking> bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=DESKTOP-R2LI9NO;" +
                "Initial Catalog=TrainBookingDB;" +
                "Persist Security Info=True;" +
                "User ID=sa;Password=1234;" +
                "Trust Server Certificate=True;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";
            
                optionsBuilder.UseSqlServer(conn);
        }
    }
}
