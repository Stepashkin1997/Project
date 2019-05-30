using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DBConnection")
        { }

        public DbSet<Employees> Employee { get; set; }
        public DbSet<Projects> Project { get; set; }
        public DbSet<Projects_Employees> Project_Employee { get; set; }
    }
}