using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Models
{
    public class CustomerSetting
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string AttributeId { get; set; }

        [Required]
        [MaxLength(30)]
        public string AttributeName { get; set; }

        [Required]
        [MaxLength(40)]
        public string Description { get; set; }

        public bool IsDistributorAttribute { get; set; }

        public bool IsCustomerAttribute { get; set; }

        public bool Used { get; set; }

        public ICollection<CustomerAttribute> CustomerAttributes { get; set; }
    }
}
