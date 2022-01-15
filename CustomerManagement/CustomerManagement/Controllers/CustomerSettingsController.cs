using CustomerManagement.Models;
using CustomerManagement.Repositories;
using CustomerManagementModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSettingsController : ControllerBase
    {
        private readonly ICustomerSetting<CustomerSetting> _customerSetting;

        public CustomerSettingsController(ICustomerSetting<CustomerSetting> customerSetting)
        {
            _customerSetting = customerSetting;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerSetting.GetList();
            var data =  result.Select(x=>new SettingDTO()
            {
                AttributeId = x.AttributeId,
                AttributeName = x.AttributeName,
                Description = x.Description,
                IsCustomerAttribute = x.IsCustomerAttribute,
                IsDistributorAttribute = x.IsDistributorAttribute,
                Used = x.Used,
            });
            return Ok(data);
        }
        [HttpGet]
        [Route("{id}")]
        
        public async Task<IActionResult> GetCustomers([FromRoute]Guid id)
        {
            var result = await _customerSetting.GetById(id);
            if (result == null) return NotFound($"{id} is not found ");
            return Ok(new SettingDTO()
            {
                AttributeId=result.AttributeId,
                AttributeName = result.AttributeName,
                Description=result.Description,
                IsCustomerAttribute=result.IsCustomerAttribute,
                IsDistributorAttribute=result.IsDistributorAttribute,
                Used=result.Used
            }
            );
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(SettingCreateRequest request)
        {

            var newCustomer = await _customerSetting.Create(new CustomerSetting()
            {
                AttributeName = request.AttributeName,
                Description = request.Description,
                IsCustomerAttribute = request.IsCustomerAttribute,
                IsDistributorAttribute = request.IsDistributorAttribute,
                Used = request.Used,
                AttributeId = request.AttributeId
            });
            return CreatedAtAction(nameof(GetCustomers), new { id = Guid.NewGuid() });
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] SettingUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dataFromDB = await _customerSetting.GetById(id);
            if(dataFromDB == null)
            {
                return NotFound($"{id} is not found");
            }
            dataFromDB.AttributeName = request.AttributeName;
            await _customerSetting.Update(dataFromDB);
            return Ok(new SettingDTO()
            {
                AttributeName = request.AttributeName,
                Description = request.Description,
                IsCustomerAttribute = request.IsCustomerAttribute,
                IsDistributorAttribute = request.IsDistributorAttribute,
                Used = request.Used,
                AttributeId = request.AttributeId
            });

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var customertoDelete = await _customerSetting.GetById(id);
            if (customertoDelete == null) { return NotFound(); }
            await _customerSetting.Delete(customertoDelete);
            return Ok(new SettingDTO()
            {
                AttributeId=customertoDelete.AttributeId,
                AttributeName = customertoDelete.AttributeName,
                IsCustomerAttribute= customertoDelete.IsCustomerAttribute,
                IsDistributorAttribute=customertoDelete.IsDistributorAttribute,
                Description = customertoDelete.Description,
                Used = customertoDelete.Used
            });
        }
    }
}
