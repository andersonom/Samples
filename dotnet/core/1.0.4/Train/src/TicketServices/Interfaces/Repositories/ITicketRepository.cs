using System.Collections.Generic; 

namespace Train.TicketServices.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        IEnumerable<string> GetStations();
    }
}
