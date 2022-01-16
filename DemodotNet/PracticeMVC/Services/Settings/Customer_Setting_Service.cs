using PracticeMVC.ConnectDB;
using PracticeMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace PracticeMVC.Services
{
    public class Customer_Setting_Service : ICustomer_Setting
    {
        private  CustomerContext context;

        public Customer_Setting_Service(CustomerContext context)
        {
            this.context = context;
        }

        //public void AddCustomerSetting(Customer_Setting cs)
        //{
        //    context.Customer_Setting.Add(cs);
        //    context.SaveChanges();
        //}

        //public bool DeleteCustomerSetting(string id)
        //{
        //    Customer_Setting cs = context.Customer_Setting.SingleOrDefault(c => c.Attribute_ID.Equals(id));
        //    if (cs != null)
        //    {
        //        context.Remove(cs);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public List<Customer_Setting> GetCustomer_Setting()
        {
            return context.Customer_Setting.ToList();
        }
    }
}
