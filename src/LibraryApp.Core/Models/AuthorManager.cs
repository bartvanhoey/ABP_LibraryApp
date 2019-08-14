using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;

namespace LibraryApp.Models
{
    public class AuthorManager : DomainService, IAuthorManager
    {
        private readonly IRepository<Author> _repositoryAuthor;

        public AuthorManager(IRepository<Author> repositoryAuthor)
        {
            _repositoryAuthor = repositoryAuthor;
        }
        
        public IEnumerable<Author> GetAllList()
        {
            return _repositoryAuthor.GetAllIncluding(x => x.Books);
        }

        public Author GetAuthorById(int id)
        {
            return _repositoryAuthor.Get(id);
        }

        public async Task<Author> Create(Author entity)
        {
            var author = _repositoryAuthor.FirstOrDefault(x => x.Id == entity.Id);
            if (author != null)
                throw new UserFriendlyException("Already Exist");
            return await _repositoryAuthor.InsertAsync(entity);
        }

        public void Update(Author entity)
        {
            _repositoryAuthor.Update(entity);
        }

        public void Delete(int id)
        {
            var author = _repositoryAuthor.FirstOrDefault(x => x.Id == id);
            if (author == null)
                throw new UserFriendlyException("No Data Found");
            _repositoryAuthor.Delete(author);
        }
    }
}