using Insurance.Application.DTO;
using Insurance.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressService service;
        public AddressController(IAddressService service) 
        {
            this.service= service;
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(Customer_addressDTO dto) 
        {
            await service.AddAddress(dto);
            return Ok("Added Brother");
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAddressByID(int id)
        {
            var result = await service.GetAddressByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, Customer_addressDTO dto) {

            var data=await service.UpdateAddress(id, dto);
            if (data == null) { 
                return NotFound();
            }
            return Ok("Updated");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAddress(int id) { 
            await service.DeleteAddress(id);
            return Ok("Deleted");
        }
    }
}
