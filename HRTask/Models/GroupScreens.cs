using System.ComponentModel.DataAnnotations.Schema;

namespace HRTask.Models
{
    public class GroupScreens
    {
        public int Id { get; set; }
        public int GroupId_FK { get; set; }
        public int ScreenId_FK { get; set; }
        public bool View { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }

        #region Relations
        [ForeignKey(nameof(GroupId_FK))]
        public Group? Group { get; set; }
        [ForeignKey(nameof(ScreenId_FK))]
        public Screen? Screen { get; set; }

        #endregion
    }
}
