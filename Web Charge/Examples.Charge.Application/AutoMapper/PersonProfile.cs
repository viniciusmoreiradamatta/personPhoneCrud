using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
               .ReverseMap()
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PersonDto, Person>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones));

            CreateMap<Person, PersonRequest>()
               .ReverseMap()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.Id));
        }
    }
}