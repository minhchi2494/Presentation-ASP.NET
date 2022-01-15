using CustomerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) :base(options)
        {
        }
        public DbSet<CustomerSetting> Settings { get; set;}
        public DbSet<CustomerAttribute> Attributes { get; set;}
    }
}
