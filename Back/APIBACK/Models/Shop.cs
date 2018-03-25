using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBACK.Models
{
    public class Shop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Thing> Things { get; set; }
    }
}
