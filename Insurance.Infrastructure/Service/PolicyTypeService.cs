using AutoMapper;
using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Insurance.Domain.Model;
using Insurance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Service
{
    public class PolicyTypeService : IPolicyTypeService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public PolicyTypeService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<bool> AddTypePolicy(PolicyTypeDTO dto)
        {
            var data = mapper.Map<TypeOfPolicy>(dto);
            await db.TypeOfPolicies.AddAsync(data);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteType(int id)
        {
            var data= await db.TypeOfPolicies.FindAsync(id);
            data.Status= "InActive";
            await db.SaveChangesAsync();
            return true;


        }

        public async Task<PolicyTypeDTO> GetTypeById(int id)
        {

            var data =await db.TypeOfPolicies.FindAsync(id);
            return mapper.Map<PolicyTypeDTO>(data);
        }

        public async Task<bool> UpdateType(int id, PolicyTypeDTO dto)
        {
            var data = await db.TypeOfPolicies.FindAsync(id);
            mapper.Map(dto, data);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
