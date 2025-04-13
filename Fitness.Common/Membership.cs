using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Common
{
    public class Membership : Identifiable
    {
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }

        public Membership() { }

        public Membership(string type, DateTime startDate, decimal price)
        {
            Type = type;
            StartDate = startDate;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Type} абонемент | Початок: {StartDate:d} | Ціна: {Price} грн";
        }
    }
}
