using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;

namespace conifs.rms.business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(string customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.CustomerID);
            if (existingCustomer == null)
                return null; // Return null if customer not found

            // Update properties of the existing customer
            existingCustomer.CustomerID = customer.CustomerID;
            existingCustomer.FullName = customer.FullName;
            existingCustomer.Identifier = customer.Identifier;
            existingCustomer.Address = customer.Address;
            existingCustomer.Email = customer.Email;
            existingCustomer.ContactNo = customer.ContactNo;



            await _customerRepository.UpdateCustomerAsync(existingCustomer); // Save changes

            return existingCustomer;
        }



        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            return await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}
