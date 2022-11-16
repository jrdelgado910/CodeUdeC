using CodeUdeC.Areas.Identity.Data;
using CodeUdeC.Core.Repositories;

namespace CodeUdeC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        //list users
        public ICollection<AppUser> GetUsers()
        {
            return _context.Users.ToList();
            
        }

        //update users from database
        public AppUser UpdateUser(AppUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
