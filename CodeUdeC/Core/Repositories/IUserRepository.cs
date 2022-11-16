using CodeUdeC.Areas.Identity.Data;

namespace CodeUdeC.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<AppUser> GetUsers();

        AppUser GetUser(string id);

        AppUser UpdateUser(AppUser user);
    }
}
