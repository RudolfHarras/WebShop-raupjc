using System.ComponentModel.DataAnnotations;

namespace WebShop_raupjc.Models.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lozinka mora biti duljine između {2} i {1} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinka i ponovljena lozinka se ne poklapaju.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
