using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dm1.Models.Dm
{
  [Table("Setting", Schema = "dbo")]
  public partial class Setting
  {
    [Key]
    public string AttributeID
    {
      get;
      set;
    }

    public ICollection<Attribute> Attributes { get; set; }
    public string AttributeName
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public bool IsDistributorAttribute
    {
      get;
      set;
    }
    public bool IsCustomerAttribute
    {
      get;
      set;
    }
    public bool Used
    {
      get;
      set;
    }
  }
}
