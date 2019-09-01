using System;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ReservationMangment.Api;

namespace ZbW.CarRentify.ReservationMangment.Domain
{
    public class Reservation:EntityBase
    {
        private Car _car;
        private Employee _employee;
        private Customer _customer;
        public Car Car => _car;
        public DateTime From { get; set; }
        public  DateTime OnTil { get; set; }
        public string Description { get; set; }

        public Employee Employee => _employee;
        public Customer Customer => _customer;
        public Reservation() : base(new Guid())
        {

        }

        public Reservation(Guid id) : base(id)
        {

        }
        public Reservation(Guid id,Car car,Customer customer,Employee employee) : base(id)
        {
            _car = car;
            _employee = employee;
            _customer = customer;
        }

        public ReservationDto ToDto()
        {
            var reservation = new ReservationDto();
            reservation.id = Id;
            reservation.PublicId = PublicId;
            reservation.From = From;
            reservation.UnTil = OnTil;
            reservation.Description = Description;
            return reservation;
        }
        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{Description};{From};{OnTil};{EditFrom};{Edit};{CreateFrom};{Create};{Car.Id.ToString()};{Employee.Id.ToString()};{Customer.Id.ToString()}";
        }
    }
}