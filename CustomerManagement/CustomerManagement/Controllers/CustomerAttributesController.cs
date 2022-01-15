

using CustomerManagement.Models;
using CustomerManagement.Repositories;
using CustomerManagementModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAttributesController : ControllerBase
    {
        
        private readonly ICustomerAttribute _customerAttribute;

        public CustomerAttributesController(ICustomerAttribute customerAttribute)
        {
            _customerAttribute = customerAttribute;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SearchAttributes searchAttributes)
        {
            var result = await _customerAttribute.GetAttributeList(searchAttributes);
            var data = result.Select(x => new AttributeDTO()
            {
                AttriId = x.AttriId,
                AttributeMaster = x.AttributeMaster,
                Code = x.Code,
                Description = x.Description,
                ShortName = x.ShortName,
                Parent = x.Parent,
                EffectiveDate = x.EffectiveDate,
                ValidUntil = x.ValidUntil
            }
            );
            return Ok(data);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOneAttribute([FromRoute]Guid id)
        {
            var result = _customerAttribute.GetById(id);
            if (result == null) return NotFound($"{id} is not found");
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AttributeCreateRequest request)
        {

            var newCustomer = await _customerAttribute.Create(new CustomerAttribute()
            {
                AttriId = Guid.NewGuid(),
                AttributeMaster = request.AttributeMaster,
                Code    =   request.Code,
                Description = request.Description,
                ShortName = request.ShortName,
                Parent = request.Parent
            });
            return CreatedAtAction(nameof(GetOneAttribute), new { id = newCustomer.AttriId },newCustomer);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AttributeUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dataFromDB = await _customerAttribute.GetById(id);
            if (dataFromDB == null)
            {
                return NotFound($"{id} is not found");
            }
            dataFromDB.AttributeMaster = request.AttributeMaster;
            await _customerAttribute.Update(dataFromDB);
            return Ok(new AttributeDTO()
            {
                AttributeMaster = request.AttributeMaster,
                Code = request.Code,
                Description = request.Description,
                ShortName = request.ShortName,
                Parent = request.Parent
            });

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAttribute([FromRoute] Guid id)
        {
            var customertoDelete = await _customerAttribute.GetById(id);
            if (customertoDelete == null) { return NotFound(); }
            await _customerAttribute.Delete(customertoDelete);
            return Ok(new AttributeDTO()
            {
                AttributeMaster = customertoDelete.AttributeMaster,
                Code = customertoDelete.Code,
                Description = customertoDelete.Description,
                ShortName = customertoDelete.ShortName,
                Parent =customertoDelete.Parent
            });
        }
    }
}
