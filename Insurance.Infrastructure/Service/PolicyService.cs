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
    public class PolicyService : IPolicyService
    {
        ApplicationDbContext db;
        IMapper mapper;
        public PolicyService(ApplicationDbContext db ,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<bool> AddPolicy(PolicyDTO dto)
        {
            var data=mapper.Map<InsurancePolicy>(dto);
            await db.InsurancePolicies.AddAsync(data);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePolicy(int id)
        {
            var data = await db.InsurancePolicies.FindAsync(id);
            data.Status = "InActive";
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<PolicyDTO> GetPolicyByID(int id)
        {
            var data = await db.InsurancePolicies.FindAsync(id);
            return mapper.Map<PolicyDTO>(data);
        }

        public async Task<bool> UpdatePolicy(int id, PolicyDTO dto)
        {
            var data = await db.InsurancePolicies.FindAsync(id);
            mapper.Map(dto, data);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
