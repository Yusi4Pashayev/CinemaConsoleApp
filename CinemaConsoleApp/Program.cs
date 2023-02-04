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
            var flameTowrs = new Cinema()
            {
                Id = 4,
                Name = "FlameTowrs",
            };

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
            Hall zallForUpdate = new Hall
            {
                Id = 7,
                Name = "Pluto",
                Row = 6,
                Col = 6
            };
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
            var filmForUpdate = new Film
            {
                Id = 5,
                Name = "Forrest Gump",
                Genre = "Drama, Romance",
                Director = "Robert Zemeckis",
                Time = 142,
            };
            var date = new DateTime(2023, 2, 3, 9, 0, 0);
            var date1 = new DateTime(2023, 2, 3, 12, 20, 0);
            var date2 = new DateTime(2023, 2, 3, 16, 20, 0);
            var date3 = new DateTime(2023, 2, 3, 20, 30, 0);
            var date4 = new DateTime(2023, 2, 3, 23, 40, 0);

            string command = "";
            int id, row, col;

            Console.WriteLine("Command List:");
            Console.WriteLine("1. add cinema\n2. delete cinema\n3. update cinema\n4. print cinemas\n5. add hall\n6. delete hall\n7. update hall\n8. print halls\n9. print hall with id\n" +
                "10. add film\n11. delete film\n12. update film\n13. print films\n14. add session\n15. delete session\n16. update session\n17. print sessions\n18. print session with id\n" +
                "19. buy ticket");

            while (true)
            {
                do
                {
                    Console.Write("Write command:");
                    command = (Console.ReadLine().ToLower()).Trim();
                    id = 0;

                    switch (command)
                    {
                        case "add cinema":
                            cinemaManager.Add(genclikMall);
                            cinemaManager.Add(parkBulvar);
                            cinemaManager.Add(nizami);
                            break;
                        case "delete cinema":
                            Console.Write("Silmek istediyniz cinemanin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            cinemaManager.Delete(id);
                            break;
                        case "update cinema":
                            Console.Write("Deyismek istediyniz cinemanin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            cinemaManager.Update(id, flameTowrs);
                            break;
                        case "print cinemas":
                            cinemaManager.Print();
                            break;
                        case "add hall":
                            hallManager.Add(1, zal1);
                            hallManager.Add(1, zal2);
                            hallManager.Add(1, zal3);
                            hallManager.Add(2, zal4);
                            hallManager.Add(2, zal5);
                            hallManager.Add(3, zal6);
                            break;
                        case "delete hall":
                            Console.Write("Silmek istediyniz zalin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            hallManager.Delete(id);
                            break;
                        case "update hall":
                            Console.Write("Deyismek istediyniz zalin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            hallManager.Update(id, zallForUpdate);
                            break;
                        case "print halls":
                            hallManager.Print();
                            break;
                        case "print hall with id":
                            Console.Write("secdiyiniz zalin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            hallManager.Print(id);
                            break;
                        case "add film":
                            filmManager.Add(film1);
                            filmManager.Add(film2);
                            filmManager.Add(film3);
                            filmManager.Add(film4);
                            filmManager.Add(film5);
                            filmManager.Add(film6);
                            filmManager.Add(film7);
                            break;
                        case "delete film":
                            Console.Write("Silmek istediyiniz filmin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            filmManager.Delete(id);
                            break;
                        case "update film":
                            Console.Write("Deyismek istediyiniz filmin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            filmManager.Update(id, filmForUpdate);
                            break;
                        case "print films":
                            filmManager.Print();
                            break;
                        case "add session":
                            sessionManager.Add(1, 1, 1, 1, 10, date);
                            sessionManager.Add(1, 2, 5, 2, 8, date1);
                            sessionManager.Add(1, 2, 2, 3, 5, date2);
                            sessionManager.Add(1, 2, 5, 4, 8, date3);
                            sessionManager.Add(1, 2, 5, 5, 8, date4);
                            break;
                        case "update session":
                            sessionManager.Update(1, 2, 5, date4, 1, 7, 6);
                            break;
                        case "print sessions":
                            sessionManager.Print();
                            break;
                        case "print session with id":
                            Console.Write("Baxmaq istediyiniz seansin id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            sessionManager.Print(id);
                            break;
                        case "buy ticket":
                            Console.Write("Seansin Id sini daxil edin:");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("Sira secin:");
                            row = int.Parse(Console.ReadLine());
                            Console.Write("Yer secin:");
                            col = int.Parse(Console.ReadLine());
                            ticketManager.BuyTicket(id, row, col);
                            break;
                    }

                } while (command == "quit");
            }

        }
    }
}