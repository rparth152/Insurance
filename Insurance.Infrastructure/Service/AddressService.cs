using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Insurance.Domain.Model;
using Insurance.Infrastructure.Data;

namespace Insurance.Infrastructure.Service
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        public AddressService(ApplicationDbContext db , IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<bool> AddAddress(Customer_addressDTO dto)
        {
            var data=mapper.Map<Customer_Address>(dto);
            await db.Customer_Addresses.AddAsync(data);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAddress(int id)
        {
            var data=await db.Customer_Addresses.FindAsync(id);
            data.status = "InActive";
            db.SaveChangesAsync();
            return true;
        }

        public async Task<Customer_addressDTO> GetAddressByID(int id)
        {
            var data =await db.Customer_Addresses.FindAsync(id);
            return mapper.Map<Customer_addressDTO>(data) ;
        }

        public async Task<bool> UpdateAddress(int id, Customer_addressDTO dto)
        {
            var data=await db.Customer_Addresses.FindAsync(id);
            var res = mapper.Map(dto, data);
            db.Customer_Addresses.Update(res);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
