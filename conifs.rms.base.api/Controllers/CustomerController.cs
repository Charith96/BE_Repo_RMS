using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.business;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;

namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerManager.GetAllCustomersAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomer(string customerId)
        {
            try
            {
                var customer = await _customerManager.GetCustomerByIdAsync(customerId);
                if (customer == null)
                    return NotFound("Customer not found.");

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            try
            {
                var addedCustomer = await _customerManager.AddCustomerAsync(customer);
                return CreatedAtAction(nameof(GetCustomer), new { customerId = addedCustomer.CustomerID }, addedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(string customerId, Customer customer)
        {
            try
            {
                if (customerId != customer.CustomerID)
                    return BadRequest("Customer ID mismatch");

                var updatedCustomer = await _customerManager.UpdateCustomerAsync(customer);
                if (updatedCustomer == null)
                    return NotFound("Customer not found.");

                return Ok(updatedCustomer);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            try
            {
                var result = await _customerManager.DeleteCustomerAsync(customerId);
                if (!result)
                    return NotFound("Customer not found.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
