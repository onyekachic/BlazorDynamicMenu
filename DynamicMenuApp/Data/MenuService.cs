using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DynamicMenuApp.Data
{
    public class MenuService
    {
        private readonly SqlConnectionConfiguration _sqlConnectionConfiguration;

        public MenuService(SqlConnectionConfiguration sqlConnectionConfiguration)
        {
            _sqlConnectionConfiguration = sqlConnectionConfiguration;
        }

        public async Task<IEnumerable<MenuInfo>> GetMenuData()
        {
            IEnumerable<MenuInfo> menuInfos;

            using (var conn = new SqlConnection(_sqlConnectionConfiguration.Value))
            {
                const string query = @"Select * From MenuInfo";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    menuInfos = await conn.QueryAsync<MenuInfo>(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }

            return menuInfos;
        }
    }
}
