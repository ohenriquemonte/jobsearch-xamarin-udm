using System;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.Domain.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(10)]
		public string Name { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(6)]
		public string Password { get; set; }

		//public User()
		//{

		//}
	}
}