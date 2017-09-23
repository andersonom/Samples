using System.Collections.Generic; 
using Train.TicketServices.Interfaces.Repositories;

namespace Train.TicketServices.Repositories
{
    public class TicketMockedRepository : ITicketRepository
    {
        public IEnumerable<string> GetStations()
        {
            return new List<string> { "DARTFORD", "DARTMOUTH", "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON", "EUSTON", "LONDON BRIDGE", "VICTORIA" };
        }
    }
}
