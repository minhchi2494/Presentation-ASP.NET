using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementModel
{
    public class SettingUpdateRequest
    {
        public string AttributeId { get; set; }

        public string AttributeName { get; set; }

        public string Description { get; set; }

        public bool IsDistributorAttribute { get; set; }

        public bool IsCustomerAttribute { get; set; }
        public bool Used { get; set; }
    }
}
