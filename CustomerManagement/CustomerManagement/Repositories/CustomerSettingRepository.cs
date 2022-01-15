using CustomerManagement.Models;
using CustomerManagementModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Repositories
{
    public class CustomerSettingRepository : ICustomerSetting<CustomerSetting>
    {
        private readonly CustomerContext _context;
        public CustomerSettingRepository(CustomerContext context)
        {
            _context = context;
        }
        public async Task<CustomerSetting> Create(CustomerSetting entity)
        {
            await _context.Settings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerSetting> Delete(CustomerSetting entity)
        {
            _context.Settings.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerSetting> GetById(Guid id)
        {
            return await _context.Settings.FindAsync(id);
        }

        public async Task<IEnumerable<CustomerSetting>> GetList()
        {
            return await _context.Settings.ToListAsync();
        }

        public async Task Update(CustomerSetting entity)
        {
            _context.Settings.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
