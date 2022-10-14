
using AutoMapper;
using PruebaTecnicaCrud.DTOs;
using PruebaTecnicaCrud.Models;

namespace PruebaTecnicaCrud.Mapper
{
    public class MappingConfig : Profile
    {

        public MappingConfig()
        {

            CreateMap<Client, ClientDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone))
                .ForMember(d => d.OrderDTOs, opt => opt.Ignore());

            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.Stock, opt => opt.MapFrom(s => s.Stock))
                .ForMember(d => d.OrderDetailDTOs, opt => opt.Ignore());

            CreateMap<Order, OrderDTO>()
                .ForMember(d => d.OrderNumber, opt => opt.MapFrom(s => s.OrderNumber))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Date))
                .ForMember(d => d.Total, opt => opt.MapFrom(s => s.Total))
                .ForMember(d => d.ClientId, opt => opt.MapFrom(s => s.ClientId))
                .ForMember(d => d.OrderDetailDTOs, opt => opt.Ignore());

            CreateMap<Administrator, AdministratorDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Nickname, opt => opt.MapFrom(s => s.Nickname))
                .ForMember(d => d.Password, opt => opt.Ignore());

            CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Amount, opt => opt.MapFrom(s => s.Amount))
                .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.ProductId))
                .ForMember(d => d.OrderNumber, opt => opt.MapFrom(s => s.OrderNumber));


        }


    }
}
