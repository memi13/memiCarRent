using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Infrastructure
{
    public class BrandRepository:IBrandRepository
    {
        private string paths;
        private string header;

        public BrandRepository()
        {
            paths = @"C:\temp\CarRent\Brand\";
            header = "Id;PublicId;Name;Country;EditFrom;Edit;CreateFrom;Create";
        }
        public IEnumerable<Brand> GetAll()
        {
            List<Brand> brands = new List<Brand>();
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                brands.Add(DataTableToBrand(FileSystem.LoadeFile(path)));
            }

            return brands;
        }

        public Brand Get(Guid id)
        {
            string[] filePaths = Directory.GetFiles(paths, $"Brand_{id.ToString()}_.csv");
            if (filePaths.Length > 1)
                throw new ArgumentException("Fehler im File System");
            if (filePaths.Length.Equals(0))
            {
                throw new EntityNotFoundException();
            }
            var brand = DataTableToBrand(FileSystem.LoadeFile(filePaths[0]));
            return brand;
        }
    

        public void Insert(Brand entity)
        {
            entity.Create = DateTime.UtcNow;
            entity.Edit = DateTime.UtcNow;
            entity.CreateFrom = "USER";
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Brand");
        }

        public void Update(Brand entity)
        {
            var oldbrand = Get(entity.Id);
            entity.CreateFrom = oldbrand.CreateFrom;
            entity.Create = oldbrand.Create;
            entity.Edit = DateTime.UtcNow;
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Brand");
        }

        public void Delete(Brand entity)
        {
            File.Delete(paths + $"Brand_{entity.Id.ToString()}_.csv");
        }
        private Brand DataTableToBrand(DataTable dt)
        {
            var row1 = dt.Rows[0];
            var id = row1.ItemArray[0].ToString();
            var newBrand = new Brand(Guid.Parse(id));
            newBrand.PublicId = int.Parse(row1.ItemArray[1].ToString());
            newBrand.Name = row1.ItemArray[2].ToString();
            newBrand.Country= row1.ItemArray[3].ToString();
            newBrand.EditFrom = row1.ItemArray[4].ToString();
            newBrand.CreateFrom = row1.ItemArray[6].ToString();
            newBrand.Edit = DateTime.Parse(row1.ItemArray[5].ToString());
            newBrand.Create = DateTime.Parse(row1.ItemArray[7].ToString());
            return newBrand;
        }
    }
}