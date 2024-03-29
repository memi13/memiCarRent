﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZbW.CarRentify.ContractManagment.Services;

namespace ZbW.CarRentify.ContractManagment.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public IEnumerable<ContractDto> Get()
        {
            var result = _contractService.Get().Select(x => x.ToDto());
            return result.ToList();
        }

        [HttpGet("{id}", Name = "GetContract")]
        public ContractDto Get(Guid id)
        {
            var result = _contractService.Get(id);
            return result.ToDto();
        }

        [HttpPost]
        public void Post([FromBody] ContractDto car)
        {
            _contractService.Insert(car.ToObject());
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ContractDto carClass)
        {
            _contractService.Update(carClass.ToObject(), id);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _contractService.Delete(id);
        }
    }
}