using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> FindAllAsync();

        Task<Person> FindById(int id);

        Task<Person> Add(Person person);

        Task<Person> Modify(Person person);

        Task<Person> Delete(Person person);
    }
}