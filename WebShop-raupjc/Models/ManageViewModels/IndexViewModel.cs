using System.ComponentModel.DataAnnotations;

namespace WebShop_raupjc.Models.ManageViewModels
{
    public class IndexViewModel
    {
		[Display(Name = "Korisničko ime")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Broj mobitela")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
