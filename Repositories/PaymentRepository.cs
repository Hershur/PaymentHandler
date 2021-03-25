using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentHandler.Models
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDBContext _context;

        public PaymentRepository(PaymentDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            //Get All payments in db
            
            return _context.Payments.ToList();
            
            
        }

        
        public async Task<IActionResult> ProcessPayment(Payment payment)
        {

            if (ValidateCCInfo.IsCCInfoValid(payment.CreditCardNumber, payment.ExpirationDate, payment.SecurityCode))
            {
                payment = new Payment()
                {
                    CreditCardNumber = payment.CreditCardNumber,
                    CardHolder = payment.CardHolder,
                    ExpirationDate = Convert.ToDateTime(payment.ExpirationDate),
                    SecurityCode = payment.SecurityCode,
                    Amount = Convert.ToDecimal(payment.Amount),
                    PaymentState = PaymentState.State.Pending.ToString()
                };

               

                await _context.Payments.AddAsync(payment);
                await _context.SaveChangesAsync();

                return new OkObjectResult("Payment processed succesfully");

            }
            else
            {
                return new BadRequestObjectResult("Invalid Credit Card Details");
            }

        }

       

    }
}
