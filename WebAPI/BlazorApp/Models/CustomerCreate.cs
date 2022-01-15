using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlazorApp.Models
{
    public class CustomerCreate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Attribute Master is required")]
        [StringLength(50)]
        public string AttributeMaster { get; set; }

        [Required]
        [StringLength(2)]
        public string AttributeValuesCode { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(80)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Short Name is required")]
        [StringLength(40)]
        public string ShortName { get; set; }


        [StringLength(50)]
        public string Parent { get; set; }

        public DateTime EffectiveDate { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
