using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;


namespace Dm1.Data
{
  public partial class DemoSecurityContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public DemoSecurityContext(DbContextOptions<DemoSecurityContext> options):base(options)
    {
    }

    public DemoSecurityContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        this.OnModelBuilding(builder);
    }

  }
}
