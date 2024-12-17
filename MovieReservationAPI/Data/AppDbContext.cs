using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Model;

namespace MovieReservationAPI.Data
{//this class sets up databbase using entity framework
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //DBsets represent tables in the database
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
