using CinemaConsoleApp.Models;
using CinemaConsoleApp.Services.Contacts;
using System;


namespace CinemaConsoleApp.Services
{
    internal class TicketmManager
    {
        private int _ticketId = 0;

        private SessionManager _sessionManager;
        private HallManager _hallManager;
        private CinemaManager _cinemaManager;
        
        internal TicketmManager(SessionManager sessionManager, HallManager hallManager, CinemaManager cinemaManager)
        {
            _cinemaManager = cinemaManager;
            _sessionManager = sessionManager;
            _hallManager = hallManager;
        }
        public void BuyTicket(int sessionId, int row, int col)
        {
            _ticketId++;
            Ticket ticket = new Ticket();
            ticket.Id = _ticketId;
            Session session=(Session)_sessionManager.Get(sessionId);
            int hallId = session.Hall.Id;

            for (int i = 0; i < _cinemaManager.Cinemas.Length; i++)
            {
                for (int j = 0; j < _cinemaManager.Cinemas[i].Hall.Length; j++)
                {
                    if (_cinemaManager.Cinemas[i].Hall[j].Id == session.Hall.Id)
                    {
                        _cinemaManager.Cinemas[i].Hall[j].seats[row + 1, col + 1] = $"{"Full",-7}";
                        break;
                    }

                }
                break;
            }
            
           Hall hall = (Hall)_hallManager.Get(hallId);

            for (int i = 0; i < hall.seats.GetLength(0); i++)
            {
                for (int j = 0; j < hall.seats.GetLength(1); j++)
                {
                    Console.Write(hall.seats[i, j]);
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("Bilet ugurla alindi");
            Console.WriteLine("_____________________________________");
        }

        public void Print(int id)
        {
            Session session = (Session)_sessionManager.Get(id);
            Console.WriteLine(session);
        }
    }
}
