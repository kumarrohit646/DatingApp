using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    [StringLength(8, MinimumLength = 4)]
    public string Password { get; set; }
}
