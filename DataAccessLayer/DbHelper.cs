using Microsoft.Data.SqlClient;

namespace Database
{
    public static class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=DESKTOP-FK56QQ3\\SQLEXPRESS;Initial Catalog=EPortal;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
