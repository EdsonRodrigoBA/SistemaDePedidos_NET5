using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class BaseDomain
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }


    }
}
