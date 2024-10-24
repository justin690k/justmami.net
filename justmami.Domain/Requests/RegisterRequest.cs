using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace justmami.Domain.Requests;
public class RegisterRequest
{
    [Required, MaxLength(255)]
    public required string Firstname { get; set; }

    [Required, MaxLength(255)]
    public required string Lastname { get; set; }

    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required, MinLength(8), MaxLength(255)]
    public required string Password { get; set; }

    [Required, MinLength(8), MaxLength(255)]
    public required string ConfirmPassword { get; set; }
}
