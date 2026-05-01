using Insurance.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Interface
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerDTO dto);
        Task<CustomerDTO> GetById(int id);
        Task UpdateCustomer(int id,CustomerDTO dto);
        Task DeleteCustomer(int id);
        Task<List<CustomerDTO>> GetAllCustomer();
    }
}
