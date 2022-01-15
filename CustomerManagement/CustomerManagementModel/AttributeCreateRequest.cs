using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementModel
{
    public class AttributeCreateRequest
    {
        public Guid AttriId { get; set; }
        public string AttributeMaster { get; set; }
        public string Parent { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        
    }
}
