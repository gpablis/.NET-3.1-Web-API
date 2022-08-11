using my_books2.Dtos.Book;
using my_books2.Models;
using System.Collections.Generic;

namespace my_books2.Services.BookService
{
    public interface IBookService
    {
        ServiceResponse<List<GetbBookDto>> GetAllBooks();
        ServiceResponse<GetbBookDto> GetBookById(int id);
        ServiceResponse<List<GetbBookDto>> AddBook(AddBookDto newBook);
        ServiceResponse<GetbBookDto> UpdateBook(UpdateBookDto updateBookDto);
        ServiceResponse<List<GetbBookDto>> DeleteBook(int id);
    }
}
