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

        public void ReturnMovie()
        {
            using (var ctx = new MyMediaEntities())
            {
                Console.Write("Choose ID for Rented Movie to remove:");
                var removeRent = new RentedMovie { RentedID = int.Parse(Console.ReadLine()) };

                if ((removeRent.RentExpires - DateTime.Now).TotalDays > 0)
                {
                    Console.WriteLine("What the fuck did you just fucking say about me, you little bitch? I’ll have you know I graduated top of my class in the Navy Seals, and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I’m the top sniper in the entire US armed forces. You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You’re fucking dead, kiddo.");
                    ctx.RentedMovies1.Attach(removeRent);
                    ctx.RentedMovies1.Remove(removeRent);
                    ctx.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Action completed. Press any key to Continue...");
                    Console.ReadKey();
                }
                else
                {
                    ctx.RentedMovies1.Attach(removeRent);
                    ctx.RentedMovies1.Remove(removeRent);
                    ctx.SaveChanges();
                    Console.WriteLine();
                    Console.WriteLine("Action completed. Press any key to Continue...");
                    Console.ReadKey();
                }
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