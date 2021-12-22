using AareonTechnicalTest.Models;
using AareonTechnicalTest.Repositories;

namespace AareonTechnicalTest.Services
{
    public class TicketService : BaseService<Ticket, int>, ITicketService
    {
        public TicketService(ITicketRepository ticketRepository) : base(ticketRepository)
        {
        }
    }
}
