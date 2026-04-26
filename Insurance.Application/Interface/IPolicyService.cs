using Insurance.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Interface
{
    public interface IPolicyService
    {
        Task<bool> AddPolicy(PolicyDTO dto);
        Task<PolicyDTO> GetPolicyByID(int id);
        Task<bool> UpdatePolicy(int id, PolicyDTO dto);
        Task<bool> DeletePolicy(int id);
    }
}
