using conifs.rms.dto.Customer;

namespace conifs.rms.business
{
    public interface ICustomerManager
    {
        Task<List<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(Guid customerId);
        Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateCustomerAsync(Guid customerId, CustomerDto customerDto);
        Task<bool> DeleteCustomerAsync(Guid customerId);
    }
}