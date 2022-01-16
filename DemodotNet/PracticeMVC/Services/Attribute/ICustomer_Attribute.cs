using PracticeMVC.Models;
using System.Collections.Generic;

namespace PracticeMVC.Services
{
    public interface ICustomer_Attribute
    {
        List<Customer_Attribute> findAll();
        Customer_Attribute findOne(string id);
        void AddCustomerAttribute(Customer_Attribute ca);
        void UpdateCustomerAttribute(Customer_Attribute ca);
        bool DeleteCustomerAttribute(string id);
    }
}
