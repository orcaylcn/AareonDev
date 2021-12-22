using System;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Repositories
{
    public class PersonRepository : EFEntityRepositoryBase<Person, int>, IPersonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PersonRepository(ApplicationContext context) : base(context)
        {
            _dbContext = context;
        }

        public override async Task Update(int id, Person entity)
        {
            var existingItem = await Get(id);
            if (existingItem == null)
            {
                throw new ArgumentException("Invalid id: " + id);
            }

            var anyChanges = false;
            if (entity.Forename != existingItem.Forename)
            {
                anyChanges = true;
                existingItem.Forename = entity.Forename;
            }

            if (entity.Surname != existingItem.Surname)
            {
                anyChanges = true;
                existingItem.Surname = entity.Surname;
            }

            if (entity.IsAdmin != existingItem.IsAdmin)
            {
                anyChanges = true;
                existingItem.IsAdmin = entity.IsAdmin;
            }

            if (!anyChanges)
            {
                throw new ArgumentException("No changes for update");
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}