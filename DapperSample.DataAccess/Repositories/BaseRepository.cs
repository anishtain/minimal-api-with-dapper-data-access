using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSample.DataAccess.Repositories
{
    public class BaseRepository : IRepository
    {
        private readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure,
                                                        U parameters,
                                                        string connectionId)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure,
                                      T parameters,
                                      string connectionId)
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            await dbConnection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
