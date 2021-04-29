using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Data
{
    public interface CustomerRepository
    {
        IEnumerable<Customer> GetList();
        Customer Create(string name);
        Customer Get(int id);
        void Update(Customer customer);
        bool Delete(int id);
    }
}
