using System;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Repositories
{
    public class TicketRepository : EFEntityRepositoryBase<Ticket, int>, ITicketRepository
    {
        private readonly ApplicationContext _dbContext;

        public TicketRepository(ApplicationContext context) : base(context)
        {
            _dbContext = context;
        }

        public override async Task Update(int id, Ticket entity)
        {
            var existingItem = await Get(id);
            if (existingItem == null)
            {
                throw new ArgumentException("Invalid id: " + id);
            }

            var anyChanges = false;
            if (entity.PersonId != existingItem.PersonId)
            {
                anyChanges = true;
                existingItem.PersonId = entity.PersonId;
            }

            if (entity.Content != existingItem.Content)
            {
                anyChanges = true;
                existingItem.Content = entity.Content;
            }

            if (!anyChanges)
            {
                throw new ArgumentException("No changes for update");
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}