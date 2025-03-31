
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using BankingApp.Domain.Enum;

namespace BankingApp.Domain.Models
{
    public class Transaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        [Required]
        public Account Account { get; set; }
        [Required]
        public TransactionTypes TransactionType { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }


    }
}
