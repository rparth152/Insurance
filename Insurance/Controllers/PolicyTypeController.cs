using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyTypeController : ControllerBase
    {
        private readonly IPolicyTypeService service;
        public PolicyTypeController(IPolicyTypeService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> addtypepolicy(PolicyTypeDTO dto)
        {

            var data = await service.AddTypePolicy(dto);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Added", data });
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Getbyid(int id)
        {
            var data = await service.GetTypeById(id);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Fetched", data });
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateType(int id, PolicyTypeDTO dto)
        {
            var data = await service.UpdateType(id, dto);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Updated", data });
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var data = await service.DeleteType(id);
            if (data == null) { return NotFound(); }
            return Ok(new { message = "Data Deleted", data });
        }
    }
}
