using HRTask.Models;

namespace HRTask.Services
{
	public interface IEmployeeAttendanceService:DataService<EmployeeAttendance>
	{
		public IEnumerable<EmployeeAttendance> GetEmployeeAttendances(int Id);
	}
}
