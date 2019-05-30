using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection")
        { }

        public DbSet<Employees> Employee { get; set; }
    }
}