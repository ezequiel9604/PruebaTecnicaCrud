
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnicaCrud.Models;
using PruebaTecnicaCrud.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PruebaTecnicaCrud.DTOs;

namespace PruebaTecnicaCrud.Repositories
{
    public class ClientRepository : IClientRepository
    {

        private IMapper _mapper;
        private PruebaTecnicaCrudDbContext _dbContext;
        private IOrderRepository _orderRepository;

        public ClientRepository(PruebaTecnicaCrudDbContext dbContext, 
            IOrderRepository orderRepository,
            IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        // done
        public async Task<List<ClientDTO>> GetAllAsync()
        {

            try
            {

                var clients = await _dbContext.Clients.ToListAsync();

                if(clients == null)
                    return new List<ClientDTO>();


                var dtos = new List<ClientDTO>();

                foreach (var item in clients)
                {

                    var clientDto = _mapper.Map<ClientDTO>(item);

                    clientDto.OrderDTOs = await _orderRepository.GetAllByClientId(item.Id);

                    dtos.Add(clientDto);

                }
               
                return dtos;

            }
            catch (Exception)
            {
                return new List<ClientDTO>();
            }

        }

        // done
        public async Task<ClientDTO> GetByIdAsync(int id)
        {
            try
            {

                var client = await _dbContext.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (client == null)
                    return new ClientDTO();

                var dto = _mapper.Map<ClientDTO>(client);

                dto.OrderDTOs = await _orderRepository.GetAllByClientId(client.Id);

                return dto;

            }
            catch (Exception)
            {
                return new ClientDTO();
            }
        }

        // done
        public async Task<string> DeleteAsync(int id)
        {
            try
            {

                var client = await _dbContext.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (client == null)
                    return "No exists";

                _dbContext.Clients.Remove(client);

                await _dbContext.SaveChangesAsync();

                return "Success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }


        public Task<string> CreateAsync(ClientDTO obj)
        {

            throw new System.NotImplementedException();

        }

        public Task<string> UpdateAsync(ClientDTO obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
