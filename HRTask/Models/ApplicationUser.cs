using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRTask.Models
{
    public class ApplicationUser:IdentityUser
    {
        public int? GroupId_FK { get; set; }

        [ForeignKey(nameof(GroupId_FK))]
        public Group? Group { get; set; }
    }
}
