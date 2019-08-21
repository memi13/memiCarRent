using System;
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
        private readonly IContractService _contreService;

        public ContractController(IContractService contractService)
        {
            _contreService = contractService;
        }
        [HttpGet]
        public IEnumerable<ContractDTO> Get()
        {
            return new[] {
                new ContractDTO {  From = DateTime.Now},
                new ContractDTO {  From = DateTime.Now }
            };
        }

        [HttpGet("{id}", Name = "GetContract")]
        public ContractDTO Get(Guid id)
        {
            return new ContractDTO { From = DateTime.Now };
        }

        [HttpPost]
        public void Post([FromBody] ContractDTO car)
        {
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ContractDTO car)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}