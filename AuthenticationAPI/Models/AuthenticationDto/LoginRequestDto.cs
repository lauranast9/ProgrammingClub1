using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models.AuthenticationDto
{
    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
