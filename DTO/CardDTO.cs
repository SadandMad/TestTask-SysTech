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
        public string Bills { get; }
        [DisplayName("Сумма")]
        public decimal Amout { get; }
        internal CardDTO(string bills, decimal amout)
        {
            Bills = bills;
            Amout = amout;
        }
    }
}