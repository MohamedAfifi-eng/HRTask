using HRTask.Models;

namespace HRTask.Services
{
    public interface IGroupScreensService : IDataService<GroupScreens>
    {
        public IEnumerable<GroupScreens> GetForSpecificGroup(int id);
    }
}
