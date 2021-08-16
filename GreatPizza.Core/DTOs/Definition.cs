using System;
using System.Collections.Generic;
using System.Text;

namespace GreatPizza.Core.DTOs
{
  public class Definition
  {
    public class Common
    {
      public bool correct { get; set; }
      public string message { get; set; }
    }
    public class Pizza
    {
      public long pizzaid { get; set; }
      public string description { get; set; }
      public List<Topping> toppings { get; set; } = new List<Topping>();
    }

    public class Topping
    {
      public long toppingid { get; set; }
      public string description { get; set; }
    }


  }
}
