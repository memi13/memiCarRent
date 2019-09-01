using System;
using System.Collections.Generic;
using ZbW.CarRentify.ContractManagment.Domain;

namespace ZbW.CarRentify.ContractManagment.Services
{
    public interface IContractService
    {
        List<Contract> Get();

        Contract Get(Guid id);


        void Update(Contract car, Guid id);


        void Delete(Guid car);
        void Insert(Contract car);
    }
}