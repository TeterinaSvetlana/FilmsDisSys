using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FilmsDisSys
{
    using static DataSource.AccessHelper;
    using DataDestination;
    using Converter;
    using Excel;
    using System.Data.OleDb;
    using DataSource;

    class Program
    {
        //public static string msAccessConnectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DataSource/FilmsDumb.accdb;Persist Security Info=False;";
        //private static OleDbConnection msAcessConnection;
        //public static ICollection<FlatTableRow> LoadFlatTableRows;
        static void Main()
        {
            //msAcessConnection = new OleDbConnection(msAccessConnectString);

            //string StrCmd = "Select * from FilmsDumb";

            //msAcessConnection.Open();

            //OleDbCommand command = new OleDbCommand();
            //command.CommandText = StrCmd;
            //command.Connection = msAcessConnection;

            //OleDbDataReader dr = command.ExecuteReader();

            //List<FlatTableRow> list = new List<FlatTableRow>();

            //if (dr.HasRows)
            //{
            //    while (dr.Read())
            //    {
            //        FlatTableRow flatTableRow = new FlatTableRow();
            //        flatTableRow.ID = Convert.ToInt32(dr["ID"]);
            //        flatTableRow.Length = Convert.ToInt32(dr["Length"]);
            //        flatTableRow.NameDirector = Convert.ToString(dr["NameDirector"]);
            //        flatTableRow.NameFilm = Convert.ToString(dr["NameFilm"]);
            //        flatTableRow.NameGenre = Convert.ToString(dr["NameGenre"]);
            //        flatTableRow.NameTag = Convert.ToString(dr["NameTag"]);
            //        flatTableRow.NameType = Convert.ToString(dr["NameType"]);
            //        flatTableRow.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]);
            //        flatTableRow.Country = Convert.ToString(dr["Country"]);

            //        list.Add(flatTableRow);
            //    }
            //}


            LoadFlatTableRows()
                .ConvertToEntities()
                .SaveToSqlServer()
                .GenerateExcel().SaveToFile("result.xlsx");

            string t = Test();
            Console.WriteLine(t.ToString());
            Console.ReadLine();
        }
    }
}
