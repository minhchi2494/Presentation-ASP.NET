using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PracticeMVC.Models;

namespace PracticeMVC.ConnectDB
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

       public DbSet<Customer_Attribute> Customer_Attribute { get; set; }
       public DbSet<Customer_Setting> Customer_Setting { get; set; } 
    }
}
