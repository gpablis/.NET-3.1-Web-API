using AutoMapper;
using my_books2.Data;
using my_books2.Dtos.Book;
using my_books2.Models;
using System.Collections.Generic;
using System.Linq;

namespace my_books2.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public BookService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _dataContext = context;
        }

        public ServiceResponse<List<GetbBookDto>> AddBook(AddBookDto newBook)
        {
            ServiceResponse<List<GetbBookDto>> response = new ServiceResponse<List<GetbBookDto>>();
            Book book = _mapper.Map<Book>(newBook);
            _dataContext.Books.Add(book);
            _dataContext.SaveChanges();

            response.Data = _dataContext.Books.Select(book => _mapper.Map<GetbBookDto>(book)).ToList();
            return response;
        }

        public ServiceResponse<List<GetbBookDto>> DeleteBook(int id)
        {
            ServiceResponse<List<GetbBookDto>> response = new ServiceResponse<List<GetbBookDto>>();
            Book book = _dataContext.Books.FirstOrDefault(book => book.Id == id);
            _dataContext.Books.Remove(book);
            _dataContext.SaveChanges();

            response.Data = _dataContext.Books.Select(book => _mapper.Map<GetbBookDto>(book)).ToList();
            return response;

        }

        public ServiceResponse<List<GetbBookDto>> GetAllBooks()
        {
            ServiceResponse<List<GetbBookDto>> response = new ServiceResponse<List<GetbBookDto>>();
            List<Book> dbBooks = _dataContext.Books.ToList();
            response.Data = dbBooks.Select( book => _mapper.Map<GetbBookDto>(book)).ToList();  
            return response;
        }

        public ServiceResponse<GetbBookDto> GetBookById(int id)
        {
            ServiceResponse<GetbBookDto> response = new ServiceResponse<GetbBookDto>();  
            Book dbBook = _dataContext.Books.FirstOrDefault( book => book.Id == id );
            response.Data = _mapper.Map<GetbBookDto>(dbBook);
            return response;
        }

        public ServiceResponse<GetbBookDto> UpdateBook(UpdateBookDto updateBookDto)
        {
            ServiceResponse<GetbBookDto> response = new ServiceResponse<GetbBookDto>();
            Book book = _dataContext.Books.FirstOrDefault( book => book.Id == updateBookDto.Id );
            book.Rate = updateBookDto.Rate;

            _dataContext.Books.Update(book);
            _dataContext.SaveChanges();
            response.Data = _mapper.Map<GetbBookDto>(book);
            
            return response;
        }


    }
}
