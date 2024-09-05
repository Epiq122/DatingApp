using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
	public class RegisterDto
	{

		[Required]
		public string Username { get; set; } = string.Empty;

		[Required]
		[StringLength(8, MinimumLength = 8)]
		public string Password { get; set; } = string.Empty;

	}
}
