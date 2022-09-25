using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace HRTask.Models
{
    public class Screen
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30,MinimumLength =3,ErrorMessage ="إسم الشاشة يجب ان لا يقل عن 3 حروف و لا يزيد عن 30 حرف")]
        public string Name { get; set; }

        #region Relations
        // we can put virtual keyword and install entityfrmework.proxies and use Lazy loading but now we use eager loading as default
        public List<GroupScreens>? GroupScreens { get; set; }
        #endregion
    }
}
