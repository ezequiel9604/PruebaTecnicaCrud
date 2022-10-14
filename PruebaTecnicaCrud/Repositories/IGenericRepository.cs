

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Repositories
{
    public interface IGenericRepository<T>
    {

        Task<List<T>> GetAllAsync();

    }
}
