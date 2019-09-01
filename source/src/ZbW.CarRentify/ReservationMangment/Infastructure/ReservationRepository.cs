using System;
using System.Collections.Generic;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Infastructure
{
    public class ReservationRepository:IReservationRepository
    {
        public IEnumerable<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Reservation Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}