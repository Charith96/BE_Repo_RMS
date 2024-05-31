using AutoMapper;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.dto.Customer;
using FluentValidation;

namespace conifs.rms.business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<Customer> _customerValidator;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerRepository customerRepository, IValidator<Customer> customerValidator, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _customerValidator = customerValidator;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllCustomersAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var validationResult = await _customerValidator.ValidateAsync(customer);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var addedCustomer = await _customerRepository.AddCustomerAsync(customer);
            return _mapper.Map<CustomerDto>(addedCustomer);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var validationResult = await _customerValidator.ValidateAsync(customer);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.CustomerCode);
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

            return _mapper.Map<CustomerDto>(existingCustomer);
        }

        public async Task<bool> DeleteCustomerAsync(Guid customerId)
        {
            return await _customerRepository.DeleteCustomerAsync(customerId);
        }
    }
}
