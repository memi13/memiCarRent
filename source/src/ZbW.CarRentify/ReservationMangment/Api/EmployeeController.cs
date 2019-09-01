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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmploeeyService _emploeeyService;

        public EmployeeController(IEmploeeyService emploeeyService)
        {
            _emploeeyService = emploeeyService;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            var result = _emploeeyService.Get().Select(x => x.ToDto());
            return result.ToList();
        }

        [HttpGet("{id}", Name = "GetEmploee")]
        public EmployeeDto Get(Guid id)
        {
            var result = _emploeeyService.Get(id).ToDto();
            return result;
        }

        [HttpPost]
        public void Post([FromBody] EmployeeDto car)
        {
            _emploeeyService.Insert(car.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] EmployeeDto emploee)
        {
            _emploeeyService.Update(emploee.ToObject(), id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _emploeeyService.Delete(id);
        }
    }
}