using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Common
{
    public abstract class Identifiable
    {
        public Guid Id { get; set; }

        protected Identifiable()
        {
            Id = Guid.NewGuid();
        }
    }
}
