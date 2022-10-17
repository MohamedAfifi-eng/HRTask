using HRTask.Models;

namespace HRTask.Services
{
    public interface IGroupService:IDataService<Group>
    {
        public Group GetByName(string name);
    }
}
