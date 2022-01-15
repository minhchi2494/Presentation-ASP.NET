using DemoDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoDotNetCore.ConnectDB
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer_Attribute> Customer_Attribute { get; set; }
    }
}
