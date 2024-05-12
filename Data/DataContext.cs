using Exowatch.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exowatch.Data
{
	public class DataContext : IdentityDbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<Sensor> Sensors { get; set; } = null!;
		public DbSet<Temperature> Temperatures { get; set; } = null!;
		public DbSet<Area> Areas { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Sensor>().ToTable(nameof(Sensor));
			builder.Entity<Temperature>().ToTable(nameof(Temperature));
			builder.Entity<Air>().ToTable(nameof(Air));
			builder.Entity<Area>().ToTable(nameof(Area));
		}

	    public DbSet<Exowatch.Models.Air> Air { get; set; } = default!;
	}
}
