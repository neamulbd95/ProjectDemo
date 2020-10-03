using System.ComponentModel.DataAnnotations;

namespace ProjectDemoBackEND.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 6, ErrorMessage="You must specify your password between 6 and 10.")]
        public string Password { get; set; }
    }
}