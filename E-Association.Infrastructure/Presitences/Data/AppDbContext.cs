using Domain.Entities.Business;
using Domain.Entities.Securities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace E_Association.Infrastructure.Presitence.Data
{
    public class AppDbContext : IdentityDbContext<Consumer, IdentityRole<Guid>, Guid>
    {

        public AppDbContext(DbContextOptions<AppDbContext> _options) :base(_options)
        {

        }
        public AppDbContext()
        {
           
        }

        public DbSet<Consumer> users { set; get; }
        public DbSet<Balance> Balances { set; get; }
        public DbSet<Transactions> Transactions { set; get; }
        public DbSet<Association> Associations { set; get; }
        public DbSet<Payment> Payments { set; get; }
        public DbSet<Withdrawals> Withdrawals { set; get; }
        public DbSet<Notifications> Notifications { set; get; }
        public DbSet<ConsumerAssociations> ConsumerAssociations { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CL2DPAD;Database=EAssociation;Integrated Security=true;TrustServerCertificate=true;");
        }
    }
}
