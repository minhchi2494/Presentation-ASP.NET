using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerManagement.Models
{
    public class CustomerAttribute
    {
        [Key]
        public Guid AttriId { get; set; }
        public string AttributeMaster { get; set; }
        public string Parent { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ValidUntil { get; set; }
        [ForeignKey("Id")]
        public Guid Id { get; set; }

       
    }
}
