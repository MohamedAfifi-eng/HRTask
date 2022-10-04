using HRTask.Data;
using HRTask.Models;
using Microsoft.EntityFrameworkCore;

namespace HRTask.Services
{
    public class GroupScreensService : IGroupScreensService
    {
        private readonly ApplicationDbContext _db;

        public GroupScreensService(ApplicationDbContext db)
        {
            _db = db;
        }

        public GroupScreens Create(GroupScreens Entity)
        {
            _db.GroupScreens.Add(Entity);
            _db.SaveChanges();
            return Entity;
        }

        public bool Delete(GroupScreens Entity)
        {
            _db.GroupScreens.Remove(Entity);
            if (_db.SaveChanges()>0)
            {
                return true;
            }
            return false;

        }

        public GroupScreens? Find(int Id)
        {
            return _db.GroupScreens.Find(Id);
        }

        public IEnumerable<GroupScreens> GetAll()
        {
            return _db.GroupScreens;
        }

        public IEnumerable<GroupScreens> GetForSpecificGroup(int id)
        {
            return _db.GroupScreens.Where(x=>x.GroupId_FK==id).Include(x=>x.Screen);
        }

        public GroupScreens Update(GroupScreens Entity)
        {
            _db.GroupScreens.Update(Entity);
            _db.SaveChanges();
            return Entity;
        }
    }
}
