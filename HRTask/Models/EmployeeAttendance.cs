using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRTask.Models
{
	public class EmployeeAttendance
	{
		[Key]
		public int Id { get; set; }
		public int EmployeeId { get; set; }
		public DateTime? TimeOfAttendance { get; set; }
		public DateTime? TimeOfLeave { get; set; }
		public bool IsDayOff { get; set; }

		[ForeignKey(nameof(EmployeeId))]
		public Employee? Employee { get; set; }
	}
}
