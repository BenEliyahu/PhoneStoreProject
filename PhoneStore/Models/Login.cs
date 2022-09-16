using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Models
{
    public class Login
    {
        [Key, Column(Order = 1)]
        [Required(ErrorMessage = "Please enter a username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        public string? Password { get; set; }
    }
}
