using System.Data;
using System.IO;
using System.Text;
using ZbW.CarRentify.CarManagement.Domain;

namespace ZbW.CarRentify.Common
{
    public static class FileSystem
    {
        public static DataTable LoadeFile(string FilePaths)
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
                return dt;
            }
        }

        public static void CreatFile(string Header, EntityBase basse,string paths,string nameType)
        {
            var csv = new StringBuilder();
            //in your loop
            csv.AppendLine(Header);
            csv.AppendLine(basse.ToString());
            //after your loop
            File.WriteAllText(paths + $"{nameType}_{basse.Id.ToString()}_.csv", csv.ToString());
        }
    }
}