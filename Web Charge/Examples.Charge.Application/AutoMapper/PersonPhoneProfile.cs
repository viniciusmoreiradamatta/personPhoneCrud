using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonPhoneProfile : Profile
    {
        public PersonPhoneProfile()
        {
            CreateMap<PersonPhone, PersonPhoneDto>()
                .ReverseMap()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.IdPerson))
                .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
                .ForMember(dest => dest.PhoneNumberType, opt => opt.MapFrom(src => src.PhoneNumberType));

            CreateMap<PersonPhone, PersonPhoneRequest>()
                .ReverseMap()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID));
        }
    }
}