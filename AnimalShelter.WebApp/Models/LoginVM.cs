using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.WebApp.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "User name")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
