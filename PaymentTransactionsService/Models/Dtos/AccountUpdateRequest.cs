using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TransactionServiceAPI.Models.Dtos
{
    public class AccountUpdateRequest
    {
        [Precision(18, 2)]
        public decimal Balance { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
