
namespace DapperSample.DataAccess.Repositories
{
    public interface IRepository
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId);
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId);
    }
}