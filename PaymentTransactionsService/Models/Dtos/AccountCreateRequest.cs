using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TransactionServiceAPI.Models.Dtos
{
    public class AccountCreateRequest
    {
        [Required]
        public string Currency { get; set; }

        [Required]
        public int UserId { get; set; }

    }
}
