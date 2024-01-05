using fiorello.business.Dto.AppUser;
using fiorello.entity.Entities.Identity;
using System.Threading.Tasks;

namespace fiorello.business.Abstract
{
    public interface IAppUserService
    {
        Task<AppUser> Login(string usernameOrEmail, string password);
        Task LogOutAsync();
        Task<AppUser> Registration(CreateAppUserDto model);
    }
}
