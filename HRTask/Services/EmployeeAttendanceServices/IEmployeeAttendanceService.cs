using HRTask.Models;

namespace HRTask.Services
{
	public interface IEmployeeAttendanceService:IDataService<EmployeeAttendance>
	{
		public IEnumerable<EmployeeAttendance> GetEmployeeAttendances(int Id);
        public IEnumerable<EmployeeAttendance> GetAttendancesWithEmployeeInfo(DateTime start,DateTime end);

    }
}
