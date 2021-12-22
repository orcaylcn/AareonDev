using System.Threading.Tasks;
using AareonTechnicalTest.Models;

namespace AareonTechnicalTest.Services
{
    public interface INoteService : IBaseService<Note, int>
    {
        Task Delete(int id, int personId);
    }
}
