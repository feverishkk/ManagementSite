using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyGameSite.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyGameSite.Services
{
    public class GenericService<T> : IGenericRepository<T> where T : class
    {
        private readonly IConfiguration _configuration; 

        public GenericService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection SqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("CommonDbConnection"));
        }

        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        public async Task<IEnumerable<T>> GetAll(string _tableName)
        {
            using(var conn = CreateConnection())
            {
                string sql = $"SELECT * FROM {_tableName}";
                return await conn.QueryAsync<T>(sql);
            }
        }

        public async Task<IEnumerable<T>> GetById(string _tableName, int id)
        {
            using(var conn = CreateConnection())
            {
                string sql = $"SELECT * FROM {_tableName} WHERE {_tableName}Id = {id}";
                return await conn.QueryAsync<T>(sql);
            }
        }


    }
}
