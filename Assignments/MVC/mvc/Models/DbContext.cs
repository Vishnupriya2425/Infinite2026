using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace mvc.Models
{
    public class DbContext
    {
        public class ContactContext : DbContext
        {
            public ContactContext(DContextOptions<ContactContext> options) : base(options)


                public DbSet<Contact> Contacts { get; set; }
        }
    }
 }
