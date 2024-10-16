using Module05_Exercise01.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Module05_Exercise01.Services
{
    public class DatabaseService
    {
        private string connectionString = "Server=localhost;Database=CompanyDB;Uid=root;Pwd=;";

        public async Task<ObservableCollection<Employee>> GetEmployeesAsync()
        {
            var employees = new ObservableCollection<Employee>();

            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new MySqlCommand("SELECT * FROM tblEmployee", connection);
                using (var reader = await command.ExecuteReaderAsync())
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
