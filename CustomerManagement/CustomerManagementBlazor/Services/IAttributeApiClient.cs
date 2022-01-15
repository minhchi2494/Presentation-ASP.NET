using CustomerManagementModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagementBlazor.Services
{
    public interface IAttributeApiClient
    {
        Task<List<AttributeDTO>> GetAttributeList(SearchAttributes searchAttributes);
        Task<bool> CreateAttribute(CreateAttributeModel request);
    }
}
