using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TestTask_SysTech.Models
{
    internal class Card
    {
        internal string Bills;
        internal decimal Amount;
        internal Card(string bills, decimal amount)
        {
            Regex pattern = new Regex(@"^[a-zA-Z0-9]{16}$");
            if (pattern.IsMatch(bills))
            {
                Bills = bills;
                if ((amount >= 0) && (amount * 100 - Math.Truncate(amount * 100) == 0))
                {
                    Amount = amount;
                }
                else
                {
                    throw new ArgumentException($"Неверная сумма на счёте: {amount}.");
                }
            }
            else
            {
                throw new ArgumentException($"Неверный номер счёта: {bills}.");
            }
        }
    }
}