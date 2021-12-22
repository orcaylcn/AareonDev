using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Services;

namespace AareonTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> Get()
        {
            return await _noteService.GetAll();
        }

        [HttpGet("{id}")]
        public Task<Note> Get(int id)
        {
            return _noteService.Get(id);
        }

        [HttpPost]
        public async Task Post(Note note)
        {
            await _noteService.Add(note);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, Note note)
        {
            await _noteService.Update(id, note);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, [FromBody] int personId)
        {
            await _noteService.Delete(id, personId);
        }
    }
}
