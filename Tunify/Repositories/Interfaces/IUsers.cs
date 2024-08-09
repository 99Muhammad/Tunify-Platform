using Tunify.Model;

namespace Tunify.Repositories.Interfaces
{
    public interface IUsers
    {
        Task<User> CreateUser(User User);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int UserID);

        Task<User> UpdateUser(int id, User User);
        Task DeleteUser(int id);
    }
}
