using CodeUdeC.Areas.Identity.Data;
using CodeUdeC.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace CodeUdeC.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;
        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
