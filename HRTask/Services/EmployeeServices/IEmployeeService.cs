using HRTask.Models;

namespace HRTask.Services
{
    public interface IEmployeeService:IDataService<Employee>
    {
        public Employee? GetByNtionalId(string NationalId);
        public IEnumerable<Employee> GetByName(string Name);
        public IEnumerable<Employee> GetEmployeesWithAttendance();
    }
}
