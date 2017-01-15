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
            //var dBinitilizer = new DBinitilizer();
            //dBinitilizer.SeedDb();

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
                            tools.SearchStudent();
                            break;

                        case "2":
                            tools.SearchStudentWithInclude();
                            break;

                        case "3":
                            tools.PrintStudents();
                            break;
                    }

                } while (cki.Key != ConsoleKey.Escape);               
            
        }
    }
}