namespace Exowatch.Models
{
	public class Air : Sensor
	{
		public double CarbonMonoxide { get; set; }
		public double NitrogenMonoxide { get; set; }
		public double NitrogenDioxide { get; set; }
		public double Ozone {  get; set; }
		public double SulphurDioxide { get; set; }
	}
}
