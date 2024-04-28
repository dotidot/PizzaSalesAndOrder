using AutoMapper;
using PizzaSalesAndOrder.Domains.Entities;
using PizzaSalesAndOrder.Dto.PizzaTypes;

namespace PizzaSalesAndOrder.Mapping;

public class PizzaTypeMappingConfiguraiton : Profile
{
    public PizzaTypeMappingConfiguraiton()
    {
        CreateMap<PizzaType, PizzaTypeDto>();
    }
}
