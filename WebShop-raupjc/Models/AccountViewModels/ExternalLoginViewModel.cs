using System.ComponentModel.DataAnnotations;

namespace WebShop_raupjc.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
