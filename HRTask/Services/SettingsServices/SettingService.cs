using HRTask.Data;
using HRTask.Models;

namespace HRTask.Services.SettingsServices
{
    public class SettingService : ISettingService
    {
        private readonly ApplicationDbContext _db;

        public SettingService(ApplicationDbContext applicationDbContext)
        {
            this._db = applicationDbContext;
        }

        public Settings Create(Settings Entity)
        {
            _db.Settings.Add(Entity);
            _db.SaveChanges();
            return Entity;
        }

        public bool Delete(Settings Entity)
        {
            _db.Settings.Remove(Entity);
            var efficted=_db.SaveChanges();
            return efficted>0?true:false;
        }

        public Settings? Find(int Id)
        {
            return _db.Settings.Find(Id);
        }

        public IEnumerable<Settings> GetAll()
        {
            return _db.Settings;
        }

        public Settings Update(Settings Entity)
        {
            _db.Settings.Update(Entity);
            _db.SaveChanges();
            return Entity;
        }
    }
}
