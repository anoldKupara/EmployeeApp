using Microsoft.AspNetCore.Mvc;

namespace My_Employee_App.Controllers
{
    public class EmployeesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
