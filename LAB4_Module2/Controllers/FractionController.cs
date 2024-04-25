using Microsoft.AspNetCore.Mvc;
using LAB4_Module2.Models;

namespace LAB4_Module2.Controllers
{
    public class FractionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Calculate(FractionViewModel model)
        {
            Fraction fraction1 = new Fraction(model.Numerator1, model.Denominator1);
            Fraction fraction2 = new Fraction(model.Numerator2, model.Denominator2);

            Fraction result = PerformOperation(fraction1, fraction2, model.Operation);

            model.Result = result.ToString();
            return View("Index", model);
        }

        private Fraction PerformOperation(Fraction fraction1, Fraction fraction2, string operation)
        {
            switch (operation)
            {
                case "Add":
                    return fraction1.Add(fraction2);
                case "Subtract":
                    return fraction1.Subtract(fraction2);
                default:
                    throw new ArgumentException("Invalid operation");
            }
        }
    }
}