using System;
using System.Collections.Generic;
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

        public List<Template> getAll()
        {
            List<Template> template = new List<Template>();
            sqlCommand.CommandText = "SELECT `a`,`b`,`c`,`d`,`e` FROM `template` WHERE 1";
            kapcsolatNyit();
            using (MySqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    Template uj = new Template(dr.GetString("a"),dr.GetString("b"),dr.GetString("c"),dr.GetInt32("d"),dr.GetInt32("e"));
                    template.Add(uj);
                }
            }
            kapcsolatZar();
            return template;
        }
    }
}
