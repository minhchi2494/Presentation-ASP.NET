using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementModel
{
    public class AttributeDTO
    {
        public Guid AttriId { get; set; }
        public string AttributeMaster { get; set; }
        public string Parent { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
