using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Train.TicketServices.Entities
{
    public class Ticket
    {
            public IEnumerable<string> CharsAvailablesToTypeStation { get; set; }
            public IEnumerable<string> StationNames { get; set; }        
    }
}
