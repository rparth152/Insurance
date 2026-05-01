using AutoMapper;
using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Insurance.Domain.Model;
using Insurance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        public CustomerService(ApplicationDbContext db, IMapper mapper) {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task AddCustomer(CustomerDTO dto)
        {
            
            var data = mapper.Map<Customer>(dto);
            data.status = "Active"; 
            await db.Customers.AddAsync(data);
            
            await db.SaveChangesAsync();

            var lastrecord = db.Customers.OrderByDescending(x => x.Customer_Id).FirstOrDefault();
            var obj = new Customer_Address
            {
                Customer_Id = lastrecord.Customer_Id,
                status = lastrecord.status

            };
            await db.Customer_Addresses.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var data =await db.Customers.FindAsync(id);
            if (data == null|| data.DeletedAt!=null) {
                throw new Exception("Customer not found Or its deleted already");
            }
            data.status = "InActive";
            var add =await db.Customer_Addresses.Where(x => x.Customer_Id == id).ToListAsync();
            foreach (var addr in add)
            {
                addr.status = "InActive";
            }


            await db.SaveChangesAsync();
        }

        public async Task<CustomerDTO> GetById(int id)
        {
            var data = await db.Customers.FindAsync(id);
            if (data == null || data.DeletedAt != null) { 
            throw new Exception("Customer not found Or its deleted already");
            }
            return mapper.Map<CustomerDTO>(data);

        }
        public async Task<List<CustomerDTO>> GetAllCustomer() {
            
            var data = await db.Customers.Where(x => x.status == "Active").ToListAsync();
            
            return mapper.Map<List<CustomerDTO>>(data);
        }
        public async Task UpdateCustomer(int id, CustomerDTO dto)
        {
            var data=await db.Customers.FindAsync(id);
            if (data == null || data.DeletedAt != null) {
                throw new Exception("Customer not found Or its deleted already");
            }
            var res=mapper.Map(dto, data);
             db.Customers.Update(res);
            await db.SaveChangesAsync();
        }
    }
}
