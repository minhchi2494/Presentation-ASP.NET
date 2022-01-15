using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Dm1.Models.Dm;

namespace Dm1.Data
{
  public partial class DmContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public DmContext(DbContextOptions<DmContext> options):base(options)
    {
    }

    public DmContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Dm1.Models.Dm.Attribute>()
              .HasOne(i => i.Setting)
              .WithMany(i => i.Attributes)
              .HasForeignKey(i => i.SettingId)
              .HasPrincipalKey(i => i.AttributeID);


        builder.Entity<Dm1.Models.Dm.Attribute>()
              .Property(p => p.EffectiveDate)
              .HasColumnType("datetime");

        builder.Entity<Dm1.Models.Dm.Attribute>()
              .Property(p => p.ValidUntil)
              .HasColumnType("datetime");
        this.OnModelBuilding(builder);
    }


    public DbSet<Dm1.Models.Dm.Attribute> Attributes
    {
      get;
      set;
    }

    public DbSet<Dm1.Models.Dm.Setting> Settings
    {
      get;
      set;
    }
  }
}
