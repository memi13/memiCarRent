using System;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Api
{
    public class ReservationDto
    {
        public Guid id { get; set; }
        public int PublicId { get; set; }
        public DateTime From { get; set; }
        public DateTime UnTil { get; set; }
        public string Description { get; set; }
        public Reservation ToObject()
        {
            var reservation = new Reservation(id);
            reservation.PublicId = PublicId;
            reservation.From = From;
            reservation.UnTil = UnTil;
            reservation.Description = Description;
            return reservation;
        }
    }
}