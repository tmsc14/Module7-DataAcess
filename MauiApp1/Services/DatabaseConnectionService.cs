using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public class DatabaseConnectionService
    {
        private readonly string _connectionString;
      
        public DatabaseConnectionService()
        {
            _connectionString = "Server=localhost;Database=testDB;User ID=TestUser;Password=admin";
        }

        public string GetConnectionString()
        {
            return 
                _connectionString;
        }
    }
}
