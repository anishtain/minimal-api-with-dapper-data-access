using DapperSample.DataAccess.Models;

namespace DapperSample.DataAccess.Data
{
    public interface IUserData
    {
        Task Delete(int id);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task Insert(User user);
        Task Update(User user);
    }
}