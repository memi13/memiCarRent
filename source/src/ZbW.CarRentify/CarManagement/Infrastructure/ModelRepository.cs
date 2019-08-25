using System;
using System.Collections.Generic;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.CarManagement.Infrastructure
{
    public class ModelRepository:IModelRepository
    {
        public IEnumerable<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public Model Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Model entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Model entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Model entity)
        {
            throw new NotImplementedException();
        }
    }
}