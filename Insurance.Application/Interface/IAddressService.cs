using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Application.DTO;

namespace Insurance.Application.Interface
{
    public interface IAddressService
    {
        Task<bool> AddAddress(Customer_addressDTO dto);
        Task<Customer_addressDTO> GetAddressByID(int id);
        Task<bool> DeleteAddress(int id);
        Task<bool> UpdateAddress(int id, Customer_addressDTO dto);
    }
}
