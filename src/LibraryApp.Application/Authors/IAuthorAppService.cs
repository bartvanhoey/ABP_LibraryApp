using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryApp.Authors.Dtos;

namespace LibraryApp.Authors
{
    public interface IAuthorAppService : IApplicationService
    {
        IEnumerable<GetAuthorOutput> ListAll();
        Task Create(CreateAuthorInput input);
        void Update(UpdateAuthorInput input);
        void Delete(DeleteAuthorInput input);
        GetAuthorOutput GetAuthorById(GetAuthorInput input);
    }
}