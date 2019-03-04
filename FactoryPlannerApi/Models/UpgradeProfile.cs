namespace FactoryPlannerApi.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// Contains the upgrade profile definition
	/// </summary>
	public class UpgradeProfile
	{
		/// <summary>
		/// The unique id of the Upgrade Profile
		/// </summary>
		[Key]
		public int UpgradeProfileId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(128)")]
		public int ProfileName { get; set; }

		/// <summary>
		/// The Upgrade Profile description
		/// </summary>
		[Column(TypeName = "nvarchar(512)")]
		public string Description { get; set; }

		/// <summary>
		/// The profile creation time
		/// </summary>
		[Required]
		public DateTime Created { get; set; }

		/// <summary>
		/// Denotes if this upgrade profile is a system default
		/// NOTE: Default profiles will be available to all factories
		/// </summary>
		[Required]
		public bool Default { get; set; }

		/// <summary>
		/// The server path where this upgrade profile is stored
		/// </summary>
		[Required]
		public string ServerPath { get; set; }

		/// <summary>
		/// Denotes if this upgrade profile has been deleted
		/// </summary>
		[Required]
		public bool Deleted { get; set; }

		/// <summary>
		/// The date this factory was deleted
		/// </summary>
		public DateTime DeletedTime { get; set; }
	}
}