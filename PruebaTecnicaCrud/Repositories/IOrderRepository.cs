
using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Repositories
{
    public interface IOrderRepository : IGenericRepository<OrderDTO>
    {

        Task<List<OrderDTO>> GetAllByClientId(int id);

        Task<string> CreateAsync(OrderDTO obj);

        Task<string> DeleteAsync(string ordernumber);

        Task<string> UpdateAsync(OrderDTO obj);

    }
}
