using HRTask.Data;
using HRTask.Models;

namespace HRTask.Services
{
	public class EmployeeAttendanceService : IEmployeeAttendanceService
	{
		private readonly ApplicationDbContext _db;

		public EmployeeAttendanceService(ApplicationDbContext db)
		{
			_db = db;
		}

		public EmployeeAttendance Create(EmployeeAttendance Entity)
		{
			_db.EmployeeAttendances.Add(Entity);
			_db.SaveChanges();
			return Entity;

		}

		public bool Delete(EmployeeAttendance Entity)
		{
			_db.EmployeeAttendances.Remove(Entity);
			if (_db.SaveChanges() > 0)
			{
				return true;
			}
			return false;
		}

		public EmployeeAttendance? Find(int Id)
		{
			return _db.EmployeeAttendances.Find(Id);
		}

		public IEnumerable<EmployeeAttendance> GetAll()
		{
			return _db.EmployeeAttendances;
		}

		public IEnumerable<EmployeeAttendance> GetEmployeeAttendances(int Id)
		{
			return GetAll().Where(x => x.EmployeeId == Id);
		}

		public EmployeeAttendance Update(EmployeeAttendance Entity)
		{
			_db.EmployeeAttendances.Update(Entity);
			_db.SaveChanges();
			return Entity;
		}
	}
}
