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
        public IEnumerable<BrandDto> Get()
        {
            var result = _brandService.Get().Select(x=>x.ToDto());
            return result;
        }

        [HttpGet("{id}", Name = "GetBrand")]
        public BrandDto Get(Guid id)
        {
            var result = _brandService.Get(id);
            return result.ToDto();
        }

        [HttpPost]
        public void Post([FromBody] BrandDto brand)
        {
            _brandService.Insert(brand.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] BrandDto brand)
        {
           _brandService.Update(brand.ToObject(),id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _brandService.Delete(id);
        }
    }
}