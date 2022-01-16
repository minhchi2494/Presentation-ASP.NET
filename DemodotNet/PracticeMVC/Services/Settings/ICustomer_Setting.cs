using PracticeMVC.Models;
using System.Collections.Generic;

namespace PracticeMVC.Services
{
    public interface ICustomer_Setting
    {
        List<Customer_Setting> GetCustomer_Setting();
        //void AddCustomerSetting(Customer_Setting cs);
        //bool DeleteCustomerSetting(string id);
    }
}
