using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ZbW.CarRentify.CarManagement.Domain;
using ZbW.CarRentify.Common;

namespace ZbW.CarRentify.CarManagement.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private string paths;

        public CarRepository()
        {
            paths = @"C:\temp\CarRent\Car\";
        }

        public void Delete(Car entity)
        {
        }

        public Car Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            List<Car> cars=new List<Car>();
            //paths + "Car_2b95a27f-8ff3-4c11-8ba1-329a4ad4fedc_.csv"
            string[] filePaths = Directory.GetFiles(paths, "*.csv");
            foreach (var path in filePaths)
            {
                 cars.Add(LoadeFile(path));
            }

            return cars;
        }

        public void Insert(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }

        private Car LoadeFile(string FilePaths)
        {


            DataTable dt = new DataTable();
            FileStream aFile = new FileStream(FilePaths, FileMode.Open);
            using (StreamReader sr = new StreamReader(aFile, System.Text.Encoding.Default))
            {
                string strLine = sr.ReadLine();
                string[] strArray = strLine.Split(";");

                foreach (string value in strArray)
                    dt.Columns.Add(value.Trim());

                DataRow dr = dt.NewRow();

                while (sr.Peek() > -1)
                {
                    strLine = sr.ReadLine();
                    strArray = strLine.Split(";");
                    dt.Rows.Add(strArray);
                }

                var row1 = dt.Rows[0];
                var id = row1.ItemArray[0].ToString();


                var newCar = new Car(Guid.Parse(id),new Model(Guid.Parse(row1.ItemArray[9].ToString())));
                newCar.PublicId = int.Parse(row1.ItemArray[1].ToString());
              
                return newCar;
            }

            return null;



        }
    }
}
