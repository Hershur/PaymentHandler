using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentHandler
{
    public class ValidateCCInfo
    {
        public static bool IsCCInfoValid(string cardNo, DateTime expiryDate, string cvv)
        {
            var cvvCheck = new Regex(@"^\d{3}$");

            if (!cvvCheck.IsMatch(cvv)) // <2>check cvv is valid as "999"
                return false;


            var year = expiryDate.Year;
            var month = expiryDate.Month;
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); //get actual expiry date
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            //check expiry greater than today & within next 6 years <7, 8>>
            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        }
    }
}
