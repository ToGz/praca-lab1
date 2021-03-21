using AutoMapper;
using lab3.Data;
using lab3.Models;
using lab3.Models.dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IMapper _mapper;

        public PersonsController(IPersonsRepository personsRepository, IMapper mapper)
        {
            _personsRepository = personsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PersonDto>> ListPeopleAsync()
        {
            var res = await _personsRepository.ListPeopleAsync();
            return Ok(_mapper.Map<IEnumerable<PersonDto>>(res));
        }

        [HttpGet("~/api/{id}/Persons")]
        public async Task<ActionResult<PersonDto>> GetPersonAsync([FromRoute] Guid id)
        {
            var res = await _personsRepository.GetPersonAsync(id);

            if(res == null)
                return NotFound();
            

            return Ok(_mapper.Map<PersonDto>(res));
        }

        [HttpPost]
        public async Task<ActionResult> AddPersonAsync([FromBody] PersonAddDto person)
        {
            if(string.IsNullOrEmpty(person.Name) || string.IsNullOrEmpty(person.Surname))
                return BadRequest();
            
            await _personsRepository.AddPersonAsync(_mapper.Map<Person>(person));
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditPersonAsync([FromBody] PersonDto person)
        {
            if (string.IsNullOrEmpty(person.Name) || string.IsNullOrEmpty(person.Surname))        
                return BadRequest();       

            if (person.Id is not Guid id || !_personsRepository.PersonExists(id))
                return NotFound();         

            await _personsRepository.EditPersonAsync(_mapper.Map<Person>(person));
            return Ok();
        }

        [HttpDelete("~/api/{id}/Persons")]
        public async Task<ActionResult> RemovePersonAsync(Guid id)
        {
            if (!_personsRepository.PersonExists(id))
                return NotFound();

            await _personsRepository.RemovePersonAsync(id);
            return Ok();
        }
    }
}
