﻿using CinemaConsoleApp.Models;
using CinemaConsoleApp.Services.Contacts;
using System;


namespace CinemaConsoleApp.Services
{
    internal class TicketmManager
    {
        private int _ticketId = 0;
        private SessionManager _sessionManager;

        internal TicketmManager(SessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        public void BuyTicket(int sessionId, int row, int col)
        {
            Ticket ticket = new Ticket();
            
            Session session = (Session)_sessionManager.Get(sessionId);
            
            for (int i = 0; i < _sessionManager.Sessions.Length; i++)
            {
                if (_sessionManager.Sessions[i] == null)
                    continue;

                if (_sessionManager.Sessions[i].Id == sessionId)
                {
                    if (_sessionManager.Sessions[i].seats[row, col] == $"{"Full",-7}")
                    {
                        Console.WriteLine($"Bu seansda {row} sira {col} yer artiq alinmisdir");
                        return;
                    }
                    Console.WriteLine($"Bilet N-{_ticketId}");
                    Console.WriteLine(session);
                    Console.WriteLine("---------------------------------");
                    _sessionManager.Sessions[i].seats[row, col] = $"{"Full",-7}";
                    _ticketId++;
                    ticket.Id = _ticketId;

                    for (int j = 0; j < session.Hall.Row + 1; j++)
                    {
                        for (int k = 0; k < session.Hall.Col + 1; k++)
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
    }
}
