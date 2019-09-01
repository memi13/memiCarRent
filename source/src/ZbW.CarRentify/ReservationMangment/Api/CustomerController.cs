using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZbW.CarRentify.ReservationMangment.Services;

namespace ZbW.CarRentify.ReservationMangment.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            var result = _customerService.Get().Select(x => x.ToDto());
            return result.ToList();
        }

        [HttpGet("{id}", Name = "GetEmploee")]
        public CustomerDto Get(Guid id)
        {
            var result = _customerService.Get(id).ToDto();
            return result;
        }

        [HttpPost]
        public void Post([FromBody] CustomerDto car)
        {
            _customerService.Insert(car.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CustomerDto emploee)
        {
            _customerService.Update(emploee.ToObject(), id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _customerService.Delete(id);
        }
    }
}