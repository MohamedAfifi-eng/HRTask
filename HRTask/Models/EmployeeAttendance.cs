using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRTask.Models
{
	public class EmployeeAttendance
	{
		[Key]
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		[Display(Name ="Attend Time")]
		public DateTime? TimeOfAttendance { get; set; }
        [Display(Name = "Leave Time")]
        public DateTime? TimeOfLeave { get; set; }
		
		public bool IsDayOff { get; set; }
		public decimal? calculatedPonus { get; set; }
		public decimal? discount { get; set; }
		public decimal? DayCost { get; set; }
        [ForeignKey(nameof(EmployeeId))]
		public Employee? Employee { get; set; }
	}
}
