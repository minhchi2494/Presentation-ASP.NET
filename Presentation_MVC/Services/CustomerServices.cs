using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation_MVC.Models;
using Presentation_MVC.Repository;

namespace Presentation_MVC.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly CustomerContext _context;

        public CustomerServices(CustomerContext context)
        {
            _context = context;
        }

        public List<Customer_Setting> getAllCustomer()
        {
            return _context.Customer_Settings.ToList();
        }

        public Customer_Setting getCustomer(string id)
        {
            var customer = _context.Customer_Settings.SingleOrDefault(c=>c.AttributeID.Equals(id));
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }
        public void addCustomer(Customer_Setting newCustomer)
        {
            var customer = _context.Customer_Settings.SingleOrDefault(c => c.AttributeID.Equals(newCustomer.AttributeID));
            if (customer == null)
            {
                _context.Customer_Settings.Add(newCustomer);
                _context.SaveChanges();
            }
        }

        public void editCustomer(Customer_Setting editCustomer)
        {
            var customer = _context.Customer_Settings.SingleOrDefault(c => c.AttributeID.Equals(editCustomer.AttributeID));
            if (customer != null)
            {
                customer.AttributeName = editCustomer.AttributeName;
                customer.Description = editCustomer.Description;
                customer.IsDistributorAttribute = editCustomer.IsDistributorAttribute;
                customer.IsCustomerAttribute = editCustomer.IsCustomerAttribute;
                customer.Used = editCustomer.Used;
                _context.SaveChanges();
            }
        }

        public bool deleteCustomer(string id)
        {
            var customer = _context.Customer_Settings.SingleOrDefault(c=>c.AttributeID.Equals(id)); 
            if (customer != null)
            {
                _context.Remove(customer);
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
