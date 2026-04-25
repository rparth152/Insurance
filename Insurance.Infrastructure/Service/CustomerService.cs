using AutoMapper;
using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Insurance.Domain.Model;
using Insurance.Infrastructure.Data;
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
            await db.Customers.AddAsync(data);
            //var add = new Customer_Address
            //{
            //    Customer_Id=dto.Customer_Id,
            //    status=dto.status

            //};
            //await db.Customer_Addresses.AddAsync(add);
            await db.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id)
        {
            var data =await db.Customers.FindAsync(id);
            if (data == null|| data.DeletedAt!=null) {
                throw new Exception("Customer not found Or its deleted already");
            }
            data.status = "InActive";
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
