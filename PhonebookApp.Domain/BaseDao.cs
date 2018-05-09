using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PhonebookApp.Domain
{
    public class BaseDao
    {
        private string _ConnectionString = "Data Source=ether-ПК;Initial Catalog=testbase;Integrated Security=True";

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_ConnectionString))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    return await getData(connection).ConfigureAwait(false);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() тайм-аут операции SQL вышел", GetType().FullName), ex);
            }
            catch (SqlException ex)
            {
                throw new Exception(String.Format("{0}.WithConnection() ", GetType().FullName), ex);
            }
        }
    }
}
