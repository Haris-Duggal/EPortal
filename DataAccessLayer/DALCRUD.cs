using System.Data;
using System.Text.Json;
using Entities;
using Microsoft.Data.SqlClient;

namespace Database
{
    public static class DALCRUD
    {
        public static async Task AddData(string procedureName, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(procedureName, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    await connection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Exception Occurred: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
        }

        public static async Task<DataTable> ReadSpecificDataTable(string procedureName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = DbHelper.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);
                        await connection.OpenAsync();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        await connection.CloseAsync();

                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Exception Occurred: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            return new DataTable();
        }
        
        public static async Task<string> ReadDataAsync(string procedureName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        await conn.OpenAsync();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        await conn.CloseAsync();

                        if (dt.Rows.Count > 0)
                        {
                            return DalCustomLogics.DataTableToJSONWithJSONNet(dt);
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
                return string.Empty;
            }
        }

        public static async Task<string> ReadDataAsync(string procedureName, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = DbHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(procedureName, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    await connection.OpenAsync();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    await connection.CloseAsync();

                    if (dt.Rows.Count > 0)
                    {
                        return DalCustomLogics.DataTableToJSONWithJSONNet(dt);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
                return string.Empty;
            }
        }

        public static async Task<List<T>> GetEntitiesFromReadDataAsync<T>(string procedureName)
        {
            string jsonData = await ReadDataAsync(procedureName);

            if (!string.IsNullOrEmpty(jsonData))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonData)!;
            }

            return new List<T>();
        }

        public static async Task<List<T>> GetEntitiesFromReadDataAsync<T>(string procedureName, SqlParameter[] sp)
        {
            string jsonData = await ReadDataAsync(procedureName, sp);

            if (!string.IsNullOrEmpty(jsonData))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonData)!;
            }

            return new List<T>();
        }

        public static async Task DeleteInfo(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(procedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parameters);
                    await cmd.ExecuteNonQueryAsync();
                }
                await con.CloseAsync();
            }
        }

        public static async Task UpdateInfo<T>(string procedureName, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(procedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameters);
                        await cmd.ExecuteNonQueryAsync();
                    }
                    await con.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
        }
    }
}
