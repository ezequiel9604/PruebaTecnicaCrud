using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Repositories
{
    public interface IOrderDetailRepository : IGenericRepository<OrderDetailDTO>
    {

        Task<List<OrderDetailDTO>> GetAllByOrderNumber(string ordernumber);

        Task<List<OrderDetailDTO>> GetAllByProductId(int id);

        Task<string> CreateAsync(OrderDetailDTO obj);

        Task<string> DeleteAsync(int id);

        Task<string> UpdateAsync(OrderDetailDTO obj);

    }
}
