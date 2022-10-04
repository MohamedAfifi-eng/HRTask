using HRTask.Data;
using HRTask.Models;

namespace HRTask.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _db;

        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Employee Create(Employee Entity)
        {

            _db.Employees.Add(Entity);
            _db.SaveChanges();
            return Entity;
        }

        public Boolean Delete(Employee Entity)
        {
             _db.Employees.Remove(Entity);
            int result= _db.SaveChanges();
            if (result>0)
                return true;
            
            return false;
        }

        public Employee? Find(int Id)
        {
           return _db.Employees.Find(Id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees;
        }

        public IEnumerable<Employee> GetByName(string Name)
        {
            return _db.Employees.Where(x => x.Name.Contains(Name));
        }

        public Employee? GetByNtionalId(string NationalId)
        {
            return _db.Employees.Where(x => x.NationalId == NationalId).FirstOrDefault();
        }

        public Employee Update(Employee Entity)
        {
            _db.Employees.Update(Entity);
            _db.SaveChanges();
            return Entity;
        }
    }
}
