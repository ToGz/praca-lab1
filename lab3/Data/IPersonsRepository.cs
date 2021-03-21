using lab3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab3.Data
{
    public interface IPersonsRepository
    {
        Task AddPersonAsync(Person person);
        Task EditPersonAsync(Person person);
        Task<Person> GetPersonAsync(Guid id);
        Task<List<Person>> ListPeopleAsync();
        bool PersonExists(Guid id);
        Task RemovePersonAsync(Guid id);
    }
}