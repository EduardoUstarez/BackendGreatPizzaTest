using System;
using System.Collections.Generic;

namespace BackendGreatPizza.Entities
{
    public partial class Pizzatoppings
    {
        public long Pizzaid { get; set; }
        public long Toppingid { get; set; }
    }
}
