using System;
using System.Collections.Generic; 
using Train.TicketServices.Interfaces.Repositories;

namespace Train.TicketServices.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public IEnumerable<string> GetStations()
        {
            throw new NotImplementedException("No Database implemented yet!");
        }
    }
}
