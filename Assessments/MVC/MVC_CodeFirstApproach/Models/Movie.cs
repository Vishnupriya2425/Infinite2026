using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MVC_CodeFirstApproach.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }
        public string MovieName { get; set; }
        public String DirectorName { get; set; }
        public DateTime DateOfRelease { get; set; }
    
    }
}