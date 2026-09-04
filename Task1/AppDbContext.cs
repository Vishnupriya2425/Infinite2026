using System.Data.Entity;
using Task1.Models;

namespace Task1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        { }
        public DbSet<ClaimsReprocessing>ClaimsReprocessing { get; set; }
    }
}