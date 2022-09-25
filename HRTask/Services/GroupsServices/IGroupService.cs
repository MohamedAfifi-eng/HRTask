using HRTask.Models;

namespace HRTask.Services
{
    public interface IGroupService:DataService<Group>
    {
        public Group GetByName(string name);
    }
}
