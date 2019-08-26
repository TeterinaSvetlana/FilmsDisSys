using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.DataSource
{
    class ReadFromAccess
    {
        public static string msAccessConnectString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=DataSource/FilmsDumb.accdb;Persist Security Info=False;";
        private static OleDbConnection msAcessConnection;

        static List<FlatTableRow> GetData()
        {
            msAcessConnection = new OleDbConnection(msAccessConnectString);

            string StrCmd = "Select * from FilmsDumb";

            msAcessConnection.Open();

            OleDbCommand command = new OleDbCommand();
            command.CommandText = StrCmd;
            command.Connection = msAcessConnection;

            OleDbDataReader dr = command.ExecuteReader();

            List<FlatTableRow> list = new List<FlatTableRow>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    FlatTableRow flatTableRow = new FlatTableRow();
                    flatTableRow.ID = Convert.ToInt32(dr["ID"]);
                    flatTableRow.Length = Convert.ToInt32(dr["Length"]);
                    flatTableRow.NameDirector = Convert.ToString(dr["NameDirector"]);
                    flatTableRow.NameFilm = Convert.ToString(dr["NameFilm"]);
                    flatTableRow.NameGenre = Convert.ToString(dr["NameGenre"]);
                    flatTableRow.NameTag = Convert.ToString(dr["NameTag"]);
                    flatTableRow.NameType = Convert.ToString(dr["NameType"]);
                    flatTableRow.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]);
                    flatTableRow.Country = Convert.ToString(dr["Country"]);

                    list.Add(flatTableRow);
                }
            }
            return list;
        }
    }
}
