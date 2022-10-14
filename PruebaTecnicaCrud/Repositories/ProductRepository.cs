
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCrud.DataContext;
using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;

namespace PruebaTecnicaCrud.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private IMapper _mapper;
        private PruebaTecnicaCrudDbContext _dbContext;
        private IOrderDetailRepository _orderDetailRepository;

        public ProductRepository(PruebaTecnicaCrudDbContext dbContext,
            IOrderDetailRepository orderDetailRepository,
            IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        // done
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            try
            {

                var products = await _dbContext.Products.ToListAsync();

                if (products == null)
                    return new List<ProductDTO>();

                var dtos = new List<ProductDTO>();

                foreach (var item in products)
                {

                    var productDto = _mapper.Map<ProductDTO>(item);

                    productDto.OrderDetailDTOs = await _orderDetailRepository.GetAllByProductId(item.Id);

                    dtos.Add(productDto);

                }

                return dtos;

            }
            catch (Exception)
            {
                return new List<ProductDTO>();
            }
        }

        // done
        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            try
            {

                var product = await _dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (product == null)
                    return new ProductDTO();

                var dto = _mapper.Map<ProductDTO>(product);

                dto.OrderDetailDTOs = await _orderDetailRepository.GetAllByProductId(product.Id);

                return dto;

            }
            catch (Exception)
            {
                return new ProductDTO();
            }
        }

        // done
        public async Task<string> DeleteAsync(int id)
        {
            try
            {

                var product = await _dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (product == null)
                    return "No exists";

                _dbContext.Products.Remove(product);

                await _dbContext.SaveChangesAsync();

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        public Task<string> CreateAsync(ProductDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateAsync(ProductDTO obj)
        {
            throw new System.NotImplementedException();
        }

    }
}
