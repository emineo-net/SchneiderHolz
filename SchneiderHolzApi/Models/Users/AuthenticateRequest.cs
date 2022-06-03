using System.ComponentModel.DataAnnotations;

namespace SchneiderHolzApi.Models.Users;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}