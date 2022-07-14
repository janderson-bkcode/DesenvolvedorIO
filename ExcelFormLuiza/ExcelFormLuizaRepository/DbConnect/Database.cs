using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelFormLuizaRepository.DbConnect
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;

    namespace Portal.Repository.DbConnect
    {
        public class Database
        {
            public SqlConnection GetConnection()
            {
                return GetConnection("user_read");
            }

            public SqlConnection GetConnection(string username)
            {
                return GetConnection(username, "NomeBanco");
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
                if (!(username == "sa"))
                {
                    if (username == "sa")
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
                        return;
                    }
                }
            }
        }
    }

}
