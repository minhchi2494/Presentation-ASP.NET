using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation_MVC.Models;

namespace Presentation_MVC.Services
{
    public interface ICustomerServices
    {
        List<Customer_Setting> getAllCustomer();
        Customer_Setting getCustomer(string id);
        void addCustomer(Customer_Setting newCustomer);
        void editCustomer(Customer_Setting editCustomer);
    }
}
