using CustomerManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Repositories
{
    public interface ICustomerSetting<T> where T:class
    {
        Task<IEnumerable<T>> GetList();
        Task<T> Create(T entity);
        Task Update(T entity);
        Task<T> Delete(T entity);
        Task<T> GetById(Guid id);
    }
}
