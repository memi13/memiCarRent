using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Infrastructure
{
    public class CarClassRepository:ICarClassRepository
    {
        private string paths;
        private string header;

        public CarClassRepository()
        {
            paths = @"C:\temp\CarRent\CarClass\";
            header = "Id;PublicId;Name;Price;EditFrom;Edit;CreateFrom;Create";
        }
        public IEnumerable<CarClass> GetAll()
        {
            List<CarClass> carrClasses = new List<CarClass>();
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                carrClasses.Add(DataTableToCarClass(FileSystem.LoadeFile(path)));
            }

            return carrClasses;
        }

        public CarClass Get(Guid id)
        {
            string[] filePaths = Directory.GetFiles(paths, $"CarClass_{id.ToString()}_.csv");
            if (filePaths.Length > 1)
                throw new ArgumentException("Fehler im File System");
            if (filePaths.Length.Equals(0))
            {
                throw new EntityNotFoundException();
            }
            var carrClass = DataTableToCarClass(FileSystem.LoadeFile(filePaths[0]));
            return carrClass;
        }

        public void Insert(CarClass entity)
        {
            entity.Create = DateTime.UtcNow;
            entity.Edit = DateTime.UtcNow;
            entity.CreateFrom = "USER";
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "CarClass");
        }

        public void Update(CarClass entity)
        {
            var oldCarrClass = Get(entity.Id);
            entity.CreateFrom = oldCarrClass.CreateFrom;
            entity.Create = oldCarrClass.Create;
            entity.Edit = DateTime.UtcNow;
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "CarClass");
        }

        public void Delete(CarClass entity)
        {
            File.Delete(paths + $"CarClass_{ entity.Id.ToString()}_.csv");
        }
        private CarClass DataTableToCarClass(DataTable dt)
        {
            var row1 = dt.Rows[0];
            var id = row1.ItemArray[0].ToString();
            var carClass = new CarClass(Guid.Parse(id), row1.ItemArray[2].ToString(),Decimal.Parse(row1.ItemArray[3].ToString()));
            carClass.PublicId = int.Parse(row1.ItemArray[1].ToString());
            carClass.EditFrom = row1.ItemArray[4].ToString();
            carClass.CreateFrom = row1.ItemArray[6].ToString();
            carClass.Edit = DateTime.Parse(row1.ItemArray[5].ToString());
            carClass.Create = DateTime.Parse(row1.ItemArray[7].ToString());
            return carClass;
        }
    }
}