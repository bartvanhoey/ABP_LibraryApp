using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.ObjectMapping;
using LibraryApp.Authors.Dtos;
using LibraryApp.Models;

namespace LibraryApp.Authors
{
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        private readonly IAuthorManager _authorManager;
        private readonly IObjectMapper _objectMapper;

        public AuthorAppService(IAuthorManager authorManager, IObjectMapper objectMapper)
        {
            _authorManager = authorManager;
            _objectMapper = objectMapper;
        }
        
        public IEnumerable<GetAuthorOutput> ListAll()
        {
            var authors = _authorManager.GetAllList();
            var output = _objectMapper.Map<IEnumerable<GetAuthorOutput>>(authors);
            return output;
        }

        public async Task Create(CreateAuthorInput input)
        {
            var author = _objectMapper.Map<Author>(input);
            await _authorManager.Create(author);
        }

        public void Update(UpdateAuthorInput input)
        {
            var author = _objectMapper.Map<Author>(input);
            _authorManager.Update(author);
        }

        public void Delete(DeleteAuthorInput input)
        {
           _authorManager.Delete(input.Id);
        }

        public GetAuthorOutput GetAuthorById(GetAuthorInput input)
        {
            var author = _authorManager.GetAuthorById(input.Id);
            var output = _objectMapper.Map<GetAuthorOutput>(author);
            return output;
        }
    }
}