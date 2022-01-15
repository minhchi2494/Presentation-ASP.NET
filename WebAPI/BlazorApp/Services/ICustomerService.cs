using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerAttributeModel>> getAll(CustomerSearch customerSearch);

        Task<CustomerAttributeModel> GetOne(int id);

        Task<bool> Create(CustomerAttributeModel newCust);
        Task<bool> Edit(CustomerAttributeModel editCust);
        Task<bool> Delete(int id);
    }
}
