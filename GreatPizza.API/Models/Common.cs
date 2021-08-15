using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatPizza.API.Models
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
    public List<Topping> toppings { get; set; }
  }

  public class Topping
  {
    public long toppingid { get; set; }
    public string description { get; set; }
  }
}
