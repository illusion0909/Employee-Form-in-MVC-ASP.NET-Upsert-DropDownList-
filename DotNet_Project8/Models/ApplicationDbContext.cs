using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DotNet_Project8.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("conStr")
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}