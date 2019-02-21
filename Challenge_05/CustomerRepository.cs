using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_05
{
     public class CustomerRepository
    {
        public List<Customer> customerList = new List<Customer>();
        int customerCount = 0;
        public List<Customer> GetList()
        {
            return customerList;
        }
         public void AddCustomer(string first, string last, int typeNum)
        {
            customerCount = customerCount + 1;
            Customer newCustomer = new Customer(customerCount, first, last, typeNum);
            customerList.Add(newCustomer);
        }
        public void RemoveCustomer(int customerID)
        {
            int idNum = customerID;
            idNum = idNum - 1;
            customerList.Remove(customerList[idNum]);
            Recount();
            customerCount = customerCount - 1;
        }
        public void Recount()
        {
            foreach (Customer customer in customerList)
            {
                customer.UserID = (customerList.IndexOf(customer) + 1);
            }
        }

        

    }
}
