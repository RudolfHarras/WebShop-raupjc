using System.ComponentModel.DataAnnotations;

namespace WebShop_raupjc.Models.ManageViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Trenutna lozinka")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lozinka mora biti duljine između {2} i {1} znakova.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova lozinka")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Ponovi novu lozinku")]
        [Compare("NewPassword", ErrorMessage = "Lozinka i ponovljena lozinka se ne poklapaju!")]
        public string ConfirmPassword { get; set; }

        public string StatusMessage { get; set; }
    }
}
