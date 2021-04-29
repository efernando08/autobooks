using GroceryStore.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GroceryStore.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetList()
        {
            var customerService = new CustomerService(new Data.json.CustomerRepository());

            var customerList = customerService.GetList();

            Assert.AreEqual(3, customerList.Count());
        }

        [TestMethod]
        public void Create()
        {
            var customerService = new CustomerService(new Data.json.CustomerRepository());

            var newCustomer = customerService.Create("John");

            Assert.AreNotEqual(0, newCustomer.Id);
            Assert.AreEqual("John", newCustomer.Name);

            var customerList = customerService.GetList();

            Assert.AreEqual(4, customerList.Count());
        }

        [TestMethod]
        public void Get()
        {
            var customerService = new CustomerService(new Data.json.CustomerRepository());

            var customer = customerService.Get(2);

            Assert.AreEqual("Mary", customer.Name);
        }

        [TestMethod]
        public void Update()
        {
            var customerService = new CustomerService(new Data.json.CustomerRepository());

            var customer = customerService.Get(2);
            customer.Name = "Sally";
            customerService.Update(customer);

            customer = customerService.Get(2);

            Assert.AreEqual("Sally", customer.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "User Name must be 64 characters or fewer.")]
        public void NameValidation()
        {
            var customerService = new CustomerService(new Data.json.CustomerRepository());

            var customer = customerService.Get(2);
            customer.Name = "This name is too long. It shouldn't me more than 64 characters, and should throw an Exception if it is";
        }

        [TestMethod]
        public void Delete()
        {
            var customerService = new CustomerService(new Data.json.CustomerRepository());

            Assert.IsTrue(customerService.Delete(2));

            var customerList = customerService.GetList();

            Assert.AreEqual(2, customerList.Count());
        }
    }
}
