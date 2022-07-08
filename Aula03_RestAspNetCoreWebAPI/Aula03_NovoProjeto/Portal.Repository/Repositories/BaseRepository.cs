using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Fornecedores.Interface;
using Portal.Repository.DbConnect;

namespace Portal.Repository.Repositories
{
    public class BaseRepository
    {
        public IDbConnection _connection;

        public readonly IUsernameLogRepository _usernameLogRepository;

        public BaseRepository(IUsernameLogRepository usernameLogRepository)
        {
            _usernameLogRepository = usernameLogRepository;

            InitializeDatabase();
        }

        public BaseRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _connection = new Database().GetConnection("user_gestao", "PAYMENT");
        }

        public void OpenIfClosed()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public bool IsConnectionOpen()
        {
            return _connection != null && _connection.State == System.Data.ConnectionState.Open;
        }

        public void CloseConnection()
        {
            try
            {
                if (IsConnectionOpen())
                {
                    _connection.Close();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
