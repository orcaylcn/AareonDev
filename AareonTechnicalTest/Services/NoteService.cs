using System;
using System.Threading.Tasks;
using AareonTechnicalTest.Exceptions;
using AareonTechnicalTest.Models;
using AareonTechnicalTest.Repositories;

namespace AareonTechnicalTest.Services
{
    public class NoteService : BaseService<Note, int>, INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IPersonService _personService;

        public NoteService(INoteRepository noteRepository,
            IPersonService personService)
                : base(noteRepository)
        {
            _noteRepository = noteRepository;
            _personService = personService;
        }



        public async Task Delete(int id, int personId)
        {
            var note = await Get(id);
            if (note == null)
            {
                throw new ArgumentException("Invalid id: " + id);
            }

            if (note.Id != personId)
            {
                var person = await _personService.Get(personId);
                if (!person.IsAdmin)
                {
                    throw new InvalidUserException("This user cannot delete the note");
                }
            }

            await _noteRepository.Delete(id);
        }
    }
}
