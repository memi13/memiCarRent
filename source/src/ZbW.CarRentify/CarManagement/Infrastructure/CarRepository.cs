using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private string paths;
        private string header;

        public CarRepository()
        {
            paths = @"C:\temp\CarRent\Car\";
            header = "Id;PublicId;Description;HP;InOperationSince;EditFrom;Edit;CreateFrom;Create;Model";
        }

        public void Delete(Car entity)
        {
            File.Delete(paths+$"Car_{entity.Id.ToString()}_.csv");
        }

        public Car Get(Guid id)
        {
            string[] filePaths = Directory.GetFiles(paths, $"Car_{id.ToString()}_.csv");
            if(filePaths.Length>1)
                throw new ArgumentException("Fehler im File System");
            if (filePaths.Length.Equals(0))
            {
                throw new EntityNotFoundException();
            }
            var car= DataTableToCar(FileSystem.LoadeFile(filePaths[0]));
            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            List<Car> cars=new List<Car>();
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                 cars.Add(DataTableToCar(FileSystem.LoadeFile(path)));
            }

            return cars;
        }

        public void Insert(Car entity)
        {
            entity.Create = DateTime.UtcNow;
            entity.Edit = DateTime.UtcNow;
            entity.CreateFrom = "USER";
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths,"Car");
        }

        public void Update(Car entity)
        {
            var oldcar = Get(entity.Id);
            entity.CreateFrom = oldcar.CreateFrom;
            entity.Create = oldcar.Create;
            entity.Edit = DateTime.UtcNow;
            entity.EditFrom = "USER";
            FileSystem.CreatFile(header, entity, paths, "Car");
        }

        private Car DataTableToCar(DataTable dt)
        {
            var row1 = dt.Rows[0];
            var id = row1.ItemArray[0].ToString();
            var newCar = new Car(Guid.Parse(id), new Model(Guid.Parse(row1.ItemArray[9].ToString())));
            newCar.PublicId = int.Parse(row1.ItemArray[1].ToString());
            newCar.Description = row1.ItemArray[2].ToString();
            newCar.HorsPower = int.Parse(row1.ItemArray[3].ToString());
            newCar.InOperationSince = DateTime.Parse(row1.ItemArray[4].ToString());
            newCar.EditFrom = row1.ItemArray[5].ToString();
            newCar.CreateFrom = row1.ItemArray[7].ToString();
            newCar.Edit = DateTime.Parse(row1.ItemArray[6].ToString());
            newCar.Create = DateTime.Parse(row1.ItemArray[8].ToString());
            return newCar;
        }
        //private DataTable LoadeFile(string FilePaths)
        //{
        //    DataTable dt = new DataTable();
        //    FileStream aFile = new FileStream(FilePaths, FileMode.Open);
        //    using (StreamReader sr = new StreamReader(aFile, System.Text.Encoding.Default))
        //    {
        //        string strLine = sr.ReadLine();
        //        string[] strArray = strLine.Split(";");

        //        foreach (string value in strArray)
        //            dt.Columns.Add(value.Trim());
        //        DataRow dr = dt.NewRow();

        //        while (sr.Peek() > -1)
        //        {
        //            strLine = sr.ReadLine();
        //            strArray = strLine.Split(";");
        //            dt.Rows.Add(strArray);
        //        }
        //        return dt;
        //    }
        //}

        //private void CreatFile(string Header,Car car)
        //{
        //    var csv = new StringBuilder();
        //    //in your loop
        //    csv.AppendLine(Header);
        //    csv.AppendLine(car.ToString());
        //    //after your loop
        //    File.WriteAllText(paths+$"Car_{car.Id.ToString()}_.csv", csv.ToString());
        //}
    }
}
