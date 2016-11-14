using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RentMovie
{
    public class DisplayDatabase
    {
    public void PrintMovies()
        {
            using (var ctx = new MyMediaEntities())
            {
                var query = from it in ctx.Movies1
                            orderby it.MovieId, it.MovieName, it.DirectorName, it.ReleaseDate
                            select it;


                foreach (Movie movie in query)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3}", movie.MovieId, movie.MovieName, movie.DirectorName, movie.ReleaseDate);
                }
                Console.WriteLine();
                Console.WriteLine("Action completed. Press any key to Continue...");
                Console.ReadKey();
            }
        }

        public void PrintCustomers()
        {
            using (var ctx = new MyMediaEntities())
            {
                var query = from it in ctx.Customers
                            orderby it.CustomerID, it.CustomerName, it.CustomerAdress, it.CustomerPhone
                            select it;

                foreach (Customer customer in query)
                {
                    Console.WriteLine("{0} | {1} | {2} | {3} |", customer.CustomerID, customer.CustomerName, customer.CustomerAdress, customer.CustomerPhone);
                }
                Console.WriteLine();
                Console.WriteLine("Action completed. Press any key to Continue...");
                Console.ReadKey();
            }

        }
    }
}
