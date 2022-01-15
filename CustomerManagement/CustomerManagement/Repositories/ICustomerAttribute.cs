using CustomerManagement.Models;
using CustomerManagementModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Repositories
{
    public interface ICustomerAttribute
    {
        Task<IEnumerable<CustomerAttribute>> GetAttributeList(SearchAttributes searchAttributes);
        Task<CustomerAttribute> Create(CustomerAttribute entity);
        Task Update(CustomerAttribute entity);
        Task<CustomerAttribute> Delete(CustomerAttribute entity);
        Task<CustomerAttribute> GetById(Guid id);
    }
}
