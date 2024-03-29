﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Infastructure
{
    public class CustomerRepository:ICustomerRepository
    {
        private string paths;
        private string header;

        public CustomerRepository()
        {
            paths = @"C:\temp\CarRent\Customer\";
            header = "Id;PublicId;Name;FirstName;Birthday;Status;Sex;EditFrom;Edit;CreateFrom;Create";
        }
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> carrClasses = new List<Customer>();
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                carrClasses.Add(DataTableToCarClass(FileSystem.LoadeFile(path)));
            }
            return carrClasses;
        }

        public Customer Get(Guid id)
        {
            string[] filePaths = Directory.GetFiles(paths, $"Customer_{id.ToString()}_.csv");
            if (filePaths.Length > 1)
                throw new ArgumentException("Fehler im File System");
            if (filePaths.Length.Equals(0))
            {
                throw new EntityNotFoundException();
            }
            var contract = DataTableToCarClass(FileSystem.LoadeFile(filePaths[0]));
            return contract;
        }

        public void Insert(Customer entity)
        {
            entity.Create = DateTime.UtcNow;
            entity.Edit = DateTime.UtcNow;
            entity.CreateFrom = "USER";
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Customer");
        }

        public void Update(Customer entity)
        {
            var oldContract = Get(entity.Id);
            entity.CreateFrom = oldContract.CreateFrom;
            entity.Create = oldContract.Create;
            entity.Edit = DateTime.UtcNow;
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Customer");
        }

        public void Delete(Customer entity)
        {
            File.Delete(paths + $"Customer_{ entity.Id.ToString()}_.csv");
        }
        private Customer DataTableToCarClass(DataTable dt)
        {
            var row1 = dt.Rows[0];
            var id = row1.ItemArray[0].ToString();
            var contract = new Customer(Guid.Parse(id));
            contract.PublicId = int.Parse(row1.ItemArray[1].ToString());

            contract.Name = row1.ItemArray[2].ToString();
            contract.FirstName = row1.ItemArray[3].ToString();

            contract.Birthday = DateTime.Parse(row1.ItemArray[4].ToString());
            contract.Status = row1.ItemArray[5].ToString();
            contract.Sex = row1.ItemArray[6].ToString();


            contract.EditFrom = row1.ItemArray[7].ToString();
            contract.CreateFrom = row1.ItemArray[9].ToString();
            contract.Edit = DateTime.Parse(row1.ItemArray[8].ToString());
            contract.Create = DateTime.Parse(row1.ItemArray[10].ToString());
            return contract;
        }

    }
}