using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberService;
        private readonly IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberService, IMapper mapper)
        {
            _phoneNumberService = phoneNumberService;
            _mapper = mapper;
        }

        public async Task<PhoneNumberTypeResponse> FindAllAsync()
        {
            var numberType = await _phoneNumberService.FindAllAsync();

            var response = new PhoneNumberTypeResponse();

            response.PhoneNumberType = numberType.Select(c => _mapper.Map<PhoneNumberTypeDto>(c)).ToList();

            return response;
        }
    }
}