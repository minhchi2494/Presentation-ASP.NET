using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace WebAPI.Repository
{
    public class CustomerAttributeContext : DbContext
    {
        public CustomerAttributeContext(DbContextOptions options) : base(options) { }

        public DbSet<CustomerAttributeModel> CustomerAttributeModels { get; set; }
    }
}
