using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            return await _personService.GetAll();
        }

        [HttpGet("{id}")]
        public Task<Person> Get(int id)
        {
            return _personService.Get(id);
        }

        [HttpPost]
        public async Task Post(Person person)
        {
            await _personService.Add(person);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, Person person)
        {
            await _personService.Update(id, person);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _personService.Delete(id);
        }
    }
}
