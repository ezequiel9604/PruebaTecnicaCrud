
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCrud.DataContext;
using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {

        private IMapper _mapper;
        private PruebaTecnicaCrudDbContext _dbContext;

        public OrderDetailRepository(PruebaTecnicaCrudDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        // done
        public async Task<List<OrderDetailDTO>> GetAllAsync()
        {
            try
            {

                var ordersDetails = await _dbContext.OrderDetails.ToListAsync();

                if (ordersDetails == null)
                    return new List<OrderDetailDTO>();

                var dtos = new List<OrderDetailDTO>();

                foreach (var item in ordersDetails)
                {

                    var orderDto = _mapper.Map<OrderDetailDTO>(item);

                    dtos.Add(orderDto);

                }

                return dtos;

            }
            catch (Exception)
            {
                return new List<OrderDetailDTO>();
            }
        }

        // done
        public async Task<OrderDetailDTO> GetByIdAsync(int id)
        {
            try
            {

                var orderDetail = await _dbContext.OrderDetails.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (orderDetail == null)
                    return new OrderDetailDTO();

                var dto = _mapper.Map<OrderDetailDTO>(orderDetail);

                return dto;

            }
            catch (Exception)
            {
                return new OrderDetailDTO();
            }
        }

        // done
        public async Task<List<OrderDetailDTO>> GetAllByOrderNumber(string ordernumber)
        {
            try
            {

                var orderDetail = await _dbContext.OrderDetails.Where(x => x.OrderNumber == ordernumber).ToListAsync();

                if (orderDetail == null)
                    return new List<OrderDetailDTO>();

                
                var dtos = _mapper.Map<List<OrderDetailDTO>>(orderDetail);

                return dtos;

            }
            catch (Exception)
            {
                return new List<OrderDetailDTO>();
            }
        }

        // done
        public async Task<List<OrderDetailDTO>> GetAllByProductId(int id)
        {
            try
            {

                var orderDetail = await _dbContext.OrderDetails.Where(x => x.ProductId == id).ToListAsync();

                if (orderDetail == null)
                    return new List<OrderDetailDTO>();


                var dtos = _mapper.Map<List<OrderDetailDTO>>(orderDetail);

                return dtos;

            }
            catch (Exception)
            {
                return new List<OrderDetailDTO>();
            }
        }

        public Task<string> CreateAsync(OrderDetailDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateAsync(OrderDetailDTO obj)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
