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
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public IEnumerable<ModelDto> Get()
        {
            var result = _modelService.Get().Select(x => x.ToDto());
            return result.ToList();
        }

        [HttpGet("{id}", Name = "GetModel")]
        public ModelDto Get(Guid id)
        {
            var result = _modelService.Get(id);
            return result.ToDto();
        }

        [HttpPost]
        public void Post([FromBody] ModelDto model)
        {
            _modelService.Insert(model.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ModelDto model)
        {
            _modelService.Update(model.ToObject(),id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
           _modelService.Delete(id);
        }
    }
}