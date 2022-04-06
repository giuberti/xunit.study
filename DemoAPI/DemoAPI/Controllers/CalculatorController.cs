using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        [Route("add/{a}/{b}")]
        public ActionResult<double> GetAdded(double a, double b)
        {
            return new DemoCalc.Calculator().Add(a, b);
        }

        [HttpGet]
        [Route("substract/{a}/{b}")]
        public ActionResult<double> GetSubstracted(double a, double b)
        {
            return new DemoCalc.Calculator().Substract(a, b);
        }

        [HttpGet]
        [Route("multiply/{a}/{b}")]
        public ActionResult<double> GetMultiplied(double a, double b)
        {
            return new DemoCalc.Calculator().Multiply(a, b);
        }

        [HttpGet]
        [Route("divide/{a}/{b}")]
        public ActionResult<double> GetDivided(double a, double b)
        {
            return new DemoCalc.Calculator().Divide(a, b);
        }

        [HttpGet]
        [Route("factorial/{a}")]
        public ActionResult<double> GetFactored(double a)
        {
            return new DemoCalc.Calculator().Factorial(a);
        }
    }
}
