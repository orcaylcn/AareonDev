using AareonTechnicalTest.Models;
using AareonTechnicalTest.Repositories;

namespace AareonTechnicalTest.Services
{
    public class PersonService : BaseService<Person, int>, IPersonService
    {
        public PersonService(IPersonRepository personRepository) : base(personRepository)
        {
        }
    }
}
