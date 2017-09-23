using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Train.TicketServices.Interfaces.Services;
using Train.TicketServices.Entities;

namespace Train.TicketAPI.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
      private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        { 
            _ticketService = ticketService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _ticketService.GetStations();
        } 

        [HttpGet("{input}")]
        public Ticket  Get(string input)
        {
            return _ticketService.GetStations(input);                   
        }         
    }
}
