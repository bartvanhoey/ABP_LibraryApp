using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LibraryApp.Roles.Dto;
using LibraryApp.Users.Dto;

namespace LibraryApp.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
