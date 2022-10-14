
using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductDTO>
    {
        Task<string> CreateAsync(ProductDTO obj);

        Task<string> DeleteAsync(int id);

        Task<string> UpdateAsync(ProductDTO obj);
    }
}
