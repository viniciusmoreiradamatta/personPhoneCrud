using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> Add(PersonRequest person)
        {
            var Person = _mapper.Map<Person>(person);

            var newPerson = await _personService.Add(Person);

            var response = new PersonResponse();

            response.PersonObject = _mapper.Map<PersonDto>(newPerson);

            return response;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonListResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonResponse> FindById(int id)
        {
            var result = await _personService.FindById(id);
            var response = new PersonResponse();
            response.PersonObject = _mapper.Map<PersonDto>(result);

            return response;
        }

        public async Task<PersonResponse> Modify(PersonRequest person)
        {
            var Person = _mapper.Map<Person>(person);

            var personModified = await _personService.Modify(Person);

            var response = new PersonResponse();

            response.PersonObject = _mapper.Map<PersonDto>(personModified);

            return response;
        }

        public async Task<PersonResponse> Delete(int id)
        {
            var personDeleted = await _personService.Delete(id);

            var response = new PersonResponse();

            response.PersonObject = _mapper.Map<PersonDto>(personDeleted);

            return response;
        }
    }
}