using CinemaConsoleApp.Models;
using CinemaConsoleApp.Services;

namespace CinemaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cinemaManager = new CinemaManager();
            var hallManager = new HallManager(cinemaManager);
            var filmManager = new FilmManager();
            var sessionManager = new SessionManager(cinemaManager, filmManager, hallManager);
            var ticketManager = new TicketmManager(sessionManager);

            var genclikMall = new Cinema()
            {
                Id = 1,
                Name = "GenclikMall",
            };

            var parkBulvar = new Cinema()
            {
                Id = 2,
                Name = "ParkBulvar",
            };
            cinemaManager.Add(genclikMall);
            cinemaManager.Add(parkBulvar);

            cinemaManager.Print();

            var zal1 = new Hall
            {
                Id = 1,
                Name = "Zal 1",
                Row = 8,
                Col = 10
            };
            var zal2 = new Hall
            {
                Id = 2,
                Name = "Zal 2",
                Row = 10,
                Col = 10
            };

            Hall zal3 = new Hall
            {
                Id = 3,
                Name = "Zal 3",
                Row = 8,
                Col = 8
            };

            hallManager.Add(1, zal1);
            hallManager.Add(1, zal2);
            hallManager.Add(1, zal3);
            cinemaManager.Print();


            hallManager.Delete(3);
            cinemaManager.Print();
            hallManager.Print();
            hallManager.Print(1);

            var film1 = new Film
            {
                Id = 1,
                Name = "The Godfather",
                Genre = "Crime, Drama",
                Director = "Francis Ford Coppola",
                Time = 175,
            };
            var film2 = new Film
            {
                Id = 2,
                Name = "Interstellar",
                Genre = "Adventure, Drama, Sci-Fi",
                Director = "Christopher Nolan",
                Time = 169,
            };
            var film3 = new Film
            {
                Id = 3,
                Name = "Spirited Away",
                Genre = "Adventure, Animation, Family",
                Director = "Hayao Miyazaki",
                Time = 125,
            };
            var film4 = new Film
            {
                Id = 4,
                Name = "The Intouchables",
                Genre = "Biography, Comedy, Drama",
                Director = "Olivier Nakache * Éric Toledano",
                Time = 112,
            };

            filmManager.Add(film1);
            filmManager.Add(film2);
            filmManager.Add(film3);
            filmManager.Add(film4);
            filmManager.Print();

            filmManager.Delete(3);
            filmManager.Print();

            var film5 = new Film
            {
                Id = 5,
                Name = "Forrest Gump",
                Genre = "Drama, Romance",
                Director = "Robert Zemeckis",
                Time = 142,
            };
            filmManager.Update(4, film5);
            filmManager.Print();

            var date = new DateTime(2023, 2, 3, 9, 0, 0);
            var date1 = new DateTime(2023, 2, 3, 12, 20, 0);
            var date2 = new DateTime(2023, 2, 3, 16, 20, 0);
            var date3 = new DateTime(2023, 2, 3, 20, 30, 0);
            var date4 = new DateTime(2023, 2, 3, 23, 40, 0);

            sessionManager.Add(1, 1, 1, 1, 10, date);
            sessionManager.Add(1, 2, 5, 1, 8, date1);
            sessionManager.Add(1, 2, 2, 1, 5, date2);
            sessionManager.Add(1, 2, 5, 1, 8, date3);
            sessionManager.Add(1, 2, 5, 1, 8, date4);
            sessionManager.Print();

            ticketManager.BuyTicket(1, 1, 1);
            ticketManager.BuyTicket(1, 3, 5);
            ticketManager.BuyTicket(1, 1, 1);
            ticketManager.BuyTicket(1, 3, 5);


        }
    }
}