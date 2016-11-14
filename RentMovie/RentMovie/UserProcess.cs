using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentMovie
{
    public class UserProcess
    {
        public void Process()
        {
            var userTools = new UserTools();
            var displayDataBase = new DisplayDatabase();

            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                DisplayMenu();
                cki = Console.ReadKey(false);
                string input = cki.KeyChar.ToString();
                switch (input)
                {
                    case "1":
                        Space();
                        userTools.AddCustomer();
                        displayDataBase.PrintCustomers();
                        CustomerAdded();
                        break;

                    case "2":
                        Space();
                        userTools.AddMovie();
                        displayDataBase.PrintMovies();
                        MovieAdded();
                        break;

                    case "3":
                        Space();
                        userTools.AddRent();
                        MovieRented();
                        break;

                    case "4":
                        Space();
                        displayDataBase.PrintCustomers();
                        break;

                    case "5":
                        Space();
                        displayDataBase.PrintMovies();
                        break;

                    case "6":
                        Space();
                        userTools.RemoveCustomer();
                        break;

                    case "7":
                        Space();
                        userTools.RemoveMovie();
                        break;

                    case "8":
                        Space();
                        userTools.ReturnMovie();
                        break;

                }


            } while (cki.Key != ConsoleKey.Escape);
        }

        private void DisplayMenu()
        {
            Console.Write("\n------------------\nRentAMovie\n------------------\nWhat action do you wish to take?\n\n1. Add Customer. \n2. Add Movie.\n3. Rent out a movie\n4. Print Customer Registry.\n5. Print Movie Registry.\n6. Remove Customer.\n7. Remove Movie.\n8. Return Movie.\n\nYou may exit by pressing the Escape button at start menu.\n\nYour choice of action: ");
        }
        private void Space()
        {
            Console.WriteLine();
            Console.WriteLine();
        }

        private void CustomerAdded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Customer has been added. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void MovieAdded()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Movie has been added. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void MovieRented()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Movie has been rented to customer. Movie set to return within 7 days. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private void MovieReturned()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Movie has been Returned. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
        }


        private void CustomerDeleted()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Customer has been deleted. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
        }


        private void MovieDeleted()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Movie has been deleted. Press any key to Continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
