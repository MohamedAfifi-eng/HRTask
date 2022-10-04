using HRTask.Models;

namespace HRTask.Services
{
    public interface IGroupScreensService : DataService<GroupScreens>
    {
        public IEnumerable<GroupScreens> GetForSpecificGroup(int id);
    }
}
