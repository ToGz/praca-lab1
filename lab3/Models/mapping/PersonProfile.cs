using AutoMapper;
using lab3.Models.dto;

namespace lab3.Models.mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDto, Person>().ReverseMap();
            CreateMap<PersonAddDto, Person>();
        }
    }
}
