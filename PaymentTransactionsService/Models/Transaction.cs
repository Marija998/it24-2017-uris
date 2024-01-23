using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace TransactionServiceAPI.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int SourceAccount { get; set; }

        [Required]
        public int DestinationAccount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal TransactionAmount { get; set; }
        [Required]
        public TranStatus TransactionStatus { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
    public enum TranStatus
    {
        Failed,
        Success
    }
}
