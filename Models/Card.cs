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
        private decimal amout;
        internal string Bills { get { return bills; } }
        internal decimal Amout { get { return amout; } }
        internal Card(string b, decimal a)
        {
            string ex = "";
            Regex pattern = new Regex(@"^[a-zA-Z0-9]{16}$");
            if (pattern.IsMatch(b))
            {
                bills = b;
            }
            else
            {
                //throw new ArgumentException($"Неверный номер счёта: {b}.");
                ex = $"Неверный номер счёта: {b}";
            }
            if ((a >= 0) && (a * 100 - Math.Truncate(a * 100) == 0))
            {
                amout = a;
            }
            else
            {
                //throw new ArgumentException($"Неверная сумма на счёте: {a}.");
                if (ex.Any())
                {
                    ex += $" и сумма на счетё: {a}";
                }
                else
                {
                    ex = $"Неверная сумма на счёте: {a}";
                }
            }
            if (ex.Any())
            {
                throw new ArgumentException(ex);
            }
        }
    }
}