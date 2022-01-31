using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> FindById(int id) => await _personRepository.FindById(id);

        public async Task<Person> Add(Person person)
        {
            return await _personRepository.Add(person);
        }

        public async Task<Person> Modify(Person newPerson)
        {
            var oldPerson = await _personRepository.FindById(newPerson.BusinessEntityID);

            oldPerson.Name = newPerson.Name;

            var oldPhones = oldPerson.Phones.Where(c => !newPerson.Phones.Select(cc => cc.PhoneNumber).Contains(c.PhoneNumber));

            var newPhones = newPerson.Phones.Where(c => !oldPerson.Phones.Select(cc => cc.PhoneNumber).Contains(c.PhoneNumber));

            oldPhones.ToList().ForEach(i => oldPerson.Phones.Remove(i));

            newPhones.ToList().ForEach(i => oldPerson.Phones.Add(i));

            return await _personRepository.Modify(oldPerson);
        }

        public async Task<Person> Delete(int id)
        {
            var oldPerson = await _personRepository.FindById(id);

            return await _personRepository.Delete(oldPerson);
        }
    }
}