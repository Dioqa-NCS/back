using System.ComponentModel.DataAnnotations;

namespace API.Modules.Auth.Ressources;

public class SigninRequest
{
    [Required]
    public string Username { get; set; }


    [Required]
    public string Password { get; set; }
}
