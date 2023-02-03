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
        internal Session[] Session { get; set; } = new Session[21];

        public SessionManager(CinemaManager cinemaManager, FilmManager filmManager, HallManager hallManager)
        {
            _cinemaManager = cinemaManager;
            _filmManager = filmManager;
            _hallManager = hallManager;
        }

        public void Add(int cinemaId, int hallId, int filmId, int sessionId, DateTime seanceTime)
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

            var session = new Session
            {
                Id = sessionId,
                Cinema = (Cinema)_cinemaManager.Get(cinemaId),
                Hall = (Hall)_hallManager.Get(hallId),
                Film = (Film)_filmManager.Get(filmId),
                StartTime = seanceTime,
                EndTime = seanceTime.AddMinutes((int)((Film)_filmManager.Get(filmId)).Time)
            };

            Add(session);
        }
        public void Add(Entity entity)
        {
            Session[_sessionIndex] = (Session)entity;
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
            for (int i = 0; i < Session.Length; i++)
            {
                if (Session[i].Id == id)
                {
                    Session[i] = Session[i + 1];
                    _sessionIndex--;
                    return;
                }
            }
            Console.WriteLine("Bu ID de seans yoxdur!!");
        }

        public Entity[] GetAll()
        {
            return Session;
        }

        public Entity Get(int id)
        {
            for (int i = 0; i < Session.Length; i++)
            {
                if (Session[i] == null)
                    continue;

                if (Session[i].Id == id)
                    return Session[i];
            }
            Console.WriteLine("Seans tapilmadi");
            return null;
        }
        public void Update(int cinemaId, int hallId, int filmId, DateTime seanceTime, int sessionId)
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
                Cinema = (Cinema)_cinemaManager.Get(cinemaId),
                Hall = (Hall)_hallManager.Get(hallId),
                Film = (Film)_filmManager.Get(filmId),
                StartTime = seanceTime,
                EndTime = seanceTime.AddMinutes((int)((Film)_filmManager.Get(filmId)).Time)
            };

            Update(sessionId, seans);
        }
        public void Update(int id, Entity entity)
        {
            for (int i = 0; i < Session.Length; i++)
            {
                if (Session[i] == null)
                    continue;

                if (Session[i].Id == id)
                    Session[i] = (Session)entity;
            }
        }
        public void Print()
        {
            Console.WriteLine($"{"BUTUN SEANSLARIN SIYAHISI",-30}");
            Console.WriteLine("__________________________________________");

            foreach (var item in Session)
            {
                if (item == null)
                    continue;

                Console.WriteLine(item);
                Console.WriteLine("__________________________________________");
            }
        }
        public void Print(int sessionId)
        {
            Console.WriteLine($"{"SCILEN SEANS",-25}");
            Console.WriteLine("__________________________________________");

            Session session = (Session)Get(sessionId);

            Console.WriteLine(session);
            Console.WriteLine("__________________________________________");
            

        }
    }
}
