using BDD.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BDD.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
		public DbSet<Product> Products { get; set; }
		public DbSet<Entities.Version> Versions { get; set; }
		public DbSet<OS> OS { get; set; }
		public DbSet<ProductVersionOS> ProductVersionOS { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Status> Status { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
