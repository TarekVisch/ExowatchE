namespace Exowatch.Models
{
	public class Area
	{
		public long ID { get; set; }
		public string? Name { get; set; }
		public double Radius { get; set; }
		public List<Temperature>? Temperatures { get; set; }
		public List<Air>? Air { get; set; }
	}
}
