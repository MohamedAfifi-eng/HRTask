using HRTask.Data;
using HRTask.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HRTask.Services.GroupsServices
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _db;

        public GroupService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Group Create(Group Entity)
        {
            _db.Groups.Add(Entity);
            _db.SaveChanges();
            return Entity;
        }

        public bool Delete(Group Entity)
        {
            _db.Remove(Entity);
            int result = _db.SaveChanges();
            return result>0?true:false;
        }

        public Group? Find(int Id)
        {
            return _db.Groups.Find(Id);
        }

        public IEnumerable<Group> GetAll()
        {
            return _db.Groups;
        }

        public Group Update(Group Entity)
        {
            _db.Groups.Update(Entity);
            _db.SaveChanges();
            return Entity;
        }
        public Group GetByName(string name)
        {
            return _db.Groups.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
