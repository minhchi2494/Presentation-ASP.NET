using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ICustomerAttributeService
    {
        Task<List<CustomerAttributeModel>> GetAll(CustomerSearch customerSearch);
        Task<CustomerAttributeModel> GetOne(int id);
        Task<bool> Create(CustomerAttributeModel newCust);
        Task<bool> Edit(CustomerAttributeModel editCust);
        Task<bool> Delete(int id);
    }
}
