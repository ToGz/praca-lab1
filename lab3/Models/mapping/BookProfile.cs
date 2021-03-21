using AutoMapper;
using lab3.Models.dto;

namespace lab3.Models.mapping
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<BookAddDto, Book>();
        }
    }
}
