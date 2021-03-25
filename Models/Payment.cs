using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentHandler.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        [Required, CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "CardHolder name is invalid")]
        public string CardHolder { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(3), MinLength(3)]
        public string SecurityCode { get; set; }

        [Required]
        public Decimal Amount { get; set; }

        public string PaymentState { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedOn { get; set; }

    }
}
