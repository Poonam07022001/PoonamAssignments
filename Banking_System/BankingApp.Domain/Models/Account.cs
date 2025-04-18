﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BankingApp.Domain.Enum;
using System.Text.Json.Serialization;

namespace BankingApp.Domain.Models
{
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]

        public string UserId { get; set; } = string.Empty;
 
        [Required]
        public long AccountNumber { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public AccountTypes AccountType { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public ICollection<Transaction>? Transaction { get; set; }

       
    }
}
