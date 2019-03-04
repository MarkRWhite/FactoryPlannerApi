namespace FactoryPlannerApi.Models
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	///     Defines a factory, the save file unit
	/// </summary>
	public class Factory
	{
		/// <summary>
		/// The Factory Id
		/// </summary>
		[Key]
		public int FactoryId { get; set; }

		/// <summary>
		/// The UserId of the user that this factory belongs to
		/// </summary>
		[Required]
		public User Owner { get; set; }

		/// <summary>
		/// The name of the Factory
		/// </summary>
		[Required]
		[Column( TypeName = "nvarchar(128)" )]
		public string FactoryName { get; set; }

		/// <summary>
		/// Defines the upgrade profile used in this server
		/// </summary>
		[Required]
		public UpgradeProfile UpgradeProfile { get; set; }

		/// <summary>
		/// The Factory description
		/// </summary>
		[Column(TypeName = "nvarchar(512)")]
		public string Description { get; set; }

		/// <summary>
		/// The Upgrade Profiles used in this factory
		/// </summary>
		[Required]
		public ICollection<UpgradeProfile> UpgradeProfiles { get; set; }

		/// <summary>
		/// The Date this factory was created
		/// </summary>
		[Required]
		public DateTime Created { get; set; }

		/// <summary>
		/// The last time this factory was saved
		/// </summary>
		[Required]
		public DateTime LastUpdated { get; set; }

		/// <summary>
		/// The user displayed folder path of the save file
		/// NOTE: Used to organize and display a user's save files online
		/// </summary>
		[Required]
		[Column(TypeName = "nvarchar(256)")]
		public string DisplayPath { get; set; }

		/// <summary>
		/// The server file path where the serialized factory information is stored
		/// </summary>
		[Required]
		public string ServerPath { get; set; }

		/// <summary>
		/// Denotes if this factory has been deleted
		/// NOTE: This will allow the database to delete them at its leisure
		/// </summary>
		[Required]
		public bool Deleted { get; set; }

		/// <summary>
		/// The date this factory was deleted
		/// </summary>
		public DateTime DeletedTime { get; set; }
	}
}