using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAttributeController : ControllerBase
    {
        private readonly ICustomerAttributeService _service;

        public CustomerAttributeController(ICustomerAttributeService service)
        {
            _service = service;
        }

        //api/CustomerAttribute?name=
        [HttpGet]
        public Task<List<CustomerAttributeModel>> getALl([FromQuery]CustomerSearch customerSearch)
        {
            return _service.GetAll(customerSearch);
        }

        [HttpGet("{id}")]
        public Task<CustomerAttributeModel> getOne(int id)
        {
            return _service.GetOne(id);
        }

        [HttpPost]
        public Task<bool> create([FromBody]CustomerAttributeModel request)
        {
            return _service.Create(request);
        }

        [HttpDelete("{id}")]
        public Task<bool> delete(int id)
        {
            return _service.Delete(id);
        }

        [HttpPut]
        public Task<bool> edit([FromBody]CustomerAttributeModel editCust)
        {
            return _service.Edit(editCust);
        }
    }
}
