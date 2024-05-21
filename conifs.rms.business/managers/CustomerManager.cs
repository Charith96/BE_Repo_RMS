using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;
using FluentValidation;

namespace conifs.rms.business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<Customer> _customerValidator;

        public CustomerManager(ICustomerRepository customerRepository, IValidator<Customer> customerValidator)
        {
            _customerRepository = customerRepository;
            _customerValidator = customerValidator;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await _customerRepository.GetCustomerByIdAsync(customerId);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var validationResult = await _customerValidator.ValidateAsync(customer);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var validationResult = await _customerValidator.ValidateAsync(customer);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.CustomerCode);
            if (existingCustomer == null)
                return null; // Return null if customer not found

            // Update properties of the existing customer
            existingCustomer.CustomerCode = customer.CustomerCode;
            existingCustomer.CustomerID = customer.CustomerID;
            existingCustomer.FullName = customer.FullName;
            existingCustomer.Identifier = customer.Identifier;
            existingCustomer.Address = customer.Address;
            existingCustomer.Email = customer.Email;
            existingCustomer.ContactNo = customer.ContactNo;

            await _customerRepository.UpdateCustomerAsync(existingCustomer); // Save changes

            return existingCustomer;
        }

        public async Task<bool> DeleteCustomerAsync(Guid customerId)
        {
            return await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}
