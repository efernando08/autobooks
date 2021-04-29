using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Data.json
{

    public class CustomerList
    {
        public Customer[] Customers { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
