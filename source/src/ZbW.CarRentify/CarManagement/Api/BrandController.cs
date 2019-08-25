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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IEnumerable<CarDto> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name = "GetBrand")]
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