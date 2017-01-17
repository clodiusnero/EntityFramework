using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    public class Interface
    {
        public void DisplayMenu()
        {
            Console.WriteLine("School Database.\nPress ESC at start menu to exit.\nWhat would you like to do?\n\n1: Search student.\n2: Search student using Include.\n3: Print Students.\n\n");
        }
        public void Space()
        {
            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintCompleted()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Record printed, press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
