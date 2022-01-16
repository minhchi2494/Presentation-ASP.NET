using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeMVC.Models
{
    [Table("Customer_Attribute")]
    public class Customer_Attribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public String Attribute_Id { get; set; }

        [Required(ErrorMessage = "Attribute Name is required")]
        [StringLength(maximumLength: 2, ErrorMessage = "Attribute value code must 2 character!")]
        [Display(Name = "Attribute Value Code")]
        public string Attribute_Value_Code { get; set; }

        [Display(Name ="Attribute Master")]
        public string Attribute_Master { get; set; }     

        [Required(ErrorMessage = "Description is required")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Discription from 2 to 80 character.")]
        public string Description { get; set;}

        [Required(ErrorMessage = "Short name is required")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Short name from 2 to 40 character.")]
        [Display(Name ="Short Name")]
        public string Short_Name { get; set;}

        public string Parent { get; set;}

        [Display(Name ="Effective Date")]
        public string Effective_Date { get; set;}

        [Display(Name ="Valid Until")]

        public string Valid_Until { get; set;}
    }
}
