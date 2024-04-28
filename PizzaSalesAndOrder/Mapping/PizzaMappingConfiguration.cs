using AutoMapper;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.Pizzas;

namespace PizzaSalesAndOrder.Mapping;

public class PizzaMappingConfiguration : Profile
{
    public PizzaMappingConfiguration()
    {
        CreateMap<Pizza, PizzaDto>();
    }
}
