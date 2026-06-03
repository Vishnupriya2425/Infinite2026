using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_CodeFirstApproach.Models
{
    public class MovieContext:DbContext
    {
        public MovieContext():base("MoviesDB"){ }
        public DbSet<Movie> Movies { get; set; }
    }
}