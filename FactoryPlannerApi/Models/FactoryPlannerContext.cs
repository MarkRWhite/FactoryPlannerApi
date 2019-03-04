namespace FactoryPlannerApi.Models
{
	using Microsoft.EntityFrameworkCore;

	/// <summary>
	/// The DBContext manager for the Factory Planner database
	/// </summary>
	public class FactoryPlannerContext : DbContext
	{
		/// <summary>
		/// Creates a new FactoryPlannerContext instance
		/// </summary>
		/// <param name="options"></param>
		public FactoryPlannerContext (DbContextOptions<FactoryPlannerContext> options )
			: base(options)
		{

		}

		/// <summary>
		/// Contains Factory Information
		/// </summary>
		public DbSet<Factory> Factories { get; set; }

		/// <summary>
		/// Contains User Information
		/// </summary>
		public DbSet<User> Users { get; set; }

		/// <summary>
		/// Contains Upgrade Profile Information
		/// </summary>
		public DbSet<UpgradeProfile> UpgradeProfiles { get; set; }

	}
}