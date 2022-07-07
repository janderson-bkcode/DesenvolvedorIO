namespace Database
{
    using System.Data;
    using System.Data.SqlClient;

    namespace Repository
    {
        public class Database
        {
            public SqlConnection GetConnection()
            {
                return GetConnection("user_read");
            }

            public SqlConnection GetConnection(string username)
            {
                return GetConnection(username, "Fornecedores");
            }

            public SqlConnection GetConnection(string username, string dataBase)
            {
                string connectionString = GetConnectionString(username, dataBase);
                SqlConnection result = null;
                try
                {
                    result = new SqlConnection(connectionString);
                    return result;
                }
                catch
                {
                    return result;
                }
            }

            public string GetConnectionString(string username, string dataBase)
            {
                return "user id=sa;password=" + GetPassword(username) + ";Network Address=dbdev.hysoft.com.br,1433; Persist Security Info=true; database=" + dataBase + "; connection timeout=300";
            }

            public string GetPassword(string username)
            {
                if (!(username == "janderson"))
                {
                    if (username == "user_system_hysoft")
                    {
                        return "Selecttop10*from";
                    }

                    return "Selecttop10*from";
                }

                return "Selecttop10*from";
            }

            public void Close(SqlConnection connection)
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    try
                    {
                        connection.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }
    }

}
