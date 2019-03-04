namespace FactoryPlannerApi.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	///     Defines a user
	/// </summary>
	public class User
	{
		/// <summary>
		///     The User Id
		/// </summary>
		[Key]
		public int UserId { get; set; }

		/// <summary>
		///     The Username
		/// </summary>
		[Required]
		[Column( TypeName = "nvarchar(25)" )]
		public string Username { get; set; }

		/// <summary>
		///     The user email address
		/// </summary>
		[Required]
		[Column( TypeName = "nvarchar(256)" )]
		public string Email { get; set; }

		/// <summary>
		///     The date the user was created
		/// </summary>
		[Required]
		public DateTime Created { get; set; }

		/// <summary>
		///     The user Password
		/// </summary>
		[Required]
		[Column( TypeName = "nvarchar(60)" )]
		public string Password { get; set; }

		/// <summary>
		///     The user cookie SessionId
		/// </summary>
		[Required]
		[Column( TypeName = "varchar(128)" )]
		public string SessionId { get; set; }

		/// <summary>
		///     Denotes if the user account is active
		/// </summary>
		[Required]
		public bool Enabled { get; set; }
	}
}