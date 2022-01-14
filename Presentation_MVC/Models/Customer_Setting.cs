using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_MVC.Models
{
    [Table("Customer_Setting")]
    public class Customer_Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Attribute ID")]
        public string AttributeID { get; set; }

        [Required(ErrorMessage = "Attribute Name is required")]
        [Display(Name = "Attritbute Name")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Attribute Name from 2 to 30 character.")]
        public string AttributeName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Discription from 2 to 40 character.")]
        public string Description { get; set; }

        [Display(Name = "Is Distributor Attribute")]
        public bool IsDistributorAttribute { get; set; }

        [Display(Name = "Is Customer Attribute")]
        public bool IsCustomerAttribute { get; set; }

        public bool Used { get; set; }

    }
}
