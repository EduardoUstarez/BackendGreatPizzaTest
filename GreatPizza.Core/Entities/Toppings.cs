using System;
using System.Collections.Generic;

namespace GreatPizza.Core.Entities
{
    public partial class Toppings
    {
        public long Toppingid { get; set; }
        public string Description { get; set; }
        public int? State { get; set; }
    }
}
