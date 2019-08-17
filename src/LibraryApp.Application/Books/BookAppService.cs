using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.ObjectMapping;
using LibraryApp.Books.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Books
{
    public class BookAppService : ApplicationService, IBookAppService
    {
        private readonly IBookManager _bookManager;
        private readonly IObjectMapper _mapper;

        public BookAppService(IBookManager bookManager, IObjectMapper mapper)
        {
            _bookManager = bookManager;
            _mapper = mapper;
        }

        public IEnumerable<GetBookOutput> ListAll()
        {
            var books = _bookManager.GetAllList();
            var output = _mapper.Map<IEnumerable<GetBookOutput>>(books);
            return output;
        }

        public async Task Create(CreateBookInput input)
        {
            var book = _mapper.Map<Book>(input);
            await _bookManager.Create(book);
        }

        public void Update(UpdateBookInput input)
        {
            var book = _mapper.Map<Book>(input);
            _bookManager.Update(book);
        }

        public void Delete(DeleteBookInput input)
        {
            _bookManager.Delete(input.Id);
        }

        public GetBookOutput GetBookById(GetBookInput input)
        {
            var book = _bookManager.GetBookById(input.Id);
            var output = _mapper.Map<GetBookOutput>(book);
            return output;
        }
    }
}