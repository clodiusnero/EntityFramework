using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RentMovie
{
    public class UserTools
    {
        public void AddCustomer()
        {
            using (var ctx = new MyMediaEntities())
            {
                Customer newCustomer = new Customer();
                Console.Write("Enter full Customer name: ");
                newCustomer.CustomerName = Console.ReadLine();
                Console.Write("Enter adress: ");
                newCustomer.CustomerAdress = Console.ReadLine();
                Console.Write("Enter e-mail: ");
                newCustomer.CustomerPhone = Console.ReadLine();

                ctx.Customers.Add(newCustomer);
                ctx.SaveChanges();
            }
        }


        public void AddMovie()
        {
            using (var ctx = new MyMediaEntities())
            {
                Movie newMovie = new Movie();
                Console.Write("Enter Title: ");
                newMovie.MovieName = Console.ReadLine();
                Console.Write("Enter Directors Name: ");
                newMovie.DirectorName = Console.ReadLine();
                Console.Write("Enter Release Date (YYYY/MM/DD): ");
                newMovie.ReleaseDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter GenreID: ");
                newMovie.genreID = int.Parse(Console.ReadLine());

                ctx.Movies1.Add(newMovie);
                ctx.SaveChanges();
            }
        }


        public void AddRent()
        {
            using (var ctx = new MyMediaEntities())
            {
                RentedMovie newRent = new RentedMovie();
                Console.Write("Enter Customer ID: ");
                newRent.CustomerID = int.Parse(Console.ReadLine());
                Console.Write("Enter Movie ID: ");
                newRent.MovieID = int.Parse(Console.ReadLine());
                newRent.RentExpires = DateTime.Now.AddDays(7);

                ctx.RentedMovies1.Add(newRent);
                ctx.SaveChanges();
            }
        }




        public void RemoveMovie()
        {
            using (var ctx = new MyMediaEntities())
            {
                Console.Write("Choose ID for Movie to remove:");
                var removeMovie = new Movie { MovieId = int.Parse(Console.ReadLine()) };
                ctx.Movies1.Attach(removeMovie);
                ctx.Movies1.Remove(removeMovie);
                ctx.SaveChanges();
            }
        }

        public void RemoveCustomer()
        {
            using (var ctx = new MyMediaEntities())
            {
                Console.Write("Choose ID for Customer to remove:");
                var removeCustomer = new Customer { CustomerID = int.Parse(Console.ReadLine()) };
                ctx.Customers.Attach(removeCustomer);
                ctx.Customers.Remove(removeCustomer);
                ctx.SaveChanges();
            }
        }


        public string DisplayMovie(Movie movie)
        {
            var movieinfo = $"ID: {movie.MovieId} Name: {movie.MovieId}";
            return movieinfo;
        }

        public List<Movie> SearchMovie(string search)
        {
            using (var ctx = new MyMediaEntities())
            {
                var movies = ctx.Movies1.Where(x => x.DirectorName.Contains(search)).ToList();
                return movies;
            }
        }

        public string UpdateMovie(Movie movie)
        {
            string message = string.Empty;

            using (var ctx = new MyMediaEntities())
            {
                ctx.Entry(movie).State = EntityState.Modified;
                ctx.SaveChanges();
                message = "Author was updated.";
            }
            return message;

        }
        
        public List<Movie> getMovies (string search)

        {
            using (var ctx = new MyMediaEntities())
            {
                var movies = ctx.Movies1.Where(x => x.DirectorName.Contains(search)).ToList();
                return movies;
            }
        }

        public List<Movie> FindAMovie (string search)
        {
            var convert = int.Parse(search);
            using (var ctx = new MyMediaEntities())
            {
                var movies = ctx.Movies1.Where(x => x.genreID == convert).ToList();
                return movies;
            }
        }

        public List<Movie> GettingMovies(string search)
        {
            using (var ctx = new MyMediaEntities())
            {
                var movies = ctx.Movies1.Where(x => x.DirectorName.Contains(search)).ToList();
                return movies;
            }
        }

        public void AddMoviesToRegister()
        {
            using (var ctx = new MyMediaEntities())
            {
                var movie = new Movie();
                movie.DirectorName = Console.ReadLine();
                movie.MovieName = Console.ReadLine();
                ctx.Movies1.Add(movie);
            }
        }

        public string UpdateMovieAgain(Movie movie)
        {
            string message = string.Empty;

            using (var ctx = new MyMediaEntities())
            {
                ctx.Entry(movie).State = EntityState.Modified;
                ctx.SaveChanges();
                message = "Author was updated.";
            }
            return message;

        }

        public string DisplayMovieAgain(Movie movie)
        {
            var movieinfo = $"ID: {movie.MovieId} Name: {movie.MovieId}";
            return movieinfo;
        }

        public 
    }
}