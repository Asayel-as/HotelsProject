using HotelsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelsProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options): base(options) 
        { 
        }

        public DbSet<Cart> cart { get; set; }
        public DbSet<Hotel> hotel { get; set; }
        public DbSet<Invoice> invoice { get; set; }
        public DbSet<Room> room { get; set; }
        public DbSet<RoomDetails> roomDetails { get; set; }
       

    }
}
