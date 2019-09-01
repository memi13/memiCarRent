using System;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ContractManagment.Api;

namespace ZbW.CarRentify.ContractManagment.Domain
{
    public class Contract :EntityBase
    {
        private readonly Car _car;
        private readonly Reservation _reservation;
        public DateTime From { get; set; }
        public DateTime OnTill { get; set; }
        public  string Description { get; set; }
        public Car Car => _car;
        public Reservation Reservation => _reservation;
        public Contract(Guid id,Car car,Reservation reservation):base(id)
        {
            _car = car;
            _reservation = reservation;
        }
        public Contract(Guid id) : base(id) { }
        internal ContractDto ToDto()
        {
            var contractDto=new ContractDto();
            contractDto.id = Id;
            contractDto.PublicId = PublicId;
            contractDto.Description = Description;
            contractDto.From = From;
            contractDto.OnTil = OnTill;
            contractDto.ReservationId = Reservation.Id;
            contractDto.CarId = Car.Id;
            return contractDto;
        }
        public override string ToString()
        {
            return $"{Id.ToString()};{PublicId.ToString()};{Description};{From};{OnTill};{EditFrom};{Edit};{CreateFrom};{Create};{Car.Id.ToString()};{Reservation.Id.ToString()}";
        }
    }
}