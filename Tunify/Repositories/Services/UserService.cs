using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Interfaces;

namespace Tunify.Repositories.Services
{
    public class UserService : IUsers
    {
        private readonly TunifyDbContext _context;

        public UserService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User User)
        {
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return User;
        }

        public async Task DeleteUser(int id)
        {
            var getUser = await GetUserById(id);
            _context.Entry(getUser).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetUserById(int UserID)
        {
            var User = await _context.Users.FindAsync(UserID);
            return User;
        }

        public async Task<User> UpdateUser(int id, User User)
        {
            var exsitingUser = await _context.Users.FindAsync(id);
            exsitingUser = User;
            await _context.SaveChangesAsync();

            return User;
        }
    }
}
