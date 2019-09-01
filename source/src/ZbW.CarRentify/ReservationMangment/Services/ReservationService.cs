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
    public class ReservationService:IReservationService
    {
        private readonly ILogger<ReservationService> _logger;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository, ILogger<ReservationService> logger)
        {
            _logger = logger;
            _reservationRepository = reservationRepository;
        }
        public List<Reservation> Get()
        {
            var result = _reservationRepository.GetAll();
            return result.ToList();
        }

        public Reservation Get(Guid id)
        {
            var result = _reservationRepository.Get(id);
            return result;
        }

        public void Update(Reservation reservation, Guid id)
        {
           if(!id.Equals(reservation.Id))
                throw  new GuidNotEqualException();
           _reservationRepository.Update(reservation);
        }

        public void Delete(Guid reservation)
        {
          _reservationRepository.Delete(new Reservation(reservation));
        }

        public void Insert(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }
    }
}