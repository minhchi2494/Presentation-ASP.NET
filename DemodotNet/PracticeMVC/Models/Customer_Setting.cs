using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace PracticeMVC.Models
{
    [Table("Customer_Setting")]
    public class Customer_Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name ="Attribute ID")]
        public string Attribute_ID { get; set; }

        [Required(ErrorMessage = "Attribute Name is required")]
        [Display(Name = "Attribute Name")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Attribute Name from 2 to 30 character.")]
        public string Attribute_Name { get; set;}

        [Required(ErrorMessage = "Description is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Discription from 2 to 40 character.")]
        public string Description { get; set;}

        [Display(Name ="Is Distributor Attribute")]
        public bool Is_Distributor_Attribute { get; set; }

        [Display(Name ="Is Customer Attribute")]
        public bool Is_Customer_Attribute { get; set; }
        public bool Used { get; set; }
    }
}
