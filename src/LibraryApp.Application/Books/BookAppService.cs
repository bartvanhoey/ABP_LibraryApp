using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using LibraryApp.Books.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Books
{
    public class BookAppService : ApplicationService, IBookAppService
    {
        private readonly IBookManager _bookManager;

        public BookAppService(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        public IEnumerable<GetBookOutput> ListAll()
        {
            var books = _bookManager.GetAllList();
            var output = Mapper.Map<IEnumerable<Book>, IEnumerable<GetBookOutput>>(books);
            return output;
        }

        public async Task Create(CreateBookInput input)
        {
            var book = Mapper.Map<CreateBookInput, Book>(input);
            await _bookManager.Create(book);
        }

        public void Update(UpdateBookInput input)
        {
            var book = Mapper.Map<UpdateBookInput, Book>(input);
            _bookManager.Update(book);
        }

        public void Delete(DeleteBookInput input)
        {
            _bookManager.Delete(input.Id);
        }

        public GetBookOutput GetBookById(GetBookInput input)
        {
            var book = _bookManager.GetBookById(input.Id);
            var output = Mapper.Map<Book, GetBookOutput>(book);
            return output;
        }
    }
}