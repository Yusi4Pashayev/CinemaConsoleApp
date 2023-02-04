using CinemaConsoleApp.Models;
using CinemaConsoleApp.Services.Contacts;
using System;


namespace CinemaConsoleApp.Services
{
    internal class SessionManager : ICrudService
    {
        private CinemaManager _cinemaManager;
        private FilmManager _filmManager;
        private HallManager _hallManager;
        private int _sessionIndex = 0;
        internal Session[] Sessions { get; set; } = new Session[21];

        public SessionManager(CinemaManager cinemaManager, FilmManager filmManager, HallManager hallManager)
        {
            _cinemaManager = cinemaManager;
            _filmManager = filmManager;
            _hallManager = hallManager;
        }

        public void Add(int cinemaId, int hallId, int filmId, int sessionId,int price, DateTime seanceTime)
        {
            if ((Cinema)_cinemaManager.Get(cinemaId) == null)
            {
                Console.WriteLine($"{cinemaId} Cinema Tapilmadi");
                return;
            }
            if ((Hall)_hallManager.Get(hallId) == null)
            {
                Console.WriteLine($"{hallId} Zal Tapilmadi");
                return;
            }
            if ((Film)_filmManager.Get(filmId) == null)
            {
                Console.WriteLine($"{filmId} Film Tapilmadi");
                return;
            }
            if (((Film)_filmManager.Get(filmId)).Time == 0)
            {
                Console.WriteLine($"{filmId} Id li film melumatlari tam deyil");
                return;
            }

            var session = new Session
            {
                Id = sessionId,
                Cinema = (Cinema)_cinemaManager.Get(cinemaId),
                Hall = (Hall)_hallManager.Get(hallId),
                Film = (Film)_filmManager.Get(filmId),
                StartTime = seanceTime,
                EndTime = seanceTime.AddMinutes((int)((Film)_filmManager.Get(filmId)).Time),
                Price = price
            };
            Add(session);
        }
        public void Add(Entity entity)
        {
            Sessions[_sessionIndex] = (Session)entity;
            Sessions[_sessionIndex].seats = new string[Sessions[_sessionIndex].Hall.Row+1, Sessions[_sessionIndex].Hall.Col+1];
            for (int i = 0; i < Sessions[_sessionIndex].Hall.Row+1; i++)
            {
                for (int j = 0; j < Sessions[_sessionIndex].Hall.Col+1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        Sessions[_sessionIndex].seats[i, j] = $"{"S/S",-7}";
                    }
                    if (i > 0 && j == 0)
                    {
                        Sessions[_sessionIndex].seats[i, j] = $"{i,-7}";
                    }
                    if (i == 0 && j > 0)
                    {
                        Sessions[_sessionIndex].seats[i, j] = $"{j,-7}";
                    }
                    if (i > 0 && j > 0)
                    {
                        Sessions[_sessionIndex].seats[i, j] = $"{"Empty",-7}";
                    }
                }
            }
            Console.WriteLine("Seans elave olundu");
            Console.WriteLine("___________________________");

            _sessionIndex++;

            if (_sessionIndex > 19)
            {
                Console.WriteLine("Seans limitini kecmisiz");
                return;
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < Sessions.Length; i++)
            {
                if (Sessions[i].Id == id)
                {
                    Sessions[i] = Sessions[i + 1];
                    _sessionIndex--;
                    return;
                }
            }
            Console.WriteLine("Bu ID de seans yoxdur!!");
        }

        public Entity[] GetAll()
        {
            return Sessions;
        }

        public Entity Get(int id)
        {
            for (int i = 0; i < Sessions.Length; i++)
            {
                if (Sessions[i] == null)
                    continue;

                if (Sessions[i].Id == id)
                    return Sessions[i];
            }
            Console.WriteLine("Seans tapilmadi");
            return null;
        }
        public void Update(int cinemaId, int hallId, int filmId, DateTime seanceTime, int sessionId,int price,int newSessionId)
        {

            if ((Cinema)_cinemaManager.Get(cinemaId) == null)
            {
                Console.WriteLine($"{cinemaId} Cinema Tapilmadi");
                return;
            }
            if ((Hall)_hallManager.Get(hallId) == null)
            {
                Console.WriteLine($"{hallId} Zal Tapilmadi");
                return;
            }
            if ((Film)_filmManager.Get(filmId) == null)
            {
                Console.WriteLine($"{filmId} Film Tapilmadi");
                return;
            }
            if (((Film)_filmManager.Get(filmId)).Time == 0)
            {
                Console.WriteLine($"{filmId} Cinema melumatlari Tapilmadi");
                return;
            }

            var seans = new Session
            {
                Id= newSessionId,
                Cinema = (Cinema)_cinemaManager.Get(cinemaId),
                Hall = (Hall)_hallManager.Get(hallId),
                Film = (Film)_filmManager.Get(filmId),
                StartTime = seanceTime,
                EndTime = seanceTime.AddMinutes((int)((Film)_filmManager.Get(filmId)).Time),
                Price= price
                
            };

            Update(sessionId, seans);
        }
        public void Update(int id, Entity entity)
        {
            for (int i = 0; i < Sessions.Length; i++)
            {
                if (Sessions[i] == null)
                    continue;

                if (Sessions[i].Id == id)
                {
                    Sessions[i] = (Session)entity;
                    Console.WriteLine("Seans ugurla deyisdirildi");
                    return;
                }
            }
        }
        public void Print()
        {
            Console.WriteLine($"{"BUTUN SEANSLARIN SIYAHISI",30}");
            Console.WriteLine("__________________________________________");

            foreach (var item in Sessions)
            {
                if (item == null)
                    continue;

                Console.WriteLine(item);
                Console.WriteLine("__________________________________________");
            }
        }
        public void Print(int sessionId)
        {
            Console.WriteLine($"{"SCILEN SEANS",25}");
            Console.WriteLine("__________________________________________");
            Session session = (Session)Get(sessionId);
            if (session == null)
            {
                Console.WriteLine("Bu id ile Seans yoxdur");
                return;
            }

            for (int i = 0; i < session.Hall.Row + 1; i++)
            {
                for (int j = 0; j < session.Hall.Col + 1; j++)
                {
                    Console.Write(session.seats[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(session);
            Console.WriteLine("__________________________________________");
        }
    }
}
