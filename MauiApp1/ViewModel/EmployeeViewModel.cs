using MauiApp1.Model;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeService _employeeService;
        public ObservableCollection<Employee> Employees { get; set; }
        private string _statusMessage;

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoadDataCommand { get; }

        public EmployeeViewModel()
        {
            _employeeService = new EmployeeService();
            Employees = new ObservableCollection<Employee>();
            LoadDataCommand = new Command(async () => await LoadData());
        }

        public async Task LoadData()
        {
            try
            {
                var employees = await _employeeService.GetEmployeesAsync();
                Employees.Clear();
                foreach (var emp in employees)
                {
                    Employees.Add(emp);
                }
                StatusMessage = "Data loaded successfully.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
