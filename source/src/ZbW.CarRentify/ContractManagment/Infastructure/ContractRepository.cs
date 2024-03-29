﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ContractManagment.Domain;

namespace ZbW.CarRentify.ContractManagment.Infastructure
{
    public class ContractRepository:IContractRepository
    {
        private string paths;
        private string header;

        public ContractRepository()
        {
            paths = @"C:\temp\CarRent\Contract\";
            header = "Id;PublicId;Description;From;OnTil;EditFrom;Edit;CreateFrom;Create;CarId;ReservationId";
        }
        public IEnumerable<Contract> GetAll()
        {
            List<Contract> carrClasses = new List<Contract>();
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                carrClasses.Add(DataTableToCarClass(FileSystem.LoadeFile(path)));
            }
            return carrClasses;
        }

        public Contract Get(Guid id)
        {
            string[] filePaths = Directory.GetFiles(paths, $"Contract_{id.ToString()}_.csv");
            if (filePaths.Length > 1)
                throw new ArgumentException("Fehler im File System");
            if (filePaths.Length.Equals(0))
            {
                throw new EntityNotFoundException();
            }
            var contract = DataTableToCarClass(FileSystem.LoadeFile(filePaths[0]));
            return contract;
        }

        public void Insert(Contract entity)
        {
            entity.Create = DateTime.UtcNow;
            entity.Edit = DateTime.UtcNow;
            entity.CreateFrom = "USER";
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Contract");
        }

        public void Update(Contract entity)
        {
            var oldContract = Get(entity.Id);
            entity.CreateFrom = oldContract.CreateFrom;
            entity.Create = oldContract.Create;
            entity.Edit = DateTime.UtcNow;
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Contract");
        }

        public void Delete(Contract entity)
        {
            File.Delete(paths + $"Contract_{ entity.Id.ToString()}_.csv");
        }
        private Contract DataTableToCarClass(DataTable dt)
        {
            var row1 = dt.Rows[0];
            var id = row1.ItemArray[0].ToString();
            var contract = new Contract(Guid.Parse(id),new Car(  Guid.Parse(row1.ItemArray[9].ToString())) , new Reservation( Guid.Parse(row1.ItemArray[10].ToString())));
            contract.PublicId = int.Parse(row1.ItemArray[1].ToString());
            contract.Description = row1.ItemArray[2].ToString();
            contract.From = DateTime.Parse(row1.ItemArray[3].ToString());
            contract.OnTill = DateTime.Parse(row1.ItemArray[4].ToString());
            contract.EditFrom = row1.ItemArray[5].ToString();
            contract.CreateFrom = row1.ItemArray[7].ToString();
            contract.Edit = DateTime.Parse(row1.ItemArray[6].ToString());
            contract.Create = DateTime.Parse(row1.ItemArray[8].ToString());
            return contract;
        }
    }
}