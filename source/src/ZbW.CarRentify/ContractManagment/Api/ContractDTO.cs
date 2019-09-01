using System;
using ZbW.CarRentify.ContractManagment.Domain;

namespace ZbW.CarRentify.ContractManagment.Api
{
    public class ContractDto
    {
        public Guid id { get; set; }
        public int PublicId { get; set; }
        public    DateTime From { get; set; }
        public DateTime OnTil { get; set; }
        public string Description { get; set; }
        public Guid CarId { get; set; }
        public Guid ReservationId { get; set; }
        internal Contract ToObject()
        {
            var contractObject=new Contract(id,new Car(CarId), new Reservation(ReservationId));
            contractObject.PublicId = PublicId;
            contractObject.Description = Description;
            contractObject.From = From;
            contractObject.OnTill = OnTil;
            return contractObject;
        }
    }
}