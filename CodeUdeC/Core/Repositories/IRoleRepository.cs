using CodeUdeC.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace CodeUdeC.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
