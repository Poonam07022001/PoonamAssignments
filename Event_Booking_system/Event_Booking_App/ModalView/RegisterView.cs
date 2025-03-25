using System.ComponentModel.DataAnnotations;

namespace Event_Booking_App.ModalView
{
    public class RegisterView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password didnot match ")]
        public string ConfirmPassword { get; set; }
    }
}
