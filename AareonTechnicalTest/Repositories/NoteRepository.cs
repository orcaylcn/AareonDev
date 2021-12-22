using System;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Repositories
{
    public class NoteRepository : EFEntityRepositoryBase<Note, int>, INoteRepository
    {
        private readonly ApplicationContext _dbContext;

        public NoteRepository(ApplicationContext context) : base(context)
        {
            _dbContext = context;
        }

        public override async Task Update(int id, Note entity)
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

            if (entity.TicketId != existingItem.TicketId)
            {
                anyChanges = true;
                existingItem.TicketId = entity.TicketId;
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