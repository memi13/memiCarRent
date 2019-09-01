using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ZbW.CarRentify.Common;
using ZbW.CarRentify.ReservationMangment.Domain;

namespace ZbW.CarRentify.ReservationMangment.Infastructure
{
    public class ReservationRepository:IReservationRepository
    {
        private string paths;
        private string header;

        public ReservationRepository()
        {
            paths = @"C:\temp\CarRent\Reservation\";
            header = "Id;PublicId;Description;From;OnTil;EditFrom;Edit;CreateFrom;Create;CarId;EmployeeId;CustomerId";
        }
        public IEnumerable<Reservation> GetAll()
        {
            List<Reservation> carrClasses = new List<Reservation>();
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                carrClasses.Add(DataTableToCarClass(FileSystem.LoadeFile(path)));
            }
            return carrClasses;
        }

        public Reservation Get(Guid id)
        {
            string[] filePaths = Directory.GetFiles(paths, $"Reservation_{id.ToString()}_.csv");
            if (filePaths.Length > 1)
                throw new ArgumentException("Fehler im File System");
            if (filePaths.Length.Equals(0))
            {
                throw new EntityNotFoundException();
            }
            var contract = DataTableToCarClass(FileSystem.LoadeFile(filePaths[0]));
            return contract;
        }

        public void Insert(Reservation entity)
        {
            entity.Create = DateTime.UtcNow;
            entity.Edit = DateTime.UtcNow;
            entity.CreateFrom = "USER";
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Reservation");
        }

        public void Update(Reservation entity)
        {
            var oldContract = Get(entity.Id);
            entity.CreateFrom = oldContract.CreateFrom;
            entity.Create = oldContract.Create;
            entity.Edit = DateTime.UtcNow;
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Reservation");
        }

        public void Delete(Reservation entity)
        {
            File.Delete(paths + $"Reservation_{ entity.Id.ToString()}_.csv");
        }
        private Reservation DataTableToCarClass(DataTable dt)
        {
            var row1 = dt.Rows[0];
            var id = row1.ItemArray[0].ToString();
            var reservation = new Reservation(Guid.Parse(id), new Car(Guid.Parse(row1.ItemArray[9].ToString())),new Customer(Guid.Parse(row1.ItemArray[11].ToString())), new Employee(Guid.Parse(row1.ItemArray[10].ToString())));
            reservation.PublicId = int.Parse(row1.ItemArray[1].ToString());
            reservation.Description = row1.ItemArray[2].ToString();
            reservation.From = DateTime.Parse(row1.ItemArray[3].ToString());
            reservation.OnTil = DateTime.Parse(row1.ItemArray[4].ToString());
            reservation.EditFrom = row1.ItemArray[5].ToString();
            reservation.CreateFrom = row1.ItemArray[7].ToString();
            reservation.Edit = DateTime.Parse(row1.ItemArray[6].ToString());
            reservation.Create = DateTime.Parse(row1.ItemArray[8].ToString());
            return reservation;
        }
    }
}