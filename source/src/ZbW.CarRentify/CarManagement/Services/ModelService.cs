using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Services
{
    public class ModelService:IModelService
    {
        private readonly ILogger<ModelService> _logger;
        private readonly IModelRepository _modelRepository;

        public ModelService(IModelRepository modelRepository, ILogger<ModelService> logger)
        {
            _logger = logger;
            _modelRepository = modelRepository;
        }
        public List<Model> Get()
        {
            var result = _modelRepository.GetAll();
            return result.ToList();
        }

        public Model Get(Guid id)
        {
            var result = _modelRepository.Get(id);
            return result;
        }

        public void Update(Model model, Guid id)
        {
            if(!id.Equals(model.Id))
                throw new GuidNotEqualException();
            _modelRepository.Update(model);
        }

        public void Delete(Guid id)
        {
           _modelRepository.Delete(new Model(id));
        }

        public void Insert(Model model)
        {
           _modelRepository.Insert(model);
        }
    }
}