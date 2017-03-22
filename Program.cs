using DevProCleaner.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevProCleaner
{
    class Program
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        public static string version = "1.0";

        static void Main(string[] args)
        {
            UselessThings();
            if (CardManager.LoadCDB("cards.cdb", true, true))
            {
                Console.WriteLine("Database loaded (" + CardManager.CardsCount() + " cards).");
                Cleaner cln = new Cleaner();
                cln.Clean();
            }
            else
                Console.WriteLine("Error occured during database loading.");
            Console.ReadKey();
        }

        private static void UselessThings()
        {
            Console.WriteLine("______          ______              ");
            Console.WriteLine("|  _  \\         | ___ \\             ");
            Console.WriteLine("| | | |_____   _| |_/ / __ ___      ");
            Console.WriteLine("| | | / _ \\ \\ / /  __/ '__/ _ \\     ");
            Console.WriteLine("| |/ /  __/\\ V /| |  | | | (_) |    ");
            Console.WriteLine("|___/ \\___| \\_/ \\_|  |_|  \\___/     ");
            Console.WriteLine("                                    ");
            Console.WriteLine(" _____ _                            ");
            Console.WriteLine("/  __ \\ |                           ");
            Console.WriteLine("| /  \\/ | ___  __ _ _ __   ___ _ __ ");
            Console.WriteLine("| |   | |/ _ \\/ _\\` | '_ \\ / _ \\ '__|");
            Console.WriteLine("| \\__/\\ |  __/ (_| | | | |  __/ |   ");
            Console.WriteLine(" \\____/_|\\___|\\__,_|_| |_|\\___|_|   ");
            Console.WriteLine("                                    ");
            Console.WriteLine("Version : " + version + "               ");
            Console.WriteLine("                                    ");
        }
    }
}
