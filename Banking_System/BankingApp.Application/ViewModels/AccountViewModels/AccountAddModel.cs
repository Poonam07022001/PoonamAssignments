using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Domain.Enum;

namespace BankingApp.Application.ViewModels.AccountViewModels
{
  public  class AccountAddModel
    {
        [Required]
        public long AccountNumber { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public AccountTypes AccountTypes { get; set; }
    }
}
