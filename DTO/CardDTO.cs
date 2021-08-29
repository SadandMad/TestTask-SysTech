using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestTask_SysTech.DTO
{
    public class CardDTO
    {
        [DisplayName("Счёт")]
        public string Bills { get; set; }
        [DisplayName("Сумма")]
        public decimal Amount { get; set; }
        internal CardDTO(string bills, decimal amount)
        {
            Bills = bills;
            Amount = amount;
        }
    }
}