using conifs.rms.data.entities;
using conifs.rms.dto.Customer;

namespace conifs.rms.business.mappers
{
    public static class CustomerMappers
    {
        public static Customer Map(CustomerDto input)
        {
            if (input == null)
            {
                return null;
            }

            return new Customer
            {
                CustomerID = input.CustomerID,
                FullName = input.FullName,
                Identifier = input.Identifier,
                Address = input.Address,
                Email = input.Email,
                ContactNo = input.ContactNo
            };
        }

        public static CustomerDto Map(Customer input)
        {
            if (input == null)
            {
                return null;
            }

            return new CustomerDto
            {
                CustomerID = input.CustomerID,
                FullName = input.FullName,
                Identifier = input.Identifier,
                Address = input.Address,
                Email = input.Email,
                ContactNo = input.ContactNo
            };
        }
    }
}
