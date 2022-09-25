using HRTask.Data;
using HRTask.Models;

namespace HRTask.Services.ScreenServices
{
    public class ScreenService : IScreenService
    {
        private readonly ApplicationDbContext _db;

        public ScreenService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Screen Create(Screen Entity)
        {
            _db.Add(Entity);
            _db.SaveChanges();
            return Entity;
        }

        public bool Delete(Screen Entity)
        {
            _db.Remove(Entity);
            int result= _db.SaveChanges();
            if (result==0)
                return false;
            return true;
        }

        public Screen? Find(int Id)
        {
            return _db.Screens.Find(Id);
        }

        public IEnumerable<Screen> GetAll()
        {
            return _db.Screens;
        }

        public Screen Update(Screen Entity)
        {
            _db.Screens.Update(Entity);
            _db.SaveChanges();
            return Entity;
        }
    }
}
