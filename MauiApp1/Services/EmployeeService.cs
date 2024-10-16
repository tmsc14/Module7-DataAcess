using MySql.Data.MySqlClient;
using MauiApp1.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace MauiApp1.Services
{
    public class EmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService()
        {
            var dbService = new DatabaseConnectionService(); // Assuming you have this from previous projects
            _connectionString = dbService.GetConnectionString();
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                var cmd = new MySqlCommand("SELECT * FROM tblEmployee", conn);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        employees.Add(new Employee
                        {
                            EmployeeID = reader.GetInt32("EmployeeID"),
                            Name = reader.GetString("Name"),
                            Address = reader.GetString("Address"),
                            Email = reader.GetString("Email"),
                            ContactNo = reader.GetString("ContactNo")
                        });
                    }
                }
            }

            return employees;
        }
    }
}
