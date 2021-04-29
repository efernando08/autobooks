using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GroceryStore.Data.json
{
    public class CustomerRepository : Data.CustomerRepository
    {
        private readonly string FILENAME = "database.json";
        private List<Customer> customerList;

        public CustomerRepository()
        {
            var foo = Directory.GetCurrentDirectory();
            
            var jsonString = File.ReadAllText(FILENAME);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            
            customerList = new List<Customer>(JsonSerializer.Deserialize<CustomerList>(jsonString, options).Customers);
        }

        public IEnumerable<Data.Customer> GetList()
        {
            return customerList.Select(c => new Data.Customer() { Id = c.Id, Name = c.Name });
        }

        public Data.Customer Create(string name)
        {
            var customer = new Customer() { Id = customerList.Max(c => c.Id) + 1, Name = name };

            customerList.Add(customer);

            return MapJsonToDTO(customer);
        }

        public Data.Customer Get(int id)
        {
            return MapJsonToDTO(customerList.First(c => c.Id == id));
        }

        public void Update(Data.Customer customer)
        {
            var current = customerList.First(c => c.Id == customer.Id);
            current.Name = customer.Name;
        }

        public bool Delete(int id)
        {
            customerList.Remove(customerList.First(c => c.Id == id));
            return true;
        }

        private Data.Customer MapJsonToDTO(Customer customer)
        {
            return new Data.Customer() { Id = customer.Id, Name = customer.Name };
        }
    }
}
