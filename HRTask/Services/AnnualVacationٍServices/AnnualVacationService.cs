using HRTask.Data;
using HRTask.Models;

namespace HRTask.Services
{
    public class AnnualVacationService : IAnnualVacationService
    {
        private readonly ApplicationDbContext _db;

        public AnnualVacationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public AnnualVacation Create(AnnualVacation Entity)
        {
            _db.AnnualVacations.Add(Entity);
            _db.SaveChanges();
            return Entity;
        }

        public bool Delete(AnnualVacation Entity)
        {
            _db.AnnualVacations.Remove(Entity);
            if (_db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public AnnualVacation? Find(int Id)
        {
            return _db.AnnualVacations.Find(Id);

        }

        public IEnumerable<AnnualVacation> GetAll()
        {
            return _db.AnnualVacations;
        }

        public AnnualVacation Update(AnnualVacation Entity)
        {
            _db.AnnualVacations.Update(Entity);
            _db.SaveChanges();
            return Entity;
        }
    }
}
