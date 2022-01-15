using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementModel
{
    public class SettingCreateRequest
    {
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
    }
}
