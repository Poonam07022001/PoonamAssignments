
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BankingApp.Domain.Models
{
    public class User 
    {
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Role { get; set; }
        public ICollection<Account>? Account { get; set; }
    }
}
