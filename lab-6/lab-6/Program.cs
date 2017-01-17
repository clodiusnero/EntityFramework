using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_6.Models;

namespace lab_6
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hej Björn!\n\nDu kanske minns att jag hade problem på praktiska tentan med att skapa och seeda en databas?\n\nDetta program gjordes innan ominstallation och problemet var borta. Det har fungerat.\n\nJag har problem att köra det men du kan se i koden att alla uppgifter är gjorda.\n\nJag har märkt ut dem med kommentarer, kolla klassen Tools.\n\nVidare, mina klasskamrater berättade att de fick tips och hjälp med labben av dig på redovisningsdagen.\n\nKan du se vart skon klämmer?");
            Console.ReadKey();
            var dBinitilizer = new DBinitilizer();
            dBinitilizer.SeedDb();

            var programInterface = new Interface();

                ConsoleKeyInfo cki;
                do
                {
                    Console.Clear();
                    cki = Console.ReadKey(false);

                    programInterface.DisplayMenu();
                    var tools = new Tools();
                    var choice = cki.KeyChar.ToString();
                    switch (choice)
                    {
                        case "1":
                        programInterface.Space();
                        tools.PrintStudents();
                        programInterface.PrintCompleted();
                        break;

                        case "2":
                        programInterface.Space();
                        tools.SearchStudentFirstMidName();
                        programInterface.PrintCompleted();
                        break;

                        case "3":
                        programInterface.Space();
                        tools.SearchStudentWithInclude();
                        programInterface.PrintCompleted();
                        break;
                    }

                } while (cki.Key != ConsoleKey.Escape);

            
        }
    }
}