using DemoDotNetCore.Models;
using System.Collections.Generic;

namespace DemoDotNetCore.Services.Attribute
{
    public class ICustomer_Attribute_Service
    {
        List<Customer_Attribute> findAll();
        Customer_Attribute findOne(string id);
        void AddCustomerAttribute(Customer_Attribute ca);
        void UpdateCustomerAttribute(Customer_Attribute ca);
        bool DeleteCustomerAttribute(string id);
    }
}
