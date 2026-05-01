using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerDTO dto) { 
            await service.AddCustomer(dto);
            return Ok("Added Brother");
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id) { 
            var data =await service.GetById(id);
            return Ok(new { Message = "data fetched", data });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() { 
            var data = await service.GetAllCustomer();
            return Ok(new { Message = "data fetched", data });
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO dto) { 
            await service.UpdateCustomer(id, dto);
            return Ok("Updated");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id) {
            await service.DeleteCustomer(id);
            return Ok("Deleted");
        }
    }
}
