using Microsoft.Extensions.Logging;
using ZbW.CarRentify.ContractManagment.Domain;

namespace ZbW.CarRentify.ContractManagment.Services
{
    public class ContractService :IContractService
    {
        private readonly ILogger<ContractService> _logger;

        public ContractService(IContractReposetory ContractReposetory, ILogger<ContractService> logger)
        {
            _logger = logger;
        }

    }
}