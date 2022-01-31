using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();

        Task<PersonAggregate.Person> FindById(int id);

        Task<Person> Add(Person person);

        Task<Person> Modify(Person newPerson);

        Task<Person> Delete(int id);
    }
}