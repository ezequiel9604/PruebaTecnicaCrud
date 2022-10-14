using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCrud.DataContext;
using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PruebaTecnicaCrud.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private IMapper _mapper;
        private PruebaTecnicaCrudDbContext _dbContext;
        private IOrderDetailRepository _orderDetailRepository;

        public OrderRepository(PruebaTecnicaCrudDbContext dbContext, 
            IOrderDetailRepository orderDetailRepository,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        // done
        public async Task<List<OrderDTO>> GetAllAsync()
        {
            try
            {

                var orders = await _dbContext.Orders.ToListAsync();

                if (orders == null)
                    return new List<OrderDTO>();

                var dtos = new List<OrderDTO>();

                foreach (var item in orders)
                {

                    var orderDto = _mapper.Map<OrderDTO>(item);

                    orderDto.OrderDetailDTOs = await _orderDetailRepository.GetAllByOrderNumber(item.OrderNumber);

                    dtos.Add(orderDto);

                }

                return dtos; 

            }
            catch (Exception)
            {
                return new List<OrderDTO>();
            }
        }

        // done
        public async Task<OrderDTO> GetByOrderNumberAsync(string ordernumber)
        {
            try
            {

                var order = await _dbContext.Orders.Where(x => x.OrderNumber == ordernumber).FirstOrDefaultAsync();

                if (order == null)
                    return new OrderDTO();

                var dto = _mapper.Map<OrderDTO>(order);

                dto.OrderDetailDTOs = await _orderDetailRepository.GetAllByOrderNumber(order.OrderNumber);

                return dto;

            }
            catch (Exception)
            {
                return new OrderDTO();
            }
        }

        // done
        public async Task<string> DeleteAsync(string ordernumber)
        {
            try
            {

                var order = await _dbContext.Orders.Where(x => x.OrderNumber == ordernumber).FirstOrDefaultAsync();

                if (order == null)
                    return "No exists";

                _dbContext.Orders.Remove(order);

                await _dbContext.SaveChangesAsync();

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }

        // done
        public async Task<List<OrderDTO>> GetAllByClientId(int clientId)
        {
            try
            {

                var orders = await _dbContext.Orders.Where(x => x.ClientId == clientId).ToListAsync();

                if (orders == null)
                    return new List<OrderDTO>();


                var dtos = new List<OrderDTO>();

                foreach (var item in orders)
                {

                    var orderDto = _mapper.Map<OrderDTO>(item);

                    // clientDtos.OrderDTOs =

                    dtos.Add(orderDto);

                }

                return dtos;

            }
            catch (Exception)
            {
                return new List<OrderDTO>();
            }
        }


        public Task<string> CreateAsync(OrderDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateAsync(OrderDTO obj)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
