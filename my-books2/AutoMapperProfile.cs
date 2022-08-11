using AutoMapper;
using my_books2.Dtos.Book;
using my_books2.Models;

namespace my_books2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, GetbBookDto>();
            CreateMap<AddBookDto, Book>();

        }
    }
}
