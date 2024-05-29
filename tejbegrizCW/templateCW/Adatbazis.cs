using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace templateNev
{
    internal class Adatbazis
    {
        MySqlCommand sqlCommand = null;
        MySqlConnection connection = null;

        public Adatbazis()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "template";
            sb.CharacterSet = "utf8";
            connection = new MySqlConnection(sb.ConnectionString);
            try
            {
                kapcsolatNyit();
                sqlCommand = connection.CreateCommand();
                kapcsolatZar();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Adatbázis hiba!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private void kapcsolatNyit()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private void kapcsolatZar()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public List<Dolgozo> getAll()
        {
            List<Dolgozo> dolgozok = new List<Dolgozo>();
            sqlCommand.CommandText = "SELECT `nev`,`neme`,`reszleg`,`belepesev`,`ber` FROM `dolgozok` WHERE 1";
            kapcsolatNyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Dolgozo uj = new Dolgozo(dr.GetString("nev"), dr.GetString("neme"), dr.GetString("reszleg"), dr.GetInt32("belepesev"), dr.GetInt32("ber"));
                    dolgozok.Add(uj);
                }
            }
            kapcsolatZar();
            return dolgozok;
        }
    }
}
