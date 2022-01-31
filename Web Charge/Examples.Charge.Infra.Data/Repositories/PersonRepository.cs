using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() => await Task.Run(() => _context.Person);

        public async Task<Person> FindById(int id) =>
            await _context.Person.Include(c => c.Phones).ThenInclude(c => c.PhoneNumberType).FirstOrDefaultAsync(c => c.BusinessEntityID == id);

        public async Task<Person> Add(Person person)
        {
            await _context.Person.AddAsync(person);

            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<Person> Modify(Person person)
        {
            _context.Person.Update(person);

            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<Person> Delete(Person person)
        {
            _context.Person.Remove(person);

            await _context.SaveChangesAsync();

            return person;
        }
    }
}