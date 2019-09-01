using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ContractManagment.Domain;
using ZbW.CarRentify.ContractManagment.Services;
using ZbW.CarRentify.ReservationMangment.Domain;
using Reservation = ZbW.CarRentify.ReservationMangment.Domain.Reservation;

namespace ZbW.CarRentify.ReservationMangment.Services
{
    public class EmploeeyService : IEmploeeyService
    {
        private readonly ILogger<EmploeeyService> _logger;
        private readonly IEmpleeyRepository _empleeyRepository;

        public EmploeeyService(IEmpleeyRepository empleeyRepository, ILogger<EmploeeyService> logger)
        {
            _logger = logger;
            _empleeyRepository = empleeyRepository;
        }
        public void Delete(Guid id)
        {
            _empleeyRepository.Delete(new Employee(id));
        }

        public List<Employee> Get()
        {
            var result = _empleeyRepository.GetAll();
            return result.ToList();
        }

        public Employee Get(Guid id)
        {
            var result = _empleeyRepository.Get(id);
            return result;
        }

       


        public void Insert(Employee reservation)
        {
            _empleeyRepository.Insert(reservation);
        }

        public void Update(Employee employee, Guid id)
        {
            if(!id.Equals(employee.Id))
                throw new GuidNotEqualException();
           _empleeyRepository.Update(employee);
        }
    }
}