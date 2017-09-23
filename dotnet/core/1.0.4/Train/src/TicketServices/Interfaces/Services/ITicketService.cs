using System.Collections.Generic;
using Train.TicketServices.Entities;

namespace Train.TicketServices.Interfaces.Services
{
    public interface ITicketService
    {
        Ticket GetStations(string input);
        IEnumerable<string> GetStations();         
    }
}
