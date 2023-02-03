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
            Session session =(Session)_sessionManager.Get(sessionId);
            Console.WriteLine($"Bilet N-{_ticketId}");
            Console.WriteLine(session);
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < _sessionManager.Sessions.Length; i++)
            {
                if (_sessionManager.Sessions[i] == null)
                    continue;

                if (_sessionManager.Sessions[i].Id == sessionId)
                {
                    _sessionManager.Sessions[i].seats[row + 1, col + 1] = $"{"Full",-7}";
                    
                    for (int j = 0; j < session.Hall.Row+1; j++)
                    {
                        for (int k = 0; k < session.Hall.Col+1; k++)
                        {
                            Console.Write(_sessionManager.Sessions[i].seats[j, k]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\nBilet ugurla alindi");
                    Console.WriteLine("_____________________________________");
                    return;
                }
            }
            Console.WriteLine("Seans tapilmadi");
            Console.WriteLine("_____________________________________");


        }

        public void PrintTicket(int ticketId)
        {
            
        }
    }
}
