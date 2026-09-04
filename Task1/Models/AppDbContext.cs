using System.Collections.Generic;
using System.Data.Entity;

namespace Task1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(): base("DefaultConnection")
        {
        }

        public DbSet <ClaimsReprocessing> ClaimsReprocessing { get; set;}
    }
}