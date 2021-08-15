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
    /// Se usa para probar
    /// </summary>
    [HttpGet]
    public ActionResult<string> postTest()
    {
      try
      {
        throw new Exception("Error");
      } catch
      {
        _ILog.LogException("Dio un error");
      }
      return "true";
    }

    /// <summary>
    /// Method to get pizzas
    /// </summary>
    /// <returns>Pizzas</returns>
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
    /// Method to get toppings
    /// </summary>
    /// <returns>Toppings</returns>
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
    /// Method to get toppings
    /// </summary>
    /// <returns>Toppings</returns>
    [HttpDelete("DeletePizza/{id}")]
    public ActionResult<String> DeletePizza(long id)
    {
      return "true";
    }
  }
}
