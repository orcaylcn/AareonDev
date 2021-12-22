using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IEnumerable<Ticket>> Get()
        {
            return await _ticketService.GetAll();
        }

        [HttpGet("{id}")]
        public Task<Ticket> Get(int id)
        {
            return _ticketService.Get(id);
        }

        [HttpPost]
        public async Task Post(Ticket ticket)
        {
            await _ticketService.Add(ticket);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, Ticket ticket)
        {
            await _ticketService.Update(id, ticket);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ticketService.Delete(id);
        }
    }
}
