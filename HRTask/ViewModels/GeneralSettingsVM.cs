namespace HRTask.ViewModels
{
	public class GeneralSettingsVM
	{
		public byte Extra { get; set; }
		public byte Discount { get; set; }
		private List<DayOfWeek> dayesOff;

		public List<DayOfWeek> DayesOff
        {
			get { return dayesOff; }
			set {
				dayesOff = value; 
			}
		}

	}
}
