using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using AutoMapper;
using LibraryApp.Authors.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Authors
{
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAuthorManager _authorManager;

        public AuthorAppService(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }
        
        public IEnumerable<GetAuthorOutput> ListAll()
        {
            var authors = _authorManager.GetAllList();
            var output = Mapper.Map<IEnumerable<Author>, IEnumerable<GetAuthorOutput>>(authors);
            return output;
        }

        public async Task Create(CreateAuthorInput input)
        {
            var author = Mapper.Map<CreateAuthorInput, Author>(input);
            await _authorManager.Create(author);
        }

        public void Update(UpdateAuthorInput input)
        {
            var author = Mapper.Map<UpdateAuthorInput, Author>(input);
            _authorManager.Update(author);
        }

        public void Delete(DeleteAuthorInput input)
        {
           _authorManager.Delete(input.Id);
        }

        public GetAuthorOutput GetAuthorById(GetAuthorInput input)
        {
            var author = _authorManager.GetAuthorById(input.Id);
            var output = Mapper.Map<Author,GetAuthorOutput>(author);
            return output;
        }
    }
}