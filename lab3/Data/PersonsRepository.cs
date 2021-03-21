using lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3.Data
{
    public class PersonsRepository : IPersonsRepository
    {
        public readonly ApplicationDbContext _dbcontext;
        public PersonsRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public Task<List<Person>> ListPeopleAsync()
        {
            return _dbcontext.Persons.ToListAsync();
        }

        public Task<Person> GetPersonAsync(Guid id)
        {
            return _dbcontext.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddPersonAsync(Person person)
        {
            await _dbcontext.Persons.AddAsync(person);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task EditPersonAsync(Person person)
        {
            _dbcontext.Entry(person).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task RemovePersonAsync(Guid id)
        {
            var person = await _dbcontext.Persons.FirstOrDefaultAsync(p => p.Id == id);
            _dbcontext.Remove(person);
            await _dbcontext.SaveChangesAsync();
        }
        public bool PersonExists(Guid id)
        {
            return _dbcontext.Persons.Any(e => e.Id == id);
        }
    }
}
