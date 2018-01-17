using System.ComponentModel.DataAnnotations;

namespace WebShop_raupjc.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Ime { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [Display(Name = "Zapamti me")]
        public bool RememberMe { get; set; }


	    public string ReturnUrl { get; set; } = "/";
	}
}
