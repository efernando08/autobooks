using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Domain
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetList();

        Customer Create(string name);

        Customer Get(int id);

        void Update(Customer customer);

        bool Delete(int id);
    }
}
