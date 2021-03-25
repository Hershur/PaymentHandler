using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentHandler.Models
{
    public class PaymentState
    {
        public enum State {
            Pending,
            Processed,
            Failed
        }
    }
}
