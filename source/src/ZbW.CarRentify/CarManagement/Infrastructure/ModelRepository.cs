using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Infrastructure
{
    public class ModelRepository:IModelRepository
    {
        private string paths;
        private string header;

        public ModelRepository()
        {
            paths = @"C:\temp\CarRent\Model\";
            header = "Id;PublicId;Name;Version;EditFrom;Edit;CreateFrom;Create;CarClass;Brand";
        }
        public IEnumerable<Model> GetAll()
        {
            List<Model> models = new List<Model>();
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                models.Add(DataTableToModel(FileSystem.LoadeFile(path)));
            }

            return models;
        }

        public Model Get(Guid id)
        {
            string[] filePaths = Directory.GetFiles(paths, $"Model_{id.ToString()}_.csv");
            if (filePaths.Length > 1)
                throw new ArgumentException("Fehler im File System");
            if (filePaths.Length.Equals(0))
            {
                throw new EntityNotFoundException();
            }
            var model = DataTableToModel(FileSystem.LoadeFile(filePaths[0]));
            return model;
        }

        public void Insert(Model entity)
        {
            entity.Create = DateTime.UtcNow;
            entity.Edit = DateTime.UtcNow;
            entity.CreateFrom = "USER";
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Model");
        }

        public void Update(Model entity)
        {
            var oldModel = Get(entity.Id);
            entity.CreateFrom = oldModel.CreateFrom;
            entity.Create = oldModel.Create;
            entity.Edit = DateTime.UtcNow;
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Model");
        }

        public void Delete(Model entity)
        {
            File.Delete(paths + $"Brand_{entity.Id.ToString()}_.csv");
        }
        private Model DataTableToModel(DataTable dt)
        {
            var row1 = dt.Rows[0];
            var id = row1.ItemArray[0].ToString();
            var newBrand = new Model(Guid.Parse(id), new CarClass(Guid.Parse(row1.ItemArray[8].ToString())), new Brand(Guid.Parse(row1.ItemArray[9].ToString())));
            newBrand.PublicId = int.Parse(row1.ItemArray[1].ToString());
            newBrand.Name = row1.ItemArray[2].ToString();
            newBrand.Version = Int32.Parse( row1.ItemArray[3].ToString());
            newBrand.EditFrom = row1.ItemArray[4].ToString();
            newBrand.CreateFrom = row1.ItemArray[6].ToString();
            newBrand.Edit = DateTime.Parse(row1.ItemArray[5].ToString());
            newBrand.Create = DateTime.Parse(row1.ItemArray[7].ToString());
            return newBrand;
        }
    }
}