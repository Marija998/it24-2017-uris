using Microsoft.EntityFrameworkCore;
using TransactionServiceAPI.Models;
using Account = TransactionServiceAPI.Models.Account;

namespace TransactionServiceAPI.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionAmount)
                    .HasPrecision(18, 2); // Setting precision because of EF warning
            });

            modelBuilder.Entity<Account>().HasData(
            new Account { AccountNumber = 1, Balance = 1000, Currency = "USD", IsActive = true, UserId = 1 },
            new Account { AccountNumber = 2, Balance = 500, Currency = "EUR", IsActive = true, UserId = 2 }
        );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    TransactionId = 1,
                    SourceAccount = 1,
                    DestinationAccount = 2,
                    Date = DateTime.UtcNow,
                    TransactionAmount = 100,
                    TransactionStatus = TranStatus.Success
                },
                new Transaction
                {
                    TransactionId = 2,
                    SourceAccount = 2,
                    DestinationAccount = 1,
                    Date = DateTime.UtcNow.AddDays(-1),
                    TransactionAmount = 50,
                    TransactionStatus = TranStatus.Failed
                }
            );


        }


    }
}
