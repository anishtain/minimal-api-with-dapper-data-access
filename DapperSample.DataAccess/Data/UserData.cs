using DapperSample.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSample.DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly IRepository repository;

        public UserData(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Models.User>> GetAll() =>
            await repository.LoadData<Models.User, dynamic>("UserSP_GetAll", new { }, "Default");

        public async Task<Models.User?> GetById(int id) =>
            (await repository.LoadData<Models.User, dynamic>("UserSP_Get", new { Id = id }, "Default")).FirstOrDefault();

        public async Task Insert(Models.User user) =>
            await repository.SaveData("UserSP_Create", new { user.FirstName, user.LastName }, "Default");

        public async Task Update(Models.User user) =>
            await repository.SaveData("UserSP_Update", user, "Default");

        public async Task Delete(int id) =>
            await repository.SaveData<dynamic>("UserSP_Delete", new { Id = id }, "Default");
    }
}
