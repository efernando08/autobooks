using GroceryStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroceryStore.Domain
{
    public class CustomerService : ICustomerService
    {
        private CustomerRepository customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetList()
        {
            var dtos = customerRepository.GetList();
            return dtos.Select(dto => MapDTOToModel(dto));
        }

        public Customer Create(string name)
        {
            var dto = customerRepository.Create(name);
            return MapDTOToModel(dto);
        }

        public Customer Get(int id)
        {
            var dto = customerRepository.Get(id);
            return MapDTOToModel(dto);
        }

        public void Update(Customer customer)
        {
            var dto = new Data.Customer() { Id = customer.Id, Name = customer.Name };
            customerRepository.Update(dto);
        }

        public bool Delete(int id)
        {
            return customerRepository.Delete(id);
        }

        private Customer MapDTOToModel(Data.Customer dto)
        {
            return new Customer(dto.Id, dto.Name);
        }
    }
}
