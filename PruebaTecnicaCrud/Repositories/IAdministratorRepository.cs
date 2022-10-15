
using PruebaTecnicaCrud.DTOs;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Repositories
{
    public interface IAdministratorRepository : IGenericRepository<AdministratorDTO>
    {

        Task<object> LoginAsync(string nickname, string password);

    }
}
