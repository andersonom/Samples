using System;
using System.Collections.Generic;
using Train.TicketServices.Entities;
using Train.TicketServices.Interfaces.Repositories;
using Train.TicketServices.Repositories;
using Train.TicketServices.Interfaces.Services;

namespace Train.TicketServices.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        public TicketService()
        {
            _repository = new TicketRepository();
        } 

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> GetStations()
        {
            return _repository.GetStations();
        }      

        public Ticket GetStations(string input)
        {
            List<string> digits = new List<string>();
            List<string> words = new List<string>();

            if (!String.IsNullOrEmpty(input))
            {
                var source = GetStations();

                foreach (var item in source)
                {
                    if (item.StartsWith(input))
                    {
                        words.Add(item);

                        if (input.Length < item.Length)
                        {
                            var digit = item.Substring(input.Length, 1);
                            if (!digits.Contains(digit))
                                digits.Add(digit);
                        }                        
                    }
                }
            }
            return new Ticket() { CharsAvailablesToTypeStation =  digits, StationNames = words };
        }
    }
}
