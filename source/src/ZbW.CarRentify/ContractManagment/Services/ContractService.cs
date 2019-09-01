using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ContractManagment.Domain;

namespace ZbW.CarRentify.ContractManagment.Services
{
    public class ContractService :IContractService
    {
        private readonly ILogger<ContractService> _logger;
        private readonly IContractRepository _contractRepository;

        public ContractService(IContractRepository contractReposetory, ILogger<ContractService> logger)
        {
            _logger = logger;
            _contractRepository = contractReposetory;
        }

        public List<Contract> Get()
        {
            var result = _contractRepository.GetAll();
            return result.ToList();

        }

        public Contract Get(Guid id)
        {
            var result = _contractRepository.Get(id);
            return result;
        }

        public void Update(Contract contract, Guid id)
        {
            if(!contract.Id.Equals(id))
                throw new GuidNotEqualException();
            _contractRepository.Update(contract);
        }

        public void Delete(Guid id)
        {
            _contractRepository.Delete(new Contract(id));
        }

        public void Insert(Contract contract)
        {
            _contractRepository.Insert(contract);
        }
    }
}