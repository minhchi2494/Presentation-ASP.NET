using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Services
{
    public class CustomerAttributeService : ICustomerAttributeService
    {
        private readonly CustomerAttributeContext _context;

        public CustomerAttributeService(CustomerAttributeContext context)
        {
            _context = context;
        }


        public async Task<List<CustomerAttributeModel>> GetAll(CustomerSearch customerSearch)
        {
            var result = _context.CustomerAttributeModels.ToList();
            if (!string.IsNullOrEmpty(customerSearch.AttributeMaster))
            {
                result = result.Where(x=>x.AttributeMaster.ToLower().Contains(customerSearch.AttributeMaster.ToLower())).ToList();
                return result;
            }
            else
            {
                return result;
            }
        }

        public async Task<CustomerAttributeModel> GetOne(int id)
        {
            var cust = _context.CustomerAttributeModels.SingleOrDefault(x => x.Id.Equals(id));
            if (cust != null)
            {
                return cust;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Create(CustomerAttributeModel newCust)
        {
            var cust = _context.CustomerAttributeModels.SingleOrDefault(x => x.Id.Equals(newCust.Id));
            if (cust == null)
            {
                _context.CustomerAttributeModels.Add(newCust);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var cust = _context.CustomerAttributeModels.SingleOrDefault(x => x.Id.Equals(id));
            _context.Remove(cust);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Edit(CustomerAttributeModel editCust)
        {
            var cust = _context.CustomerAttributeModels.SingleOrDefault(x => x.Id.Equals(editCust.Id));
            if (cust != null)
            {
                cust.AttributeMaster = editCust.AttributeMaster;
                cust.AttributeValuesCode = editCust.AttributeValuesCode;
                cust.Description = editCust.Description;
                cust.ShortName = editCust.ShortName;
                cust.Parent = editCust.Parent;
                cust.EffectiveDate = editCust.EffectiveDate;
                cust.ValidUntil = editCust.ValidUntil;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
