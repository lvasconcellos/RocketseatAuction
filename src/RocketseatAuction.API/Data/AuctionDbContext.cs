using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=auctionsNLW.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding Auctions
            modelBuilder.Entity<Auction>().HasData(
                new Auction
                {
                    Id = 1,
                    Name = "Electronics Auction",
                    Starts = new DateTime(2024, 1, 1, 12, 0, 0),
                    Ends = new DateTime(2024, 1, 7, 12, 0, 0),
                });

            // Seeding Items
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Laptop",
                    Brand = "BrandX",
                    Condition = 1, // Assuming 1 represents 'New'
                    BestPrice = 500.00m,
                    AuctionId = 1,
                },
                new Item
                {
                    Id = 2,
                    Name = "Smartphone",
                    Brand = "BrandY",
                    Condition = 2, // Assuming 2 represents 'Used'
                    BestPrice = 300.00m,
                    AuctionId = 1,
                });
        }
    }
}
