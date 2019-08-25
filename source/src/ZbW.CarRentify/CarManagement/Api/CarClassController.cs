using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZbW.CarRentify.CarManagement.Services;

namespace ZbW.CarRentify.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassService _carClassService;

        public CarClassController(ICarClassService carClassService)
        {
            _carClassService = carClassService;
        }

        [HttpGet]
        public IEnumerable<CarDto> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name = "GetCarClass")]
        public CarDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] CarDto car)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarDto car)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}