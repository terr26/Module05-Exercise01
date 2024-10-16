using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Module05_Exercise01.Model;
using Module05_Exercise01.Services;
using System.Windows.Input;

namespace Module05_Exercise01.ViewModel
{
    public class EmployeeViewModel : BindableObject
    {
        private readonly DatabaseService _databaseService;
        public ObservableCollection<Employee> Employees { get; set; }

        public ICommand LoadEmployeesCommand { get; }

        public EmployeeViewModel()
        {
            _databaseService = new DatabaseService();
            Employees = new ObservableCollection<Employee>();
            LoadEmployeesCommand = new Command(async () => await LoadEmployeesAsync());
        }

        private async Task LoadEmployeesAsync()
        {
            var employees = await _databaseService.GetEmployeesAsync();
            Employees.Clear();
            foreach (var employee in employees)
            {
                Employees.Add(employee);
            }
        }
    }
}
