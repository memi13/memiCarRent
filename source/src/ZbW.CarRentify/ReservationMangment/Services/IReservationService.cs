using System;
using System.Collections.Generic;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Services
{
    public interface IReservationService
    {
        List<Reservation> Get();

        Reservation Get(Guid id);


        void Update(Reservation car, Guid id);


        void Delete(Guid car);
        void Insert(Reservation car);
    }
}