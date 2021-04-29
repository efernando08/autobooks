using GroceryStore.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<IEnumerable<Models.Customer>> Get()
        {
            try
            {
                var models = customerService.GetList();
                return Ok(models.Select(model => MapModelToViewModel(model)));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Models.Customer> Get(int id)
        {
            try
            {
                var model = customerService.Get(id);
                return MapModelToViewModel(model);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] string name)
        {
            try
            {
                var newCustomer = customerService.Create(name);
                return Accepted();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Models.Customer customer)
        {
            try
            {
                var current = customerService.Get(customer.Id);
                current.Name = customer.Name;
                customerService.Update(current);
                    return Ok();
            }
            catch(InvalidOperationException ex)
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                customerService.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private Models.Customer MapModelToViewModel(GroceryStore.Domain.Customer model)
        {
            return new Models.Customer() { Id = model.Id, Name = model.Name };
        }
    }
}
