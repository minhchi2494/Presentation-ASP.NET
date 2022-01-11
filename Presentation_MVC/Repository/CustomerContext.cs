using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Presentation_MVC.Models;

namespace Presentation_MVC.Repository
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer_Setting> Customer_Settings { get; set; }
    }
}
