using System.ComponentModel.DataAnnotations;

namespace LMS.DTOs
{
    public class RegisterModelDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }    
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
    }
}
