using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentHandler.Models
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments();

        Task<IActionResult> ProcessPayment(Payment payment);
    }
}
