using conifs.rms.business;
using conifs.rms.dto.Customer;
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
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerManager.GetAllCustomersAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(Guid customerId)
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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> AddCustomer(CustomerDto customerDto)
        {
            try
            {
                var addedCustomer = await _customerManager.AddCustomerAsync(customerDto);
                return CreatedAtAction(nameof(GetCustomer), new { customerId = addedCustomer.CustomerID }, addedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult<CustomerDto>> UpdateCustomer(Guid customerId, CustomerDto customerDto)
        {
            try
            {
                var updatedCustomer = await _customerManager.UpdateCustomerAsync(customerId, customerDto);
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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}