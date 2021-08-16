using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatPizza.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreatPizza.API.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class MainController : ControllerBase
  {
    private ILog _ILog;

    public MainController()
    {
      _ILog = Log.GetInstance;
    }

    /// <summary>
    /// Generic method to test Rest API
    /// </summary>
    [HttpGet]
    public ActionResult<string> postTest()
    {
      return "true";
    }

    /// <summary>
    /// Method to get a list of pizzas
    /// </summary>
    /// <remarks>
    /// This method get all pizzas registered in the database
    ///</remarks>
    [HttpGet("Getpizzas")]
    public ActionResult<Models.Main.Pizzas.Response> GetPizzas()
    {
      Models.Main.Pizzas.Response response = new Models.Main.Pizzas.Response();
      try
      {
        response = Models.Main.Pizzas.Get();
      } catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;        
      }
    
      return response;
    }

    /// <summary>
    /// Method to get a list of toppings
    /// </summary>
    /// <remarks>
    /// This method get all toppings registered in the database
    ///</remarks>
    [HttpGet("Gettoppings")]
    public ActionResult<Models.Main.Toppings.Response> GetToppings()
    {
      Models.Main.Toppings.Response response = new Models.Main.Toppings.Response();
      try
      {
        response = Models.Main.Toppings.Get();
      } catch (Exception ex)
      {
        _ILog.LogException(ex.Message);
        response.correct = false;
      }
      return response;
    }

    /// <summary>
    /// Method to Add a pizza
    /// </summary>
    /// <remarks>
    /// This method add a pizza to the list of pizzas
    ///</remarks>
    [HttpPost("AddPizza")]
    public ActionResult<String> AddPizza(string pizzaDescription)
    {
      return "true";
    }

    /// <summary>
    /// Method to delete a pizza
    /// </summary>
    /// <remarks>
    /// This method delete a pizza from the list of pizzas
    ///</remarks>
    [HttpDelete("DeletePizza/{id}")]
    public ActionResult<String> DeletePizza(long id)
    {
      return "true";
    }
  }
}
