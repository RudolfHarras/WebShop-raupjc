using System.ComponentModel.DataAnnotations;

namespace WebShop_raupjc.Models.ManageViewModels
{
    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Lozinka mora biti duljine između {2} i {1} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ponovi lozinku")]
        [Compare("NewPassword", ErrorMessage = "Lozinka i ponovljena lozinka se ne poklapaju!")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
