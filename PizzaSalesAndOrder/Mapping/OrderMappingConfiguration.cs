using AutoMapper;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.Orders;

namespace PizzaSalesAndOrder.Mapping;

public class OrderMappingConfiguration : Profile
{
    public OrderMappingConfiguration()
    {
        CreateMap<Order, OrderDto>();
    }
}
