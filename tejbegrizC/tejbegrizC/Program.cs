using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace templateNev
{
    internal class Program
    {
        static Adatbazis db = new Adatbazis();
        static List<Template> template = new List<Template>();

        static void Main(string[] args)
        {
            adatbeolvasas();
            feladat01();
            feladat02();
            feladat03();
            feladat04();
            Console.ReadKey();
        }

        private static void feladat04()
        {
            Console.WriteLine("\n4.Feladat | ");
            foreach (Template item in template.FindAll(a => a.reszleg == "random"))
            {
                Console.WriteLine($"\t{item.nev}");
            }
        }

        private static void feladat03()
        {
            var reszlegek = template.GroupBy(a => a.reszleg).Select(b => new {reszleg = b.Key,letszam = b.Count()});
            Console.WriteLine("\n3.Feladat | Almaleves");
            foreach (var item in reszlegek)
            {
                Console.WriteLine($"\t{item.reszleg}: {item.letszam} fő");
            }
        }

        private static void feladat02()
        {
            Template max = template.OrderByDescending(a => a.ber).First();
            Console.WriteLine(Environment.NewLine+$"2.Feladat | aaaaaa: {max.nev}");
        }

        private static void feladat01()
        {
            Console.WriteLine($"1.Feladat | aham száma: {template.Count} fő");
        }

        private static void adatbeolvasas()
        {
            template = db.getAll();
        }

    }
}
