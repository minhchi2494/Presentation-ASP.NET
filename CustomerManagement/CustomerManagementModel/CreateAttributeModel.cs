using CustomerManagementModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementModel
{
    public  class CreateAttributeModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string AttributeMaster { get; set; }

        public string Parent { get; set; }

        [Required(ErrorMessage = "Code is required.")]
        [MaxLength(2, ErrorMessage = "Maximum {1} characters is allowed.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(80, ErrorMessage = "Maximum {1} characters is allowed.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Shortname is required.")]
        [MaxLength(40, ErrorMessage = "Maximum {1} characters is allowed.")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Effective date is required.")]
        public DateTime EffectiveDate { get; set; }

        public DateTime ValidUntil { get; set; }

        [Required(ErrorMessage = "This is required.")]
        public bool IsCustomerAttribute { get; set; }

        [Required(ErrorMessage = "This is required.")]
        public bool IsDistributorAttribute { get; set; }
    }
}
