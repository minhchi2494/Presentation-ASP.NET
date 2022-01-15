using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dm1.Models.Dm
{
  [Table("Attribute", Schema = "dbo")]
  public partial class Attribute
  {
    [Key]
    public string Code
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public string ShortName
    {
      get;
      set;
    }
    public string Parent
    {
      get;
      set;
    }
    public DateTime EffectiveDate
    {
      get;
      set;
    }
    public DateTime? ValidUntil
    {
      get;
      set;
    }
    public string SettingId
    {
      get;
      set;
    }
    public Setting Setting { get; set; }
  }
}
