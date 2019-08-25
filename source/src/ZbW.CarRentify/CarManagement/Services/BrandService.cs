using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Services
{
    public class BrandService:IBrandService
    {
        private readonly ILogger<BrandService> _logger;
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository, ILogger<BrandService> logger)
        {
            _logger = logger;
            _brandRepository = brandRepository;
        }
        public List<Brand> Get()
        {
            var result = _brandRepository.GetAll();
            return result.ToList();
        }

        public Brand Get(Guid id)
        {
            var result = _brandRepository.Get(id);
            return result;
        }

        public void Update(Brand brand, Guid id)
        {
            if(!id.Equals(brand.Id))
                throw  new GuidNotEqualException();
            _brandRepository.Update(brand);
        }

        public void Delete(Guid id)
        {
            _brandRepository.Delete(new Brand(id));
        }

        public void Insert(Brand brand)
        {
           _brandRepository.Insert(brand);
        }
    }
}