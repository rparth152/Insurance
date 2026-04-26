using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService service;
        public PolicyController(IPolicyService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> addpolicy(PolicyDTO dto)
        {
            var data = await service.AddPolicy(dto);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Added", data });
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> PolicyGet(int id) { 
            var data = await service.GetPolicyByID(id);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Fetched", data });
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, PolicyDTO dto)
        {
            var data = await service.UpdatePolicy(id, dto);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Updated", data });
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var data = await service.DeletePolicy(id);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Deleted", data });
        }
    }
}
