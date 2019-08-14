using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;

namespace LibraryApp.Models
{
    public class BookManager : DomainService, IBookManager
    {
        private readonly IRepository<Book> _repositoryBook;

        public BookManager(IRepository<Book> repositoryBook)
        {
            _repositoryBook = repositoryBook;
        }

        public IEnumerable<Book> GetAllList()
        {
            return _repositoryBook.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _repositoryBook.Get(id);
        }

        public async Task<Book> Create(Book entity)
        {
            var book = _repositoryBook.FirstOrDefault(x => x.Id == entity.Id);
            if (book != null)
                throw new UserFriendlyException("Already Exist");
            return await _repositoryBook.InsertAsync(entity);
        }

        public void Update(Book entity)
        {
            _repositoryBook.Update(entity);
        }

        public void Delete(int id)
        {
            var book = _repositoryBook.FirstOrDefault(x => x.Id == id);
            if (book == null)
                throw new UserFriendlyException("No Data Found");
            _repositoryBook.Delete(book);
        }
    }
}