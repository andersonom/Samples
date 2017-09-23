using Train.TicketServices.Services; 
using Xunit;
using Train.TicketServices.Repositories;

namespace Train.TicketServices.Tests
{
    public class TicketServices_IsStationShould
    {
        private readonly TicketService _ticketService;
        public TicketServices_IsStationShould()
        {
            _ticketService = new TicketService(new TicketMockedRepository());
        }

        [Fact]
        public void ReturnGivenValueOfDART()
        {
            var result = _ticketService.GetStations("DART"); 

            Assert.Equal(result.CharsAvailablesToTypeStation,  new string[] { "F", "M" });
            Assert.Equal(result.StationNames, new string[] { "DARTFORD", "DARTMOUTH" });
        }

        [Fact]
        public void ReturnGivenValueOfLIVERPOOL()
        {
            var result = _ticketService.GetStations("LIVERPOOL");

            Assert.Equal(result.CharsAvailablesToTypeStation, new string[] { " " } );
            Assert.Equal(result.StationNames, new string[] { "LIVERPOOL", "LIVERPOOL LIME STREET" });
        }

        [Fact]
        public void ReturnGivenValueOfKINGS_CROSS()
        {
            var result = _ticketService.GetStations("KINGS CROSS");

            Assert.Equal(result.CharsAvailablesToTypeStation, new string[] { });
            Assert.Equal(result.StationNames, new string[] { });
        }

    }
}
