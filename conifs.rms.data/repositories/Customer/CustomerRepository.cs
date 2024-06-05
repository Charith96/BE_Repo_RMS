using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.CustomerCode);
            if (existingCustomer == null)
                return null; // Return null if customer not found

            // Update properties of the existing customer
            existingCustomer.CustomerID = customer.CustomerID;
            existingCustomer.FullName = customer.FullName;
            existingCustomer.Identifier = customer.Identifier;
            existingCustomer.Address = customer.Address;
            existingCustomer.Email = customer.Email;
            existingCustomer.ContactNo = customer.ContactNo;

            _context.Customers.Update(existingCustomer);
            await _context.SaveChangesAsync(); // Save changes

            return existingCustomer;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerCode == customerId);
        }

        public async Task<bool> DeleteCustomerAsync(Guid customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
