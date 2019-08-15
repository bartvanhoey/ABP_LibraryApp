using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using LibraryApp.Books.Dtos;

namespace LibraryApp.Books
{
    public interface IBookAppService : IApplicationService
    {
        IEnumerable<GetBookOutput> ListAll();
        Task Create(CreateBookInput input);
        void Update(UpdateBookInput input);
        void Delete(DeleteBookInput input);
        GetBookOutput GetBookById(GetBookInput input);
    }
}