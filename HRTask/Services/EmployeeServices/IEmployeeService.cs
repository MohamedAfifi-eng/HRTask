using HRTask.Models;

namespace HRTask.Services
{
    public interface IEmployeeService:DataService<Employee>
    {
        public Employee? GetByNtionalId(string NationalId);
        public IEnumerable<Employee> GetByName(string Name);
    }
}
