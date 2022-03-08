using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MVC_CRUD.Helpers
{
    public class DBHelper : IDisposable
    {
        public SqlConnection SqlConn = null;
        private const string CONNECTION_STRING = @"server=GERRY-APP-DEV\SQLEXPRESS; user=sa; password=gerry123; database=TICKETING; Trusted_Connection=True";

        public void Dispose()
        {
            
        }

        public async Task<bool> Execute(string sql, 
            DynamicParameters parameters)
        {
            try
            {
                using SqlConnection connection = new(CONNECTION_STRING);
                await connection.ExecuteAsync(sql, 
                    parameters, 
                    commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DBHelper ERROR: {ex.Message}");
            }
            return false;
        }

        public async Task<List<T>> LoadData<T>(string sql, DynamicParameters parameters)
        {
            try
            {
                using SqlConnection connection = new(CONNECTION_STRING);
                var data = await connection.QueryAsync<T>(sql,
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return data.AsList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DBHelper ERROR: {ex.Message}");
            }
            return new(new List<T>());
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(CONNECTION_STRING);
        }
    }
}
