using System.ComponentModel.DataAnnotations;

namespace API.Modules.Auth.Ressources;

public struct SigninRequest
{
    [Required]
    public string Username { get; set; }


    [Required]
    public string Password { get; set; }
}
