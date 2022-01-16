using PracticeMVC.ConnectDB;
using PracticeMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace PracticeMVC.Services
{
    public class Customer_Attribute_Service : ICustomer_Attribute
    {
        private CustomerContext context;

        public Customer_Attribute_Service(CustomerContext context)
        {
            this.context = context;
        }

        public void AddCustomerAttribute(Customer_Attribute ca)
        {
            context.Customer_Attribute.Add(ca);
            context.SaveChanges();
        }

        public bool DeleteCustomerAttribute(string id)
        {
            Customer_Attribute ca = context.Customer_Attribute.SingleOrDefault(c => c.Attribute_Id.Equals(id));
            if (ca != null)
            {
                context.Remove(ca);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Customer_Attribute> findAll()
        {
            return context.Customer_Attribute.ToList();
        }

        public Customer_Attribute findOne(string id)
        {
            Customer_Attribute _Attribute = context.Customer_Attribute.SingleOrDefault(c=>c.Attribute_Id.Equals(id));
            if (_Attribute != null)
            {
                return _Attribute;
            }
            else { return null; }
        }

        public void UpdateCustomerAttribute(Customer_Attribute ca)
        {
            Customer_Attribute editAtrribute = context.Customer_Attribute.SingleOrDefault(c => c.Attribute_Id.Equals(ca.Attribute_Id));
            if (editAtrribute != null)
            {
                editAtrribute.Attribute_Master = editAtrribute.Attribute_Master;
                editAtrribute.Attribute_Value_Code = editAtrribute.Attribute_Value_Code;
                editAtrribute.Description = editAtrribute.Description;
                editAtrribute.Short_Name = editAtrribute.Short_Name;
                editAtrribute.Parent = editAtrribute.Parent;
                editAtrribute.Effective_Date = editAtrribute.Effective_Date;
                editAtrribute.Valid_Until = editAtrribute.Valid_Until;
                context.SaveChanges();
            }
            else
            {
               //do notthing
            }
        }
    }
}
