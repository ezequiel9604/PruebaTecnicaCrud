
using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Repositories
{
    public interface IClientRepository : IGenericRepository<ClientDTO>
    {

        Task<string> CreateAsync(ClientDTO obj);

        Task<string> DeleteAsync(int id);

        Task<string> UpdateAsync(ClientDTO obj);

    }
}
