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
            var nizami = new Cinema()
            {
                Id = 3,
                Name = "Nizami",
            };

            cinemaManager.Add(genclikMall);
            cinemaManager.Add(parkBulvar);
            cinemaManager.Add(nizami);

            cinemaManager.Print();

            Hall zal1 = new Hall
            {
                Id = 1,
                Name = "Tornado",
                Row = 8,
                Col = 10
            };
            Hall zal2 = new Hall
            {
                Id = 2,
                Name = "Titan",
                Row = 10,
                Col = 10
            };
            Hall zal3 = new Hall
            {
                Id = 3,
                Name = "Merkuri",
                Row = 12,
                Col = 8
            };
            Hall zal4 = new Hall
            {
                Id = 4,
                Name = "Venera",
                Row = 8,
                Col = 8
            };
            Hall zal5 = new Hall
            {
                Id = 5,
                Name = "Andromeda",
                Row = 15,
                Col = 12
            };
            Hall zal6 = new Hall
            {
                Id = 6,
                Name = "Avropa",
                Row = 8,
                Col = 10
            };
            Hall zal7 = new Hall
            {
                Id = 7,
                Name = "Pluto",
                Row = 6,
                Col = 6
            };

            hallManager.Add(1, zal1);
            hallManager.Add(1, zal2);
            hallManager.Add(1, zal3);
            hallManager.Add(2, zal4);
            hallManager.Add(2, zal5);
            hallManager.Add(3, zal6);
            hallManager.Add(3, zal7);

            cinemaManager.Print();
            hallManager.Print();

            hallManager.Delete(3);
            hallManager.Print();
            cinemaManager.Print();
            
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
            var film5 = new Film
            {
                Id = 5,
                Name = "The Dark Knight",
                Genre = "Action, Crime, Drama",
                Director = "Christopher Nolan",
                Time = 152,
            };
            var film6 = new Film
            {
                Id = 6,
                Name = "The Imitation Game",
                Genre = "Biography, Thriller, Drama",
                Director = "Morten Tyldum",
                Time = 116,
            };
            var film7 = new Film
            {
                Id = 7,
                Name = "A Beautiful Mind",
                Genre = "Biography, Drama",
                Director = "Ron Howard",
                Time = 135,
            };

            filmManager.Add(film1);
            filmManager.Add(film2);
            filmManager.Add(film3);
            filmManager.Add(film4);
            filmManager.Add(film5);
            filmManager.Add(film6);
            filmManager.Add(film7);
            filmManager.Print();

            filmManager.Delete(3);
            filmManager.Print();

            var filmForUpdate = new Film
            {
                Id = 5,
                Name = "Forrest Gump",
                Genre = "Drama, Romance",
                Director = "Robert Zemeckis",
                Time = 142,
            };
            filmManager.Update(4, filmForUpdate);
            filmManager.Print();

            var date = new DateTime(2023, 2, 3, 9, 0, 0);
            var date1 = new DateTime(2023, 2, 3, 12, 20, 0);
            var date2 = new DateTime(2023, 2, 3, 16, 20, 0);
            var date3 = new DateTime(2023, 2, 3, 20, 30, 0);
            var date4 = new DateTime(2023, 2, 3, 23, 40, 0);

            sessionManager.Add(1, 1, 1, 1, 10, date);
            sessionManager.Add(1, 2, 5, 2, 8, date1);
            sessionManager.Add(1, 2, 2, 3, 5, date2);
            sessionManager.Add(1, 2, 5, 4, 8, date3);
            sessionManager.Add(1, 2, 5, 5, 8, date4);
            sessionManager.Print();

            ticketManager.BuyTicket(1, 1, 1);
            ticketManager.BuyTicket(1, 3, 5);
            ticketManager.BuyTicket(3, 3, 3);
            ticketManager.BuyTicket(1, 3, 5);


        }
    }
}