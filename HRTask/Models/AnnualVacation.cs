using System.ComponentModel.DataAnnotations;

namespace HRTask.Models
{
    public class AnnualVacation
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="يجب إدخال إسم الإجازة")]
        [Display(Name="الإسم")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="يجب إدخال تاريخ الإجازة")]
        public DateTime Date { get; set; }
    }
}
