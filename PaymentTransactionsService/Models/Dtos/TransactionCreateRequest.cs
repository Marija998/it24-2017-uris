using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TransactionServiceAPI.Models;

namespace TransactionServiceAPI.Models.Dtos
{
    public class TransactionCreateRequest
    {
        [Required]
        public int SourceAccount { get; set; }

        [Required]
        public int DestinationAccount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal TransactionAmount { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public TranStatus TransactionStatus { get; set; }

    }
}
