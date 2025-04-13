using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Common
{
    public static class Extensions
    {
        public static decimal CalculateTotalPrice(this List<Membership> memberships)
        {
            return memberships.Sum(m => m.Price);
        }
    }
}
