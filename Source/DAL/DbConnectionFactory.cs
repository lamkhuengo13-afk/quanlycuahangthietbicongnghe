
using Microsoft.Data.SqlClient;

namespace QuanLyCuaHangThietBiCongNghe.DAL
{
    public static class DbConnectionFactory
    {
        private const string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyCuaHangThietBiCongNghe;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
