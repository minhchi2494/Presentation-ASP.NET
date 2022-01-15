using CustomerManagement.Models;
using CustomerManagementModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Repositories
{
    public class CustomerAttributeRepository : ICustomerAttribute
    {
        private readonly CustomerContext _context;
        public CustomerAttributeRepository(CustomerContext context)
        {
            _context = context;
        }
        public async Task<CustomerAttribute> Create(CustomerAttribute entity)
        {
            await _context.Attributes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerAttribute> Delete(CustomerAttribute entity)
        {
            _context.Attributes.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerAttribute> GetById(Guid id)
        {
            return await _context.Attributes.FindAsync(id);
        }

        public async Task<IEnumerable<CustomerAttribute>> GetAttributeList(SearchAttributes searchAttributes )
        {
            var query = _context.Attributes.AsQueryable();
            if (!string.IsNullOrEmpty(searchAttributes.AttributeMaster))
                query = query.Where(x => x.AttributeMaster.Contains(searchAttributes.AttributeMaster));
            return await query.ToListAsync();
        }

        public async Task Update(CustomerAttribute entity)
        {
            _context.Attributes.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
