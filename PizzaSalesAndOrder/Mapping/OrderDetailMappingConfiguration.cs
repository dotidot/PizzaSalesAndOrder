using AutoMapper;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.OrderDetails;

namespace PizzaSalesAndOrder.Mapping;

public class OrderDetailMappingConfiguration : Profile
{
    public OrderDetailMappingConfiguration()
    {
        CreateMap<OrderDetail, OrderDetailDto>();
    }
}
