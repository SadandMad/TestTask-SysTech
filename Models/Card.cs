using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TestTask_SysTech.Models
{
    internal class Card
    {
        private string bills;
        private decimal amount;
        internal string Bills { get { return bills; } }
        internal decimal Amount { get { return amount; } }
        internal Card(string b, decimal a)
        {
            Regex pattern = new Regex(@"^[a-zA-Z0-9]{16}$");
            if (pattern.IsMatch(b))
            {
                bills = b;
                if ((a >= 0) && (a * 100 - Math.Truncate(a * 100) == 0))
                {
                    amount = a;
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